using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using OmegaStore.Models;
using OmegaStore.Services;


namespace OmegaStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactServices _ContactService;
        private readonly IEmailSender _SendMailService;
        private readonly ILogger<ContactController> _Logger;
        public ContactController(IContactServices service, IEmailSender SendMailService, ILogger<ContactController> Logger)
        {
            _ContactService = service;
            _SendMailService = SendMailService;
            _Logger = Logger;

        }

        public async Task<IActionResult> Index()
        {
            var requests = await _ContactService.GetListRequest();
            return View(requests);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var contact = await _ContactService.GetRequest(id);
            return View(contact);
        }
        public async Task<IActionResult> SendResponseEmail(string ResponseMessage, int ContactId)
        {
            if (string.IsNullOrEmpty(ResponseMessage) || ContactId <= 0)
            {
                TempData["Error"] = "Phản hồi không được để trống.";
                return RedirectToAction("Detail", new { id = ContactId });
            }

            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "EmailTemplate", "ResponseEmailTemplate.html");
            if (!System.IO.File.Exists(templatePath))
            {
                TempData["Error"] = "Không tìm thấy file template email.";
                return RedirectToAction("Detail", new { id = ContactId });
            }

            var htmlTemplate = await System.IO.File.ReadAllTextAsync(templatePath);
            var contact = await _ContactService.GetRequest(ContactId);
            if (contact == null)
            {
                TempData["Error"] = "Liên hệ không tồn tại.";
                return RedirectToAction("Index");
            }

            string htmlMessage = htmlTemplate
                .Replace("{{CustomerName}}", contact.Fullname)
                .Replace("{{RequestDate}}", contact.CreatedAt.ToString("dd/MM/yyyy"))
                .Replace("{{RequestResponse}}", ResponseMessage);

            try
            {
                await _SendMailService.SendEmailAsync(contact.Email, contact.Subject, htmlMessage);
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Failed to send email: {ex.Message}");
                TempData["Error"] = "Có lỗi xảy ra khi gửi email. Vui lòng thử lại.";
                return RedirectToAction("Detail", new { id = ContactId });
            }

            await _ContactService.ChangeContactStatus(ContactId, RequestStatus.Resolved);
            await _ContactService.AddResponseMessage(ContactId, ResponseMessage);
            TempData["success"] = "Gửi phản hồi thành công.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteContact(int id)
        {
            try
            {
                var success = await _ContactService.DeleteContactAsync(id);
                if (success)
                {
                    return Json(new { success = true, message = "Yêu cầu liên hệ đã được xóa thành công." });
                }
                else
                {
                    return Json(new { success = false, message = "Không thể xóa yêu cầu liên hệ." });
                }
            }
            catch (Exception ex)
            {
                _Logger.LogError($"Lỗi khi xóa liên hệ:{ex.Message}");
                return Json(new { success = false, message = "Đã xảy ra lỗi, vui lòng thử lại sau." });
            }
        }

    }
}
