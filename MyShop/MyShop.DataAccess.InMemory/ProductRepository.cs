using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
  public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        //--CONSTRUCTOR--//
        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();

            }
        }

        //--to  store values--//
        public void Commit()
        {
            cache["products"] = products;
        }

        //--inserting data--//
        public void Insert(Product p)
        {
            products.Add(p);
        }
        //--update list--//
        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Product not Found");
            }
        }

        //--to find a product---//
        public Product Find(string Id)
        {
            Product product = products.Find(p => p.Id == p.Id);
            if (product != null)
            {
                return  product;
            }
            else
            {
                throw new Exception("Product not Found");
            }
        }
        //--To return a list of values---//

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        //-------Delete----//
        public void Delete (string Id)
        {
            Product productToDelete = products.Find(p => p.Id == p.Id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not Found");
            }

        }
    }
}
