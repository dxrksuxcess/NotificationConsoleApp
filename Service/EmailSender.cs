using System.Net.Mail;
using System.Net;
using Newtonsoft.Json;
using NotificationApp.Models;

namespace NotificationApp.Service
{
    sealed class EmailSender
    {
        private SendEmailData dataBase;

        public EmailSender()
        {
            string path = Directory.GetCurrentDirectory() + "\\Models\\SendEmailData.json";
            var fileName = path;
            string? jsonString = File.ReadAllText(fileName);
            dataBase = JsonConvert.DeserializeObject<SendEmailData>(jsonString)!;
        }

        public void SendEmail(string subject, string body, string recipient)
        {
            try
            {
                MailMessage message = new MailMessage(); // Объект сообщения(message) и его свойства
                message.IsBodyHtml = false; // Тело сообщения текст, а не Html
                message.From = new MailAddress(dataBase.SenderEmail!, dataBase.SenderName); // Данные отправителя (Почта и имя)
                message.Subject = subject; // Название темы сообщения
                message.Body = body; // Текст сообщения    
                message.To.Add(recipient); // Получение почты получателя

                // smtp - сервера и порт с которого будет отправлено письмо
                SmtpClient client = new SmtpClient(dataBase.MailRuServerSmtp, dataBase.DefPortSmtp); //smtp - порт 587, 25, 2525 — отвечает за передачу сообщений.
                client.Credentials = new NetworkCredential(dataBase.SenderEmail, dataBase.PasswordOfSenderEmail);
                client.EnableSsl = true; // Подключение протокола безопасной связи SSL
                client.Send(message); // Функция отправки сообщения
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); // Обработка исключения и вывод сообщения на консоль 
            }
        }
    }
}
