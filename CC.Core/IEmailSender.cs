
namespace CC.Core
{
    public interface IEmailSender
    {
        void Send<TModel>(string templatePath, TModel model) where TModel : EmailModel;
        void SendMail<TModel>(TModel scheduledMail) where TModel : EmailModel;
        string GenerateMailContent(string templatePath, EmailModel model);
    }
}
