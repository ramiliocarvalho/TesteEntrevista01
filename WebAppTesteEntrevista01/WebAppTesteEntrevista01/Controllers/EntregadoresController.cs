using Microsoft.AspNetCore.Mvc;
using WebAppTesteEntrevista01.Helper;
using WebAppTesteEntrevista01.Models;
using WebAppTesteEntrevista01.Repository;

namespace WebAppTesteEntrevista01.Controllers
{
    public class EntregadoresController : Controller
    {
        private readonly ISessao _sessao;
        private readonly Models.Usuario _usuarioLogado;
        private readonly IUsuario _usuario;

        private string pathImage;

        public EntregadoresController(IWebHostEnvironment sistem, ISessao sessao, IUsuario usuario)
        {
            pathImage = sistem.WebRootPath;
            _sessao = sessao;
            _usuario = usuario;
            _usuarioLogado = _sessao.GetSessionUser();
        }
        public IActionResult Upload()
        {
            var entregador = _usuario.GetEntregadorById(_usuarioLogado.Id);

            return View(entregador);
        }

        [HttpPost]
        public IActionResult Upload(IFormFile foto)
        {
            if (foto is null)
            {
                TempData["MessageError"] = "Nenhuma imagem selecionada.";
                return Redirect("Upload");
            }

            var pathImageSave = $"{pathImage}\\Images\\";
            var newNameImage = $"{Guid.NewGuid()}_{foto.FileName}";

            var tam = newNameImage.Length - 3;
            if (newNameImage.Substring(tam, 3).ToLower() != "bmp" && (newNameImage.Substring(tam, 3).ToLower() != "png"))
            {
                TempData["MessageError"] = "Imagem aceita somente nos formatos .png ou .bmp";
                return Redirect("Upload");
            }

            System.IO.DirectoryInfo di = new DirectoryInfo($"{pathImageSave}");
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            if (!Directory.Exists(pathImageSave))
                Directory.CreateDirectory(pathImageSave);

            _usuario.SetImageCnh(_usuarioLogado.Id, newNameImage);

            using (var stream = System.IO.File.Create($"{pathImageSave}{newNameImage}"))
            {
                foto.CopyToAsync(stream);
            }

            return Redirect("Upload");
        }
    }
}
