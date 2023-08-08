﻿using BakeryApplication.Repository;
using BakeryApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BakeryApplication.Controllers
{
	public class ShoppingCartController : Controller
	{
		private readonly IProductRepository _productRepository;
		private readonly IShoppingCart _shoppingCart;

		public ShoppingCartController(IProductRepository productRepository, IShoppingCart shoppingCart)
		{
			_productRepository = productRepository;
			_shoppingCart = shoppingCart;
		}

		public ViewResult Index()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			_shoppingCart.ShoppingCartItems = items;

			var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

			return View(shoppingCartViewModel);
		}

		public RedirectToActionResult AddToShoppingCart(int productId)
		{
			var selectedProduct = _productRepository.AllProducts.FirstOrDefault(p => p.Id == productId);

			if (selectedProduct != null)
			{
				_shoppingCart.AddToCart(selectedProduct);
			}

			return RedirectToAction("Index");
		}

		public RedirectToActionResult RemoveFromShoppingCart(int productId)
		{
			var selectedProduct = _productRepository.AllProducts.FirstOrDefault(p => p.Id == productId);

			if (selectedProduct != null)
			{
				_shoppingCart.RemoveFromCart(selectedProduct);
			}

			return RedirectToAction("Index");
		}
	}
}
