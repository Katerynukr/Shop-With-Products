using ShopWithProducts.Interfaces;
using ShopWithProducts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWithProducts.Models
{
    public class Shop
    {
        public List<Products> ProductsList { get; set; }
        private DisplayMessages _service;
        private InputValidation _inputValidation;
        public Shop(ILogger logger)
        {
            ProductsList = new List<Products>();
            _service = new DisplayMessages(logger);
            _inputValidation = new InputValidation();
        }

        public void StockUp(string nameString, string priceString, string amountString)
        {
            string name = nameString.Trim().ToLower();
            int price = _inputValidation.ConvertPrice(priceString);
            int amount = _inputValidation.ConvertAmount(amountString);
            string stockUpMsg = "";
            for (int i = 0; i < amount; i++)
            {
                ProductsList.Add(new Products()
                {
                    ProductName = name,
                    Price = price

                });
            }
            if (amount == 1)
            {
                stockUpMsg += $"{amount} {name} was added to the shop with the price of {price} $";
            }
            else
            {
                stockUpMsg += $"{amount} {name} products ware added to the shop with the price of {price} $";
            }
            _service.WriteResult(stockUpMsg);
        }

        public void Buy(string nameString, string priceString, string amountString, Customer client)
        {
            string name = nameString.Trim().ToLower();
            int price = _inputValidation.ConvertPrice(priceString);
            int amount = _inputValidation.ConvertAmount(amountString);
            int check = amount * price;
            string buyMsg = "";
            bool isPossibleToBuy = _inputValidation.IsPossibleToBuy(ProductsList, name, price, amount);
            bool isEnoughCredit = this.IsEnoughCredit(client, check);
            if (isPossibleToBuy && isEnoughCredit)
            {
                for (int i = 0; i < amount; i++)
                {
                    var prodcutToRemove = ProductsList.FirstOrDefault(p => p.ProductName == name && p.Price == price);
                    ProductsList.Remove(prodcutToRemove);
                }
                if (amount == 1)
                {
                    buyMsg += $"{amount} {name} that costs {price} was bought from the shop";
                }
                else
                {
                    buyMsg += $"{amount} {name} that cost {price} were bought from the shop";
                }
                client.PayFromBudget(check);
            } 
            else
            {
                buyMsg += "You can't buy it. Try again!";
            }
            _service.WriteResult(buyMsg);
        }

        public void List()
        {
            string listMsg = "";
            if (ProductsList.Count > 0)
            {
                ProductsList.ForEach(p => listMsg += $"You can buy {p.ProductName} for {p.Price} $ \n");
            }
            else 
            {
                listMsg += "Currently there are no products at the shop";
            }
            
            _service.WriteResult(listMsg);
        }

       private bool IsEnoughCredit(Customer client, int check)
        {
            if(client.MoneyOnAccoutn >= check) 
            {
                return true;
            }
            return false;
        }
    }
}
