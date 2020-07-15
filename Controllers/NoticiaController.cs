using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_Playes.Models;
using Microsoft.AspNetCore.Http;
using System.IO;


namespace E_Playes.Controllers
{
    public class NoticiaController : Controller
    {
        Noticia noticiaModel=new Noticia();

        public IActionResult Index()
        {
            ViewBag.Noticias= noticiaModel.ReadAll();
            return View();
        }
        
        public IActionResult Cadastrar(IFormCollection form)
        {
            Noticia novaNoticia   = new Noticia();
            novaNoticia.IdNoticia = Int32.Parse(form["IdNoticia"]);
            novaNoticia.Titulo   = form["Titulo"];
            novaNoticia.Texto = form["Texto"];
            //Upload de imagem
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                novaNoticia.Imagem   = file.FileName;
            }
            else
            {
                novaNoticia.Imagem   = "padrao.png";
            }

            //Fim de Upload

            noticiaModel.Create(novaNoticia);            

            return LocalRedirect("~/Noticia");
        }

        [Route("Noticia/{id}")]
        public IActionResult Excluir(int id)
        {
            noticiaModel.Delete(id);
            return LocalRedirect("~/Noticia");
        }


    }
}