using dataLayer.Models;
using dataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Net.Mail;

namespace backLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly ILogger<User> _logger;
        private readonly IRepository<SensorData> _sensorDataRepository;
        private readonly UserRepository _userRepository;

        public EmailController(
            ILogger<User> logger, 
            IRepository<User> userRepository, 
            IRepository<SensorData> sensorDataRepository)
        {
            _logger = logger;
            _sensorDataRepository = sensorDataRepository;
            _userRepository = (UserRepository)userRepository;
        }

        [HttpGet(Name = "Send")]
        [Route("Send")]
        public async Task<ActionResult> Send()
        {
            try
            {
                //lock (_userRepository)
                //{
                    SmtpClient smtp = new SmtpClient("smtp.sendgrid.net", 587);
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = new NetworkCredential("apikey", "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");

                    var claims = this.HttpContext.User.Identities.ToList()[0].Claims.ToList();
                    User user = _userRepository.GetByUserCredentials(claims[0].Value, claims[1].Value);

                    MailAddress from = new MailAddress("kir120056@gmail.com", "Last temperature data");
                    MailAddress to = new MailAddress(user.Email);
                    MailMessage m = new MailMessage(from, to);
                    m.Subject = "Last temperature data";
                    m.Body = "Last temperature data: ";
                    foreach (var items in _sensorDataRepository.GetItems())
                    {
                        m.Body += items.ToString() + ", ";
                    }
                    smtp.Send(m);
                    _logger.LogInformation($"Email Message successfuly sent to {to}");

                    return Ok();
                //}
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}