using ProvaSiteware.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvaSiteware.MVC.Common;
using ProvaSiteware.MVC.ViewModels;
using AutoMapper;
using ProvaSiteware.Domain.Entities;
using ProvaSiteware.Application.Interfaces;
using ProvaSiteware.Domain.Common;
using ProvaSiteware.Domain.Common.Helpers;

namespace ProvaSiteware.MVC.Controllers
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

        public ActionResult Details(int id)
        {
            var produto = produtoApp.Get(id);
            return View(Mapper.Map<ProdutoViewModel>(produto));
        }

        public ActionResult Create()
        {
            ViewBag.Promocoes = SelectListHelper.ToSelectList<TipoPromocao>();
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
            ViewBag.Promocoes = SelectListHelper.ToSelectList<TipoPromocao>(produto.TipoPromocao);

            

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
