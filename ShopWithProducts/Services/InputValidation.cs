using ShopWithProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWithProducts.Services
{
    public class InputValidation
    {
        public int ConvertAmount(string inputString)
        {
            try
            {
                int input = Convert.ToInt32(inputString);
                return input;
            }
            catch
            {
                throw new FormatException();
            }
        }

        public int ConvertPrice(string inputString)
        {
            try
            {
                int input = Convert.ToInt32(inputString);
                return input;
            }
            catch
            {
                throw new FormatException();
            }
        }

        public bool IsPossibleToBuy(List<Products> allProduts, string name, int price, int amount)
        {
            bool isPossibleToBuy = false;
            List<Products> filteredProducts = new List<Products>();
            foreach (var product in allProduts)
            {
                if (product.ProductName == name && product.Price == price)
                {
                    filteredProducts.Add(product);
                }
            }
            if (filteredProducts.Count == amount)
            {
                isPossibleToBuy = true;
            }
            return isPossibleToBuy;
        }
    }
}
