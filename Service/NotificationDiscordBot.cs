using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;


namespace NotificationApp.Service
{
    public class NotificationDiscordBot
    {
        DiscordSocketClient? client;

        public async Task RunBot()
        {
            var socketConfig = new DiscordSocketConfig()
            {  
                AlwaysDownloadUsers = true,
                GatewayIntents = GatewayIntents.All
                
            };
            
            client = new DiscordSocketClient(socketConfig); 
            client.MessageReceived += MessagesHandler;
            client.Log += Log;

            var token = "MTA3NDYxNjIzNjI0OTQ2OTAzOA.G-rLxV.sOCGjXrfELE7NDU9KH_VhhXvLg5_C0IkAVXq-c";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            await Task.Delay(-1);


        }

        public Task Log(LogMessage msg)
        {
            /*throw new NotImplementedException();*/
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        public Task MessagesHandler (SocketMessage msg) // Обработчик полученных сообщений
        {
            
            if (!msg.Author.IsBot)
            {  
                msg.Author.SendMessageAsync($"{msg.Author.Mention}, ваше сообщение <<{msg.Content}>> и ваш id -");
            }
            return Task.CompletedTask;
            /*throw new NotImplementedException();*/
        }

       
        
    }
}
