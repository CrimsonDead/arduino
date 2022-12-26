using dataLayer.Models;
using dataLayer.Repositories;
using System.Net;
using System.Net.Mail;

namespace backLayer
{
    public class EmailService//: IHostedService, IDisposable
    {
        private readonly ILogger<EmailService> _logger;
        //private readonly IRepository<User> _userRepository;
        private Timer? _timer = null;

        public EmailService(ILogger<EmailService> logger, IServiceScopeFactory services)
        {
            _logger = logger;
            using (var scope = services.CreateScope())
            {
                //var userRepository = scope.ServiceProvider.GetRequiredService<IRepository<User>>();
                //_userRepository = userRepository;
            }
        }

        // public Task StartAsync(CancellationToken stoppingToken)
        // {
        //     _logger.LogInformation("Service running.");

        //     _timer = new Timer(DoWork, null, TimeSpan.Zero,
        //         TimeSpan.FromSeconds(10));
        //         //TimeSpan.FromHours(1));

        //     return Task.CompletedTask;
        // }

        // private void DoWork(object? state)
        // {
        //     if (DateTime.Now.Hour != 7)
        //         return;
        //     lock (_userRepository)
        //     {
        //         SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        //         smtp.EnableSsl = true;
        //         smtp.Credentials = new NetworkCredential("somemail@gmail.com", "password");

        //         var users = _userRepository.GetItems().ToList();
        //         for (int i = 0; i < users.Count; i++)
        //         {
        //             if (i % 100 == 0)
        //                 Thread.Sleep(TimeSpan.FromSeconds(300));
        //             MailAddress from = new MailAddress("somemail@gmail.com", "Your status in database");
        //             MailAddress to = new MailAddress(users[i].Email);
        //             MailMessage m = new MailMessage(from, to);
        //             m.Subject = "Your status in database";
        //             m.Body = "You are in local db";
        //             smtp.Send(m);
        //             _logger.LogInformation($"Email Message successfuly sent to {to}");
        //         }
        //     }

        // }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
