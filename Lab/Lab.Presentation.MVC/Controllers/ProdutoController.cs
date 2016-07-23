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
            return View(Mapper.Map<IEnumerable<ProdutoViewModel>>(produtos));
        }

        public ActionResult IndexAngular()
        {
            return View();
        }

        public ActionResult ObterProdutos()
        {
            var produtos = produtoApp.GetAll();
            return Json(Mapper.Map<IEnumerable<ProdutoViewModel>>(produtos), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            var produto = produtoApp.Get(id);
            return View(Mapper.Map<ProdutoViewModel>(produto));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = Mapper.Map<Produto>(produtoViewModel);
                produtoApp.Insert(produto);
                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }

        public ActionResult Edit(int id)
        {
            var produto = produtoApp.Get(id);
            return View(Mapper.Map<ProdutoViewModel>(produto));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = Mapper.Map<Produto>(produtoViewModel);
                produtoApp.Update(produto);

                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }

        public ActionResult Delete(int id)
        {
            var produto = produtoApp.Get(id);
            return View(Mapper.Map<ProdutoViewModel>(produto));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = produtoApp.Get(id);
            produtoApp.Delete(produto);

            return RedirectToAction("Index");
        }
    }
}
