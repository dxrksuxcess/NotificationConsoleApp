using Newtonsoft.Json;
using NotificationApp.Models;
using NotificationApp.Service;
using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace NotificationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*var data = new DataBase   -   Создание .json файла
            {
                SenderEmail = "testemail_elcomplus@mail.ru",
                NameSunder = "Ilya Fedin",
                PasswordOfSenderEmail = "rxvQPERfYSNe2NNFqjAv"
            };

            string jsonObject = JsonConvert.SerializeObject(data, Formatting.Indented);
            Console.WriteLine(jsonObject);
            File.WriteAllText("test.json", jsonObject);*/


            Console.WriteLine("Enter the subject of message: ");
            string? subject = Console.ReadLine();

            Console.WriteLine("Enter the text of message: ");
            string? body = Console.ReadLine();

            Console.WriteLine("Enter the recipient's email name");
            string? recipient;
            //Проверка на пустое значение почты получателя
            do
            {
                recipient = Console.ReadLine();
                if (string.IsNullOrEmpty(recipient))
                {
                    Console.Write("Recipient's email name = null\n");
                }
            } while (string.IsNullOrEmpty(recipient));

            // Отправка сообщения на почту
            SendEmail.FuncSendEmail(subject!, body!, recipient!);

       /* => new Program().MainAsync().GetAwaiter().GetResult();*/
        }
    }

}