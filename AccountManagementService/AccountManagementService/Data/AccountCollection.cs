using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagementService.Models;

namespace AccountManagementService.Data
{

    /// <summary>
    /// An abstract data type to hold Account objects in memory.
    /// Used primarily for testing purposes.  In the actual implementation,
    /// this may just be an object that handles requests to the database.
    /// </summary>
    public class AccountCollection
    {
        //Dictionary to hold Accounts
        private Dictionary<int, Account> _collection;

        /// <summary>
        /// Constructor
        /// </summary>
        public AccountCollection()
        {
            _collection = new Dictionary<int, Account>();
            LoadCollection();
        }

        /// <summary>
        /// Get a collection of all Accounts in AccountCollection
        /// </summary>
        /// <returns>A collection of all Accounts in collection</returns>
        public IEnumerable<Account> GetAll()
        {
            return _collection.Values;
        }

        /// <summary>
        /// Get Account specified by id
        /// </summary>
        /// <param name="id">ID of desired account</param>
        /// <returns>Desired account or null if it does not exist</returns>
        public Account GetAccount(int id)
        {
            return _collection.GetValueOrDefault(id);
        }

        /// <summary>
        /// Get an Account speicified by the username
        /// </summary>
        /// <param name="userName">UserName of account</param>
        /// <returns>Desired account or null if it does not exist</returns>
        public Account GetAccountByUserName(string userName)
        {
            Account result = (from a in _collection.Values
                              where a.UserName == userName
                              select a).SingleOrDefault();

            return result;
        }

        /// <summary>
        /// Add an account into the collection
        /// </summary>
        /// <param name="account">Account object to add</param>
        /// <returns>True if successful, false otherwise.</returns>
        public bool AddAccount(Account account)
        {
            return _collection.TryAdd(account.AccountId, account);
        }

        /// <summary>
        /// Remove an account from collection
        /// </summary>
        /// <param name="id">ID of account to remove</param>
        public void RemoveAccount(int id)
        {
            _collection.Remove(id);
        }

        /// <summary>
        /// Pre-loads Account objects into AccountCollection for testing purposes
        /// </summary>
        private void LoadCollection()
        {
            Account acc1 = new Account();
            acc1.AccountId = 1;
            acc1.UserName = "account1";
            acc1.Password = "password";
            acc1.Name = "Polly Smith";
            acc1.AccountPrivilege = Account.AccountType.physican;

            Account acc2 = new Account();
            acc2.AccountId = 2;
            acc2.UserName = "account2";
            acc2.Password = "password";
            acc2.Name = "Michael Jordan";
            acc2.AccountPrivilege = Account.AccountType.patient;
            acc2.SteadyMedsOwned.Add(1);

            Account acc3 = new Account();
            acc3.AccountId = 3;
            acc3.UserName = "account3";
            acc3.Password = "password";
            acc3.Name = "Mike Tyson";
            acc3.AccountPrivilege = Account.AccountType.patient;
            acc3.SteadyMedsOwned.Add(2);
            acc3.SteadyMedsOwned.Add(3);

            Account acc4 = new Account();
            acc4.AccountId = 4;
            acc4.UserName = "account4";
            acc4.Password = "password";
            acc4.Name = "Captain America";
            acc4.AccountPrivilege = Account.AccountType.patient;
            acc4.SteadyMedsOwned.Add(4);
            acc4.SteadyMedsOwned.Add(10);  //For Device testing
            

            _collection.Add(acc1.AccountId, acc1);
            _collection.Add(acc2.AccountId, acc2);
            _collection.Add(acc3.AccountId, acc3);
            _collection.Add(acc4.AccountId, acc4);
        }

    }
}
