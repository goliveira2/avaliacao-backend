﻿using System;
using System.Linq;
using System.Web.Mvc;
using Angular_MVC_Crud.Models;

namespace Angular_MVC_Crud.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Todos os livros
        public JsonResult GetTodosLivros()
        {
            using (livroContexto contextObj = new livroContexto())
            {
                try
                {
                    var listaLivros = contextObj.livro.ToList();
                    return Json(listaLivros, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //GET: livro por Id
        public JsonResult GetLivroPorId(string id)
        {
            using (livroContexto contextObj = new livroContexto())
            {
                var livroId = Convert.ToInt32(id);
                var getLivroPorId = contextObj.livro.Find(livroId);
                return Json(getLivroPorId, JsonRequestBehavior.AllowGet);
            }
        }

        public string AtualizarLivro(Livro livro)
        {
            if (livro != null)
            {
                using (livroContexto contextObj = new livroContexto())
                {
                    int livroId = Convert.ToInt32(livro.Id);
                    Livro _livro = contextObj.livro.Where(b => b.Id == livroId).FirstOrDefault();
                    _livro.Titulo = livro.Titulo;
                    _livro.Autor = livro.Autor;
                    contextObj.SaveChanges();
                    return "Registro de livro atualizado com sucesso";
                }
            }
            else
            {
                return "Registro de livro inválido";
            }
        }
        // Adiciona livro
        public string AdicionarLivro(Livro livro)
        {
            if (livro != null)
            {
                using (livroContexto contextObj = new livroContexto())
                {
                    try
                    {
                        contextObj.livro.Add(livro);
                        contextObj.SaveChanges();
                        return "Registro de livro adicionado com sucesso";
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                return "Registro de livro inválido";
            }
        }

        // Deleta livro
        public string DeletarLivro(Livro livro)
        {
            //if (!String.IsNullOrEmpty(livroId))
            if (livro != null)
            {
                try
                {
                    int _livroId = livro.Id;
                    using (livroContexto contextObj = new livroContexto())
                    {
                        var _livro = contextObj.livro.Find(_livroId);
                        contextObj.livro.Remove(_livro);
                        contextObj.SaveChanges();
                        return "Registro do livro selecionado deletado com sucesso";
                    }
                }
                catch (Exception)
                {
                    return "Detalhes do livro não encontrado";
                }
            }
            else
            {
                return "Operação inválida";
            }
        }
    }
}