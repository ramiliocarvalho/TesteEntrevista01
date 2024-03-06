using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using System.Globalization;
using WebAppTesteEntrevista01.Enums;
using WebAppTesteEntrevista01.Filters;
using WebAppTesteEntrevista01.Helper;
using WebAppTesteEntrevista01.Models;
using WebAppTesteEntrevista01.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAppTesteEntrevista01.Controllers
{
    [PageUserLoged]
    public class LocacoesController : Controller
    {
        private readonly ISessao _sessao;
        private readonly ILocacao _locacao;
        private readonly IPlano _plano;
        private readonly IUsuario _usuario;
        private readonly Models.Usuario _usuarioLogado;
        private CotacaoLocacao _cotacaoLocacao;

        public LocacoesController(ILocacao locacao, IPlano plano, ISessao sessao, IUsuario usuario)
        {
            _locacao = locacao;
            _plano = plano;
            _sessao = sessao;
            _usuario = usuario;
            _usuarioLogado = _sessao.GetSessionUser();
        }

        public IActionResult Index()
        {
            var locacoes = _locacao.List();

            return View(locacoes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var planos = _plano.List();

            ViewBag.Planos = new SelectList(planos, "Id", "Descricao");

            return View(new CotacaoLocacao());
        }

        [HttpPost]
        public ActionResult Create(int id, string dataAvulsa)
        {
            if (id <= 0)
            {
                TempData["MessageError"] = "O Plano deve ser informado";
                return RedirectToAction("Create");
            }

            var planoSelecionado = _plano.GetById(id);
            var motoDisponivel = _locacao.GetMotoDisponivel();
            var dataRegistro = DateTime.Now;
            var dataInicio = dataRegistro.AddDays(1);
            var dataPrevisaoTerminoSistema = dataInicio.AddDays(planoSelecionado.NumeroDiaria).Date;
            var categoria = _usuario.GetEntregadorById(_usuarioLogado.Id);
            decimal totalPagar = (planoSelecionado.NumeroDiaria * planoSelecionado.ValorDiaria);
            decimal totalPagarAvulso = 0;
            bool isMulta = false;

            if (DateTime.TryParse(dataAvulsa, out DateTime dataUsuario))
            {
                if (dataUsuario < dataPrevisaoTerminoSistema)
                {
                    var diasNaoEfetivados = (dataPrevisaoTerminoSistema.Subtract(dataUsuario)).Days;
                    var valorDiasNaoEfetivados = diasNaoEfetivados * planoSelecionado.ValorDiaria;
                    decimal multaAdicional = (planoSelecionado.PorcentagemDiariaNaoEfetivada * valorDiasNaoEfetivados) / 100;

                    totalPagarAvulso = totalPagar + multaAdicional;
                    isMulta = true;
                }
                else if (dataUsuario > dataPrevisaoTerminoSistema)
                {
                    var diasAdicionais = (dataUsuario.Subtract(dataPrevisaoTerminoSistema)).Days;
                    decimal multaAdicional = diasAdicionais * planoSelecionado.ValorDiariaAdicional;

                    totalPagarAvulso = totalPagar + multaAdicional;
                    isMulta = true;
                }
            }

            var planos = _plano.List();
            ViewBag.Planos = new SelectList(planos, "Id", "Descricao");

            _cotacaoLocacao = new CotacaoLocacao()
            {
                TotalPagar = string.Format("{0:N}", totalPagar),
                TotalPagarAvulso = string.Format("{0:N}", totalPagarAvulso),
                IsMulta = isMulta,
                DataCriacao = dataRegistro,
                DataInicio = dataInicio,
                DataPrevisaoTerminoSistema = dataPrevisaoTerminoSistema,
                //DataPrevisaoTerminoUsuario

                NomeEntregador = _usuarioLogado.Nome,
                EmailEntregador = _usuarioLogado.Email,
                Categoria = categoria.TipoCnh.GetEnumDescription(),

                AnoMoto = motoDisponivel == null ? "Indisponivel" : motoDisponivel.Ano.ToString(),
                ModeloMoto = motoDisponivel == null ? "Indisponivel" : motoDisponivel?.Modelo,
                PlacaMoto = motoDisponivel == null ? "Indisponivel" : motoDisponivel?.Placa,

                DescricaoPlano = planoSelecionado.Descricao,
                NumeroDiaria = planoSelecionado.NumeroDiaria,
                ValorDiaria = planoSelecionado.ValorDiaria.ToString(),
                //ValorDiariaAdicional = planoSelecionado.ValorDiariaAdicional.ToString("D2"),
                //PorcentagemDiariaNaoEfetivada = planoSelecionado.PorcentagemDiariaNaoEfetivada,
                IsCotacaoCalculada = true,
                IsLocacaoDisponivel = true
            };

            if (_cotacaoLocacao.PlacaMoto == "Indisponivel")
            {
                TempData["MessageError"] = "Ops, Não há moto disponivel em nosso estoque.";
                _cotacaoLocacao.IsLocacaoDisponivel = false;
            }

            if (categoria.TipoCnh == TipoCnhEnums.CategoriaB)
            {
                TempData["MessageError"] = "Entregador não possui habilitação de categoria A.";
                _cotacaoLocacao.IsLocacaoDisponivel = false;
            }

            return View(_cotacaoLocacao);
        }
    }
}
