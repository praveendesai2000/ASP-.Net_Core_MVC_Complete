using Bulkybook.DataAccess.Repository.IRepository;
using Bulkybook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulkybook.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDbContext _db;

        public OrderDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

      

        public void update(OrderDetail obj)
        {
            _db.OrderDetails.Update(obj);
        }
    }
}
