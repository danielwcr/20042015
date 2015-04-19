using AutoMapper;
using ProvaSiteware.Application.Interfaces;
using ProvaSiteware.Domain.Entities;
using ProvaSiteware.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaSiteware.MVC.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ICarrinhoAppService carrinhoApp;

        public CarrinhoController(ICarrinhoAppService carrinhoApp)
        {
            this.carrinhoApp = carrinhoApp;
        }

        private CarrinhoViewModel Carrinho
        {
            get { return HttpContext.Session["Carrinho"] == null ? new CarrinhoViewModel() { ItensCarrinho = new List<ItemCarrinhoViewModel>() } : (CarrinhoViewModel)HttpContext.Session["Carrinho"]; }
            set { HttpContext.Session["Carrinho"] = value; }
        }

        private void AtualizarSessao(Carrinho carrinho)
        {
            Carrinho = Mapper.Map<CarrinhoViewModel>(carrinho);
        }

        public ActionResult Index()
        {
            return View(Carrinho.ItensCarrinho);
        }

        [HttpPost]
        public ActionResult Refresh(IEnumerable<ItemCarrinhoViewModel> itensCarrinho)
        {
            var carrinhoEmSessao = Carrinho;

            foreach (var item in carrinhoEmSessao.ItensCarrinho)
            {
                var itemRefresh = itensCarrinho.FirstOrDefault(p => p.CodigoProduto == item.CodigoProduto);
                if (itemRefresh != null)
                    item.Quantidade = itemRefresh.Quantidade;
            }

            var carrinho = carrinhoApp.AtualizarItensCarrinho(Mapper.Map<Carrinho>(carrinhoEmSessao));
            AtualizarSessao(carrinho);

            return RedirectToAction("Index");
        }

        public ActionResult Add(int codigoProduto)
        {
            var carrinho = carrinhoApp.AdicionarItemCarrinho(Mapper.Map<Carrinho>(Carrinho), codigoProduto);
            AtualizarSessao(carrinho);

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int codigoProduto)
        {
            var carrinho = carrinhoApp.RemoverItemCarrinho(Mapper.Map<Carrinho>(Carrinho), codigoProduto);
            AtualizarSessao(carrinho);

            return RedirectToAction("Index");
        }
    }
}
