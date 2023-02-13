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
            var config = new DiscordSocketConfig()
            {
                AlwaysDownloadUsers= true,
                GatewayIntents = GatewayIntents.All
            };
            
            client = new DiscordSocketClient(); 
            client.MessageReceived += CommandsHandler;
            client.Log += Log;

            var token = "MTA3NDYxNjIzNjI0OTQ2OTAzOA.G1LaB-.BEeaZhe8DsBt0QblOSso63kKvDFCVuBZ4_jVRs";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage arg)
        {
            /*throw new NotImplementedException();*/
            Console.WriteLine(arg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandsHandler(SocketMessage arg)
        {
            /*var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(client, message);

            if(message!.Author.IsBot)
            {
                return;
            }*/
            throw new NotImplementedException();
        }
        
    }
}
