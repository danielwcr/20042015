using ProvaSiteware.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvaSiteware.MVC.Common;
using ProvaSiteware.MVC.ViewModels;
using AutoMapper;
using ProvaSiteware.Application;
using ProvaSiteware.Domain.Entities;

namespace ProvaSiteware.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoAppService ProdutoApp;

        public ActionResult Index()
        {
            var produtos = ProdutoApp.GetAll();
            return View(Mapper.Map<IEnumerable<ProdutoViewModel>>(produtos));
        }

        public ActionResult Details(int id)
        {
            var produto = ProdutoApp.Get(id);
            return View(Mapper.Map<ProdutoViewModel>(produto));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = Mapper.Map<Produto>(produtoViewModel);
                ProdutoApp.Insert(produto);

                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }

        public ActionResult Edit(int id)
        {
            var produto = ProdutoApp.Get(id);
            return View(Mapper.Map<ProdutoViewModel>(produto));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = Mapper.Map<Produto>(produtoViewModel);
                ProdutoApp.Insert(produto);

                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }

        public ActionResult Delete(int id)
        {
            var produto = ProdutoApp.Get(id);
            return View(Mapper.Map<ProdutoViewModel>(produto));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = ProdutoApp.Get(id);
            ProdutoApp.Delete(produto);

            return RedirectToAction("Index");
        }
    }
}
