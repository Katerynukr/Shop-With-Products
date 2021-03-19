using ShopWithProducts.Interfaces;
using ShopWithProducts.Loggers;
using ShopWithProducts.Models;
using System;

namespace ShopWithProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            Commands userInteraction = new Commands(logger);
            var shop = new Shop(logger);
            userInteraction.Greeting();
            while (true)
            {
                userInteraction.CommandsList();
                var userInput = userInteraction.ReadCommand().Trim().ToLower();
                if (userInput == "list")
                {
                    shop.List();
                }
                else if (userInput == "add")
                {
                    var name = userInteraction.ReadProductName();
                    var price = userInteraction.ReadProductPrice();
                    var amount = userInteraction.ReadProductAmount();
                    shop.StockUp(name, price, amount);
                }
                else if (userInput == "buy")
                {
                    var name = userInteraction.ReadProductName();
                    var price = userInteraction.ReadProductPrice();
                    var amount = userInteraction.ReadProductAmount();
                    shop.Buy(name, price, amount);
                }
                else if (userInput == "exit")
                {
                    break;
                }
                else
                {
                    userInteraction.CommandErrorMessage();
                }
            }
        }
    }
}
