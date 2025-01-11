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

        public async Task<ICollection<Contact>>GetListRequest(){
            return await _context.Contacts.ToListAsync();
        }
        public async Task ChangeContactStatus(int ContactId, RequestStatus status){
            var contact=_context.Contacts.Find(ContactId);
            if(contact!=null){
                contact.Status = status;
            }
            else{
                _logger.LogWarning($"Không tìm thấy yêu cầu với ContactId = {ContactId}");
            }
            await _context.SaveChangesAsync();
        }
    }
}