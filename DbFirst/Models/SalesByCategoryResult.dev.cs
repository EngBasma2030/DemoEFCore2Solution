using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirst.Models
{
    public partial class SalesByCategoryResult
    {
        public override string ToString()
        {
            return $"ProductName = {ProductName} , total = {TotalPurchase}";
        }
    }
}
