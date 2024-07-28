using Core.Entities;
using Core.Interfaces;
using System.Net;
using System.Net.Mail;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace Core.Services;

public class EmailService : IEmailService
{
    private readonly IParametroRepository _parametroRepository;

    public EmailService(IParametroRepository parametroRepository)
    {
        _parametroRepository = parametroRepository;
    }

    public void SendMail(string to, string subject, string body, string name)
    {
        Parametro email = _parametroRepository.GetByNameAsync("Email").Result;
        Parametro password = _parametroRepository.GetByNameAsync("Password").Result;
        Parametro smtp = _parametroRepository.GetByNameAsync("Smtp").Result;
        Parametro puerto = _parametroRepository.GetByNameAsync("Port").Result;

        var smtpClient = new SmtpClient(smtp.ParaValor)
        {
            Port = Convert.ToInt16(puerto.ParaValor),
            Credentials = new NetworkCredential(email.ParaValor, password.ParaValor),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(email.ParaValor),
            Subject = subject,
            Body = body,
            IsBodyHtml = true,
        };

        mailMessage.To.Add(to);
        smtpClient.Send(mailMessage);
    }
}