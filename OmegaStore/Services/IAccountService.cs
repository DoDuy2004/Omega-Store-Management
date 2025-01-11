using OmegaStore.Models;

namespace OmegaStore.Services
{
    public interface IAccountService
    {
        Account? Authenticate(string username, string password); // Kiểm tra đăng nhập
        bool Register(Account account); // Đăng ký tài khoản mới
        Account? GetAccountByUsername(string username); // Lấy thông tin tài khoản theo Username
        bool IsAccountLocked(string username); // Kiểm tra tài khoản bị khóa
        bool CheckFieldExists(string field, string value);
    }
}
