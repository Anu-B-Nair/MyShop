using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
   


    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productcategories;

        //--CONSTRUCTOR--//
        public ProductCategoryRepository()
        {
            productcategories = cache["productcategories"] as List<ProductCategory>;
            if (productcategories == null)
            {
                productcategories = new List<ProductCategory>();

            }
        }

        //--to  store values--//
        public void Commit()
        {
            cache["productcategories"] = productcategories;
        }

        //--inserting data--//
        public void Insert(ProductCategory p)
        {
            productcategories.Add(p);
        }
        //--update list--//
        public void Update(ProductCategory ProductCategory)
        {
            ProductCategory productCategoryToUpdate = productcategories.Find(p => p.Id == ProductCategory.Id);
            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = ProductCategory;
            }
            else
            {
                throw new Exception("ProductCategory not Found");
            }
        }

        //--to find a ProductCategory---//
        public ProductCategory Find(string Id)
        {
            ProductCategory ProductCategory = productcategories.Find(p => p.Id == p.Id);
            if (ProductCategory != null)
            {
                return ProductCategory;
            }
            else
            {
                throw new Exception("ProductCategory not Found");
            }
        }
        //--To return a list of values---//

        public IQueryable<ProductCategory> Collection()
        {
            return productcategories.AsQueryable();
        }

        //-------Delete----//
        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelete = productcategories.Find(p => p.Id == p.Id);
            if (productCategoryToDelete != null)
            {
                productcategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("ProductCategory not Found");
            }

        }
    }
}
