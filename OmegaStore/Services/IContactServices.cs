using System.Collections.ObjectModel;
using OmegaStore.Models;

namespace OmegaStore.Services{
    public interface IContactServices{
        public Task<ICollection<Contact>> GetListRequest();
        public Task<Contact> GetRequest(int id);
        public Task ChangeContactStatus(int ContactId, RequestStatus status);
    }
}