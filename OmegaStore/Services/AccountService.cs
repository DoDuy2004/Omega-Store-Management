using OmegaStore.Models;

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
            return _context.Accounts.FirstOrDefault(u =>
            (u.Username == username || u.Email == username) &&
            u.Password == password &&
            u.RoleId == 3);
        }

        public Account? AuthenticateAdmin(string username, string password)
        {
            return _context.Accounts.FirstOrDefault(u =>
            (u.Username == username || u.Email == username) &&
            u.Password == password &&
            u.RoleId != 3);
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
        public bool CheckFieldExists(string field, string value)
        {
            if (string.IsNullOrEmpty(field) || string.IsNullOrEmpty(value))
            {
                return false;
            }

            if (field.ToLower() == "username")
            {
                return _context.Accounts.Any(a => a.Username == value);
            }
            else if (field.ToLower() == "email")
            {
                return _context.Accounts.Any(a => a.Email == value);
            }

            return false;
        }
        public int GetAccountId(string? username)
        {
            int id = _context.Accounts.FirstOrDefault(a => a.Username == username)!.Id;

            return id;
        } 
    }

}
