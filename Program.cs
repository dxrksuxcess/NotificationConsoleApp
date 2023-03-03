using Newtonsoft.Json;
using NotificationApp.Models;
using NotificationApp.Service;
using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using Discord;
using Discord.Net;
using Discord.WebSocket;
using System.Threading.Tasks;
using System.Text.Json.Nodes;


namespace NotificationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*var bot = new NotificationDiscordBot();
            bot.RunBot().GetAwaiter().GetResult();*/

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
            SendEmail sendEmailObject = new SendEmail();
            sendEmailObject.FuncSendEmail(subject!, body!, recipient!);

        }
    }

}