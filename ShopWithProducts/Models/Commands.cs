using ShopWithProducts.Interfaces;
using ShopWithProducts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWithProducts.Models
{
    public class Commands
    {
        private DisplayMessages _service;

        public Commands(ILogger logger)
        {
            _service = new DisplayMessages(logger);
        }

        public void Greeting()
        {
            string greeting= "Dear customer, welcome to the shop where you can stock up, buy and view products";
            _service.WriteResult(greeting);
        }

        public void CommandsList()
        {
            string commandsString = "In our shop you can: \n* Press list - see all amount of available items and find its price " +
                         "\n* Press add -  order to the shop an item if it is out of stock" +
                         "\n* Press buy - buy products" +
                         "\n* Press budjet - view the amount of money on the account" +
                         "\n* Press put - put money to your account" +
                         "\n* Press exit - leave the program" +
                         "\n* Please ender the command: " +
                         "\n\n";
            _service.WriteResult(commandsString);
        }
        public string ReadCommand()
        {
            return _service.ReadCommand();
        }

        public string ReadProductName() 
        {
            _service.WriteResult("Enter product name: ");
            return _service.ReadCommand();
        }

        public string ReadProductPrice()
        {
            _service.WriteResult("Enter product price: ");
            return _service.ReadCommand();
        }
        public string ReadProductAmount()
        {
            _service.WriteResult("Enter amount of products: ");
            return _service.ReadCommand();
        }
        public void CommandErrorMessage()
        {
            _service.WriteResult("Such command does not exists");
        }

    }
}
