namespace Core.Interfaces;

public interface IEmailService
{
    void SendMail(string to, string subject, string body, string name);
}