using Microsoft.AspNetCore.Mvc;
using WebAppTesteEntrevista01.Models;
using WebAppTesteEntrevista01.Repository;

namespace WebAppTesteEntrevista01.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuario _usuario;
        public UsuariosController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        public IActionResult Index()
        {
            var usuarios = _usuario.List();

            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var usuario = _usuario.Get(id);

            return View(usuario);
        }

        public IActionResult ConfirmDelete(int id)
        {
            var usuario = _usuario.Get(id);

            return View(usuario);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var isDeleted = _usuario.Delete(id);
                if (isDeleted)
                {
                    TempData["MessageSucess"] = "Usuário apagado com sucesso";
                }
                else
                {
                    TempData["MessageError"] = $"Ops, Não conseguimos apagar o usuário";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MessageError"] = $"Ops, Não conseguimos apagar o usuário, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Create(Models.Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuario.Create(usuario);
                    TempData["MessageSucess"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MessageError"] = $"Ops, Não conseguimos cadastrar o usuário, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(Models.Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuario.Edit(usuario);
                    TempData["MessageSucess"] = "Usuário alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MessageError"] = $"Ops, Não conseguimos atualizar o usuário, tente novamente. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
