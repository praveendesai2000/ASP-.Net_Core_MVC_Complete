using Bulkybook.DataAccess.Repository.IRepository;
using Bulkybook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulkybook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void update(Product obj)
        {
           var objFromDb= _db.Products.FirstOrDefault(u=>u.Id==obj.Id);
            if(objFromDb!=null)
            {
                objFromDb.Title=obj.Title;
                objFromDb.ISBN=obj.ISBN;
                objFromDb.Price=obj.Price;
                objFromDb.Price50=obj.Price50;
                objFromDb.ListPrice=obj.ListPrice;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Auther = obj.Auther;
                objFromDb.CoverTypeId=obj.CoverTypeId;
                if(obj.ImageUrl!=null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }

        }
    }
}
