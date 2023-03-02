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

            /*DiscordBotData firstValue = new DiscordBotData();
            firstValue.userDiscord = 11111111111111111111;
            firstValue.userJira = "first value";

            var userList = new List<DiscordBotData>();
            userList.Add(firstValue);

            var jsonObject = JsonConvert.SerializeObject(userList, Formatting.Indented);
            Console.WriteLine(jsonObject);
            File.WriteAllText("test.json", jsonObject);*/
            /*var data = new DataBase   -   Создание .json файла
            {
                SenderEmail = "testemail_elcomplus@mail.ru",
                NameSunder = "Ilya Fedin",
                PasswordOfSenderEmail = "rxvQPERfYSNe2NNFqjAv"
            };

            string jsonObject = JsonConvert.SerializeObject(data, Formatting.Indented);
            Console.WriteLine(jsonObject);
            File.WriteAllText("test.json", jsonObject);*/
            var bot = new NotificationDiscordBot();
            bot.RunBot().GetAwaiter().GetResult();

            /*var fileName = "DiscordBotData.json";
            string? jsonString = File.ReadAllText(fileName);
            var data = JsonConvert.DeserializeObject<List<DiscordBotData>>(jsonString)!;
            
            foreach (var item in data)
            {
                if (item.userJira == "SecondUser")
                {
                    Console.WriteLine("User Jira - {0}\n" +
                                      "User Discord - {1}", item.userJira, item.userDiscord);
                }
            }*/



            /*Console.WriteLine("Enter the subject of message: ");
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
            sendEmailObject.FuncSendEmail(subject!, body!, recipient!);*/





        }
    }

}