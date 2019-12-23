using System.Threading.Tasks;
using CoreMailer.Models;

namespace CoreMailer.Interfaces
{
    public interface ICoreMvcMailer
    {
        void EnableSsl();
        void Send(MailerModel mailer);
        Task SendAsync(MailerModel mailer);
    }
}
