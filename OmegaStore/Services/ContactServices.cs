using OmegaStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
namespace OmegaStore.Services
{
    public class ContactService : IContactServices
    {
        private readonly StoreDbContext _context;
        private readonly ILogger<ContactService> _logger;
        public ContactService(StoreDbContext context, ILogger<ContactService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Contact?> GetRequest(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(request => request.ContactId == id);
        }

        public async Task<ICollection<Contact>> GetListRequest()
        {
            return await _context.Contacts.ToListAsync();
        }
        public async Task ChangeContactStatus(int ContactId, RequestStatus status)
        {
            var contact = _context.Contacts.Find(ContactId);
            if (contact != null)
            {
                contact.Status = status;
            }
            else
            {
                _logger.LogWarning($"Không tìm thấy yêu cầu với ContactId = {ContactId}");
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Boolean> AddResponseMessage(int ContactID, string ResponseMessage)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(ct => ct.ContactId == ContactID);
            if (contact != null)
            {
                if (ResponseMessage != null)
                {
                    contact.ResponseMessage = ResponseMessage;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else {
                    _logger.LogError("ResponseMessage null!");
                    return false;
                }
            }
            else{
                _logger.LogError("ContactID not exits");
                return false;
            }

        }

        public async Task<Boolean> DeleteContactAsync(int contactId)
        {
            if (contactId <= 0)
            {
                _logger.LogWarning($"ContactId không hợp lệ: {contactId}");
                return false;
            }

            try
            {
                var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.ContactId == contactId);
                if (contact != null)
                {
                    _context.Contacts.Remove(contact);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Đã xóa contact với ContactId = {contactId}");
                    return true;
                }
                else
                {
                    _logger.LogWarning($"Không tìm thấy contact với ContactId = {contactId}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi xóa contact với ContactId = {contactId}");
                throw;
            }
        }

    }
}