using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulkybook.Models.ViewModels
{
    public class ShoppingCartVM
    {
       public IEnumerable<ShoppingCart> ListCart { get; set; }
     
        public OrderHeader OrderHeader { get; set; }
    }
}
