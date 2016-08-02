using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Lab.Presentation.MVC.ViewModels;
using AutoMapper;
using Lab.Domain.Entities;
using Lab.Application.Interfaces;

namespace Lab.Presentation.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService produtoApp;

        public ProdutoController(IProdutoAppService produtoApp)
        {
            this.produtoApp = produtoApp;
        }

        public ActionResult Index()
        {
            var produtos = produtoApp.GetAll();
            return View(produtos);
        }

        public ActionResult IndexAngular()
        {
            return View();
        }

        public ActionResult ObterProdutos()
        {
            var produtos = produtoApp.GetAll();
            return Json(produtos, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                produtoApp.Save(produto);
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        public ActionResult Edit(int id)
        {
            var produto = produtoApp.Get(id);
            return View(produto);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                produtoApp.Save(produto);
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        public ActionResult Delete(int id)
        {
            var produto = produtoApp.Get(id);
            return View(produto);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = produtoApp.Get(id);
            produtoApp.Delete(produto);

            return RedirectToAction("Index");
        }
    }
}
