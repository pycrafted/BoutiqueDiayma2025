using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        
        public IEnumerable<CartLine> Lines => _lignesPanier;
        private List<CartLine> _lignesPanier = new List<CartLine>();

        /// <summary>
        /// Get the list of cart lines
        /// </summary>
        private List<CartLine> GetCartLineList()
        {
            return _lignesPanier;
        }
        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>
        public void AddItem(Product product, int quantity)
        {
            // Recherche du produit dans le panier avec LINQ pour améliorer la lisibilité
            var cartLine = _lignesPanier.FirstOrDefault(line => line.Product.Id == product.Id);

            // Si le produit est déjà dans le panier, augmentez la quantité
            if (cartLine != null)
            {
                cartLine.Quantity += quantity;
            }
            // Sinon, ajoutez un nouvel élément CartLine au panier
            else
            {
                _lignesPanier.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // Calcul du total en multipliant le prix par la quantité pour chaque produit
            return GetCartLineList().Sum(x => x.Product.Price * x.Quantity);
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // Calcul de la moyenne pondérée en tenant compte des quantités (total / nombre total d'items)
            var cartLines = GetCartLineList();
            if (cartLines.Count > 0)
            {
                double total = cartLines.Sum(x => x.Product.Price * x.Quantity);
                int totalItems = cartLines.Sum(x => x.Quantity);
                return totalItems > 0 ? total / totalItems : 0.0;
            }
            else
                return 0.0;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // Recherche du produit avec gestion null-safe pour éviter NullReferenceException
            var cartLine = GetCartLineList().FirstOrDefault(x => x.Product.Id == productId);
            return cartLine?.Product;
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            // Amélioration : vérification de l'index pour éviter IndexOutOfRangeException
            var cartLines = Lines.ToArray();
            if (index < 0 || index >= cartLines.Length)
                return null;
            
            return cartLines[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
