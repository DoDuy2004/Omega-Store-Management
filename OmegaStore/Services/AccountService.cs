﻿using OmegaStore.Models;

namespace OmegaStore.Services
{
    public class AccountService : IAccountService
    {
        private readonly StoreDbContext _context;

        public AccountService(StoreDbContext context)
        {
            _context = context;
        }

        public Account? Authenticate(string username, string password)
        {
            return _context.Accounts.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public bool Register(Account account)
        {
            try
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Account? GetAccountByUsername(string username)
        {
            return _context.Accounts.FirstOrDefault(u => u.Username == username);
        }

        public bool IsAccountLocked(string username)
        {
            var account = GetAccountByUsername(username);
            return account != null && account.Status == 0;
        }
    }

}