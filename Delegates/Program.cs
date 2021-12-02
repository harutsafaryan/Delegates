using System;

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

            Console.ReadLine();
        }

        private static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static void ColorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }
    }
}
