using System;
using System.Collections.Generic;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(200);
            Account.AccountStateHandler colorDelegate = new Account.AccountStateHandler(ColorMessage);

            account.RegisterHndler(new Account.AccountStateHandler(ShowMessage));
            account.RegisterHndler(colorDelegate);

            account.Withdraw(110);
            account.Withdraw(100);

            account.UnregisterHandler(colorDelegate);
            account.Withdraw(50);


            Console.WriteLine("\n\n\nStock operations");

            List<Item> list = new List<Item>()
            {
                new Item(521, "pen", 20),
                new Item(220, "book", 30),
                new Item(300, "notebook", 40)
            };
            
            Stock stock = new Stock(list);
            Stock.StockOpertation QuantityMessage = new Stock.StockOpertation(ColorMessage);
            stock.RegisterHandler(QuantityMessage);
            
            stock.AddQty(521, 100);
            stock.TakOfQty(220, 28);
            
            stock.UnregisterHandler(QuantityMessage);

            stock.AddQty(300, 80);
        }

        private static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static void ColorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
