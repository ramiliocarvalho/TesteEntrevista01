using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAppTesteEntrevista01.Filters;
using WebAppTesteEntrevista01.Models;
using WebAppTesteEntrevista01.Repository;

namespace WebAppTesteEntrevista01.Controllers
{
    [PageUserLoged]
    [PageRestrictedAdmin]
    public class MotosController : Controller
    {
        private readonly IMoto _moto;
        public MotosController(IMoto moto)
        {
            _moto = moto;
        }

        public IActionResult Index()
        {
            var motos = _moto.List();

            return View(motos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var moto = _moto.GetById(id);

            return View(moto);
        }

        public IActionResult ConfirmDelete(int id)
        {
            //Eu como usuário admin quero remover uma moto que foi cadastrado incorretamente, desde que não tenha registro de locações.


            var moto = _moto.GetById(id);

            return View(moto);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var isDeleted = _moto.Delete(id);
                if (isDeleted)
                {
                    TempData["MessageSucess"] = "Moto apagada com sucesso";
                }
                else
                {
                    TempData["MessageError"] = $"Ops, Não conseguimos apagar a moto";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MessageError"] = $"Ops, Não conseguimos apagar a moto, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Create(Models.Moto moto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var motoDb = _moto.GetByPlaca(moto.Placa);
                    if (motoDb != null)
                        TempData["MessageError"] = "Esta placa já se encontra em nosso sistema.";
                    else
                    {
                        _moto.Create(moto);
                        TempData["MessageSucess"] = "Moto cadastrada com sucesso";
                    }

                    return RedirectToAction("Index");
                }

                return View(moto);
            }
            catch (Exception ex)
            {
                TempData["MessageError"] = $"Ops, Não conseguimos cadastrar a moto, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(Models.Moto moto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var motoDb = _moto.GetByPlaca(moto.Placa);
                    if (motoDb == null || motoDb.Id == moto.Id)
                    {
                        _moto.Edit(moto);
                        TempData["MessageSucess"] = "Placa da moto alterada com sucesso";
                    }
                    else
                        TempData["MessageError"] = "Esta placa já se encontra em nosso sistema.";

                    return RedirectToAction("Index");
                }

                return View(moto);
            }
            catch (Exception ex)
            {
                TempData["MessageError"] = $"Ops, Não conseguimos atualizar a placa da moto, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
