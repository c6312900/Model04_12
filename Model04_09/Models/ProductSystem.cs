using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model04_09.DAL;
using Model04_09.ViewModels;

namespace Model04_09.Models
{
   public class ProductSystem
    {

        public ProductViewModel GetProductID(int id)
        {
            NorthwindEntities db = new NorthwindEntities();
            var query = from p in db.Products
                        where p.ProductID == id
                        select new ProductViewModel {
                            ProductID =p.ProductID,
                            ProductName =p.ProductName,
                            UnitPrice =p.UnitPrice
                        };

            var result = query.First();
            return result;
        }



        public CategoryProductsViewModel GetProductsByCategoryID(int Id)
        {
            NorthwindEntities db = new NorthwindEntities();
            var query = from p in db.Products
                        where p.CategoryID == Id
                        select new ProductViewModel
                        {
                            ProductID = p.ProductID,
                            ProductName = p.ProductName,
                            UnitPrice = p.UnitPrice
                        }; 

            CategoryProductsViewModel result = new CategoryProductsViewModel();
            result.CategoryID = Id;
            result.CategoryName = db.Categories.Find(Id).CategoryName;
            result.Products = query.ToList();


                
            return result;
        }
    }


    
}
