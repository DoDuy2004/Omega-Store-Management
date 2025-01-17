using OmegaStore.Models;
using OmegaStore.Models.Momo;
using OmegaStore.Models.ViewModels;

namespace OmegaStore.Services.Momo
{
    public interface IMomoService
    {
        Task<MomoCreatePaymentResponseModel> CreatePaymentMomo(CheckoutViewModel checkout);
        MomoExcuteResponseModel PaymentExcuteAsync(IQueryCollection collection);
    }
}
