/*
 * ITSE 1430
 * Mitchell Davis
 * Nile Lab 4
 */
using System;
using System.Collections.Generic;
using System.Data;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public class MemoryProductDatabase : ProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        protected override Product AddCore ( Product product )
        {
            var newProduct = CopyProduct(product);

            foreach (var comProduct in _products)
            {
                if (String.Compare(comProduct.Name, newProduct.Name, true) == 0) //Does Product already exist?
                    throw new DuplicateNameException("Duplicate Name");
            };
         
            _products.Add(newProduct);

            if (newProduct.Id <= 0)
                newProduct.Id = _nextId++;
            else if (newProduct.Id >= _nextId)
                _nextId = newProduct.Id + 1;

            return CopyProduct(newProduct);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        protected override Product GetCore(int id)
        {
            var product = FindProduct(id);

            return (product != null) ? CopyProduct(product) : null;
        }

        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        protected override IEnumerable<Product> GetAllCore ()
        {
            foreach (var product in _products)
                yield return CopyProduct(product);
        }

        /// <summary>Removes the product.</summary>
        /// <param name="product">The product to remove.</param>
        protected override void RemoveCore ( int id )
        {
            var product = FindProduct(id);
            if (product != null)
                _products.Remove(product);
        }

        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        protected override Product UpdateCore ( Product existing, Product product )
        {
            //Replace
            existing = FindProduct(product.Id);

            if (String.Compare(existing.Name, product.Name, true) == 1) // If the existing and new product are not the same
            {
                foreach (var comProduct in _products)
                {
                    if (String.Compare(comProduct.Name, product.Name, true) == 0) // And if there are no duplicates of the newProduct
                        throw new DuplicateNameException("Duplicate Name");
                };
            };

            _products.Remove(existing);

            var newProduct = CopyProduct(product);
            _products.Add(newProduct);

            return CopyProduct(newProduct);
        }
        
        private Product CopyProduct ( Product product )
        {
            var newProduct = new Product();
            newProduct.Id = product.Id;
            newProduct.Name = product.Name;
            newProduct.Description = product.Description;
            newProduct.Price = product.Price;
            newProduct.IsDiscontinued = product.IsDiscontinued;

            return newProduct;
        }

        //Find a product by ID
        private Product FindProduct ( int id )
        {
            foreach (var product in _products)
            {
                if (product.Id == id)
                    return product;
            };

            return null;
        }

        private List<Product> _products = new List<Product>();
        private int _nextId = 1;
    }
}
