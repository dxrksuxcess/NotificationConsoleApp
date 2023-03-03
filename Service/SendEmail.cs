﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NotificationApp.Models;

namespace NotificationApp.Service
{
    sealed class SendEmail
    {
        public void FuncSendEmail(string subject, string body, string recipient)
        {
            try
            {
                
                var fileName = "D:\\Programming\\Internship at Elcomplus\\NotificationApp\\Models\\SendEmailData.json";
                string? jsonString = File.ReadAllText(fileName);
                SendEmailData dataBase = JsonConvert.DeserializeObject<SendEmailData>(jsonString)!;

                MailMessage message = new MailMessage(); // Объект сообщения(message) и его свойства
                message.IsBodyHtml = false; // Тело сообщения текст, а не Html
                message.From = new MailAddress(dataBase.SenderEmail!, dataBase.SenderName); // Данные отправителя (Почта и имя)
                message.Subject = subject; // Название темы сообщения
                message.Body = body; // Текст сообщения    
                message.To.Add(recipient); // Получение почты получателя
                
                WebProxy proxy = new WebProxy
                {
                    Address = new Uri("http://{proxyHost}:{proxyPort}"),
                    BypassProxyOnLocal = false,
                    UseDefaultCredentials = false,

                    Credentials = new NetworkCredential(
                        userName: "proxyUserName",
                        password: "proxyPassword")
                };

                HttpClientHandler httpClientHandler = new HttpClientHandler
                {
                    Proxy = proxy
                };

                

                // smtp - сервера и порт с которого будет отправлено письмо
                SmtpClient client = new SmtpClient(); //smtp - порт 587, 25, 2525 — отвечает за передачу сообщений.
                
                client.Host = dataBase.MailRuServerSmtp!;
                client.Port = dataBase.DefPortSmtp;
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
