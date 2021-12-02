using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Account
    {
        private int _sum;
        public delegate void AccountStateHandler(string message);
        AccountStateHandler _del;

        public void RegisterHndler(AccountStateHandler del)
        {
            _del += del;
        }

        public void UnregisterHandler(AccountStateHandler del)
        {
            _del -= del;
        }

        public Account(int sum)
        {
            _sum = sum;
        }
        public int CurrentSum { get { return _sum; } }
        public void Put(int sum) 
        {
            _sum += sum; 
        }
        public void Withdraw(int sum)
        {
            if (sum < _sum)
            {
                _sum -= sum;
                if (_del != null)
                    _del($"The amount {sum} has been withdraw from account ");
            }
            else
            {
                if (_del != null)
                    _del($"There are not enough money");
            }
        }
    }
}
