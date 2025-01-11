using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models;
using OmegaStore.Services;


namespace OmegaStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactServices _services;
        private readonly IEmailSender _SendMailService;
        public ContactController(IContactServices service, IEmailSender SendMailService)
        {
            _services = service;
            _SendMailService = SendMailService;
        }

        public async Task<IActionResult> Index()
        {
            var requests = await _services.GetListRequest();
            return View(requests);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var contact = await _services.GetRequest(id);
            return View(contact);
        }
        public async Task<IActionResult> SendResponseEmail(string ResponseMessage, int ContactId)
        {
            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "EmailTemplate", "ResponseEmailTemplate.html");
            var htmlTemplate = await System.IO.File.ReadAllTextAsync(templatePath);
            var contact=await _services.GetRequest(ContactId);
            // Thay thế placeholder bằng dữ liệu thực tế
            string htmlMessage = htmlTemplate
                .Replace("{{CustomerName}}",contact.Fullname)
                .Replace("{{RequestDate}}", contact.CreatedAt.ToString())
                .Replace("{{RequestResponse}}", ResponseMessage);

            // Gửi email
            await _SendMailService.SendEmailAsync(contact.Email,contact.Subject,htmlMessage);
            await _services.ChangeContactStatus(contact.ContactId,RequestStatus.Pending);
            return RedirectToAction("Index");

        }
    }
}
