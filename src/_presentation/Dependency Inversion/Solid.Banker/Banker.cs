using System.Collections.Generic;
using System.Linq;

namespace Solid.Banker
{
    
    public class Banker
    {
        private readonly List<Account> _accounts;

        public Banker()
        {
            #region Persistance stuff

            var accountOne = new Account("12345");
            accountOne.Deposit(1000);

            var accountTwo = new Account("54321");
            accountTwo.Deposit(5000);

            _accounts = new List<Account>
                {
                    accountOne,
                    accountTwo
                };

            #endregion
        }

        public void Deposit(string socialSecurityNumber, decimal amount)
        {
            Account account = GetAccount(socialSecurityNumber);

            account.Deposit(amount);
        }

        public void Withdraw(string socialSecurityNumber, decimal amount)
        {
            var account = GetAccount(socialSecurityNumber);
            account.Withdraw(amount);  
        }

        private Account GetAccount(string socialSecurityNumber)
        {
            var account = _accounts.FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);

            return account;
        }
    }
}