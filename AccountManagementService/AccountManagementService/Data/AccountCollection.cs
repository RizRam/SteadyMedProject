using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagementService.Models;

namespace AccountManagementService.Data
{
    public class AccountCollection
    {
        private Dictionary<int, Account> _collection;

        public AccountCollection()
        {
            _collection = new Dictionary<int, Account>();
            LoadCollection();
        }

        public IEnumerable<Account> GetAll()
        {
            return _collection.Values;
        }

        public Account GetAccount(int id)
        {
            return _collection.GetValueOrDefault(id);
        }

        public Account GetAccountByUserName(string userName)
        {
            Account result = (from a in _collection.Values
                              where a.UserName == userName
                              select a).SingleOrDefault();

            return result;
        }

        public bool AddAccount(Account account)
        {
            return _collection.TryAdd(account.AccountId, account);
        }

        public void RemoveAccount(int id)
        {
            _collection.Remove(id);
        }

        private void LoadCollection()
        {
            Account acc1 = new Account();
            acc1.AccountId = 1;
            acc1.UserName = "account1";
            acc1.Password = "password";
            acc1.Name = "Polly Smith";
            acc1.AccountPrivilege = Account.AccountType.patient;
            acc1.SteadyMedsOwned.Add(1);
            acc1.SteadyMedsOwned.Add(2);

            _collection.Add(acc1.AccountId, acc1);
        }

    }
}
