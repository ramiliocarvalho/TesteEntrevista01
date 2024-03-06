using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppTesteEntrevista01.Helper;
using WebAppTesteEntrevista01.Models;
using WebAppTesteEntrevista01.Repository;

namespace WebAppTesteEntrevista01.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuario _usuario;
        private readonly ISessao _sessao;

        public LoginController(IUsuario usuario, ISessao sessao)
        {
            _usuario = usuario;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            //Se o usuário estiver logado, redirecionar para a home
            if (_sessao.GetSessionUser() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Exit()
        {
            _sessao.RemoveSessionUser();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Start(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = _usuario.GetByLogin(login.User);

                    if (usuario != null)
                    {
                        if (usuario.IsPasswordValid(login.Password))
                        {
                            _sessao.CreateSessionUser(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                            TempData["MessageError"] = "Senha do usuário inválida. Por favor, tente novamente.";
                    }
                    else
                        TempData["MessageError"] = "Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["MessageError"] = $"Ops, Não conseguimos realizar seu login, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.CadastroEntregador entregador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dtNascto = new DateTime(entregador.DataNascimento.Year,
                                                entregador.DataNascimento.Month,
                                                entregador.DataNascimento.Day, 03, 00, 00, DateTimeKind.Utc);

                    var cnpjDb = _usuario.GetByCnpj(entregador.Cnpj);
                    if (cnpjDb != null)
                    {
                        TempData["MessageError"] = "Este CNPJ já se encontra em nosso sistema.";
                        return RedirectToAction("Index");
                    }

                    var cnhDb = _usuario.GetByCnh(entregador.NumeroCnh);
                    if (cnhDb != null)
                    {
                        TempData["MessageError"] = "Esta CNH já se encontra em nosso sistema.";
                        return RedirectToAction("Index");
                    }

                    var usuario = new Models.Usuario()
                    {
                        Nome = entregador.Nome,
                        Login = entregador.Login,
                        Senha = entregador.Senha,
                        Email = entregador.Email,
                        Perfil = Enums.PerfilEnums.Entregador,
                        Entregador = new Entregador()
                        {
                            Cnpj = entregador.Cnpj,
                            DataNascimento = dtNascto,
                            NumeroCnh = entregador.NumeroCnh,
                            TipoCnh = entregador.TipoCnh
                        }
                    };

                    _usuario.Create(usuario);
                    TempData["MessageSucess"] = "Entregador cadastrado com sucesso. Sistema disponivel para acesso !!!";

                    return RedirectToAction("Index");
                }

                return View(entregador);
            }
            catch (Exception ex)
            {
                TempData["MessageError"] = $"Ops, Não conseguimos cadastrar o entregador, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
