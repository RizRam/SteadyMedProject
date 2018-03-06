using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagementService.Models;

namespace AccountManagementService.Data
{

    //An abstract data type to hold Account objects in memory
    //In the actual implementation, this may simply be a direct query to
    //the database.
    public class AccountCollection
    {
        //Dictionary to hold Accounts
        private Dictionary<int, Account> _collection;

        public AccountCollection()
        {
            _collection = new Dictionary<int, Account>();
            LoadCollection();
        }

        //Get a collection of all Accounts in AccountCollection
        public IEnumerable<Account> GetAll()
        {
            return _collection.Values;
        }

        //Get Account specified by id
        public Account GetAccount(int id)
        {
            return _collection.GetValueOrDefault(id);
        }

        //Get an Account speicified by the username
        public Account GetAccountByUserName(string userName)
        {
            Account result = (from a in _collection.Values
                              where a.UserName == userName
                              select a).SingleOrDefault();

            return result;
        }

        //Add an Account
        public bool AddAccount(Account account)
        {
            return _collection.TryAdd(account.AccountId, account);
        }

        //Remove an Account
        public void RemoveAccount(int id)
        {
            _collection.Remove(id);
        }

        //Pre-loads Account objects into AccountCollection for testing.
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
