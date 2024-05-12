using System.Collections.Generic;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly Dictionary<string, Account> _accounts = new();

        public Account GetAccount(string id)
        {
            return _accounts.TryGetValue(id, out var account) ? account : null;
        }

        public void PutAccount(Account account)
        {
            _accounts.Add(account.Id, account);
        }

        public void ResetRecords()
        {
            _accounts.Clear();
        }
    }
}