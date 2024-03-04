using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAppTesteEntrevista01.Models;
using WebAppTesteEntrevista01.Repository;

namespace WebAppTesteEntrevista01.Controllers
{
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
            var moto = _moto.Get(id);

            return View(moto);
        }

        public IActionResult ConfirmDelete(int id)
        {
            var moto = _moto.Get(id);

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
                    _moto.Create(moto);
                    TempData["MessageSucess"] = "Moto cadastrada com sucesso";
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
                    _moto.Edit(moto);
                    TempData["MessageSucess"] = "Moto alterada com sucesso";
                    return RedirectToAction("Index");
                }

                return View(moto);
            }
            catch (Exception ex)
            {
                TempData["MessageError"] = $"Ops, Não conseguimos atualizar a moto, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
