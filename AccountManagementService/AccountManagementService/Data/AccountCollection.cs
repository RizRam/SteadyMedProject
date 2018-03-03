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

        public Account GetAccount(int id)
        {
            return _collection.GetValueOrDefault(id);
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

        }

    }
}
