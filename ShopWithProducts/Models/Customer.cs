using ShopWithProducts.Interfaces;
using ShopWithProducts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWithProducts.Models
{
    public class Customer
    {
        public int MoneyOnAccoutn { get; set; }
        private DisplayMessages _service;
        private InputValidation _inputValidation;
        public Customer(ILogger logger)
        {
            MoneyOnAccoutn = 0;
            _service = new DisplayMessages(logger);
            _inputValidation = new InputValidation();
        }


        public void PutToBudget(string amountString)
        {
            int amount = _inputValidation.ConvertAmount(amountString);
            string budjetMsg = ""; 
            if (amount > 100 || amount <= 0)
            {
               budjetMsg += "Sorry, but we cannot increase your budget for this amount";
            }
            else
            {
                this.MoneyOnAccoutn += amount;
                budjetMsg += $"{amount} $ was added on your account. \n Currently on your acoount: {this.MoneyOnAccoutn}";
            }
            _service.WriteResult(budjetMsg);
        }

        public void PayFromBudget(int amount)
        {
            string budjetMsg = "";
            if (amount > this.MoneyOnAccoutn || amount <= 0)
            {
                budjetMsg += "Sorry, we cannot perform this operation";
            }
            else
            {
                this.MoneyOnAccoutn -= amount;
                budjetMsg += $"{amount} $ was discarded from your account. \n Currently on your acoount: {this.MoneyOnAccoutn}";
            }
            _service.WriteResult(budjetMsg);
        }
    }
}
