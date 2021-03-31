using ShopWithProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWithProducts.Services
{
    public class BudjetManager
    {
        public bool IsEnoughCredit(Customer client, int check)
        {
            if (client.MoneyOnAccoutn >= check)
            {
                return true;
            }
            return false;
        }
    }
}
