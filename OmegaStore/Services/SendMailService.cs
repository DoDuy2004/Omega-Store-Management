using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;

namespace OmegaStore.Services
{
    public class SendMailService : IEmailSender
    {
        private readonly MailSettings _settings;
        private readonly ILogger<SendMailService> _logger;
        public SendMailService(IOptions<MailSettings> mailSettings, ILogger<SendMailService> logger)
        {
            _settings = mailSettings.Value;
            _logger = logger;
            logger.LogInformation("Creat SendMailService");
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mail = new MimeMessage();
            mail.Sender = new MailboxAddress(_settings.DisplayName, _settings.Mail);
            mail.From.Add(new MailboxAddress(_settings.DisplayName, _settings.Mail));
            mail.To.Add(new MailboxAddress(email, email));
            mail.Subject = subject;
            var bodyBuilder = new BodyBuilder()
            {
                HtmlBody = htmlMessage
            };
            mail.Body = bodyBuilder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);//Mở kết nối
                await smtp.AuthenticateAsync(_settings.Mail, _settings.Password);//Xác thực
                await smtp.SendAsync(mail);//Gửi mail
            }
            catch (Exception ex)
            {
                try
                {
                    var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "mailssave");
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave

                    var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                    await mail.WriteToAsync(emailsavefile);

                    _logger.LogInformation("Lỗi gửi mail, lưu tại - " + emailsavefile);
                    _logger.LogError($"Lỗi:{ex.Message}");
                }
                catch (Exception directoryEx)
                {
                    _logger.LogError($"Không thể tạo thư mục lưu email: {directoryEx.Message}");
                }
            }
            
            finally
            {
                
                if (smtp.IsConnected)
                {
                    await smtp.DisconnectAsync(true);
                }
                smtp.Dispose();
                _logger.LogInformation("Đã giải phóng tài nguyên SMTP.");
            }
        }
    }
}