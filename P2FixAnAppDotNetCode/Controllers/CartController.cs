using System.Linq;
using Microsoft.AspNetCore.Mvc;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Services;

namespace P2FixAnAppDotNetCode.Controllers
{
    public class CartController : Controller
    {
        private readonly ICart _cart;
        private readonly IProductService _productService;

        public CartController(ICart pCart, IProductService productService)
        {
            _cart = pCart;
            _productService = productService;
        }

        public ViewResult Index()
        {
            return View(_cart as Cart);
        }

        [HttpPost]
        public RedirectToActionResult AddToCart(int id)
        {
            // Validation de l'ID
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "ID de produit invalide";
                return RedirectToAction("Index", "Product");
            }

            Product product = _productService.GetProductById(id);

            if (product != null)
            {
                // Vérification du stock disponible avant d'ajouter au panier
                if (product.Stock > 0)
                {
                    _cart.AddItem(product, 1);
                    TempData["SuccessMessage"] = $"{product.Name} ajouté au panier";
                }
                else
                {
                    TempData["ErrorMessage"] = "Ce produit n'est plus en stock";
                }
                // Redirection vers la page des produits au lieu du panier
                return RedirectToAction("Index", "Product");
            }
            else
            {
                TempData["ErrorMessage"] = "Produit introuvable";
                return RedirectToAction("Index", "Product");
            }
        }

        public RedirectToActionResult RemoveFromCart(int id)
        {
            Product product = _productService.GetAllProducts()
                .FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                _cart.RemoveLine(product);
            }
            return RedirectToAction("Index");
        }
    }
}
