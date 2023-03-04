using Discord;
using Discord.WebSocket;

namespace NotificationApp.Service
{
    sealed class NotificationDiscordBot
    {
        DiscordSocketClient? client;
        JiraDiscordUserMapper service = new JiraDiscordUserMapper();
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
            var token = service.GetToken();

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            string? message = "Сообщение об ошибке";
            string? userJira = "Ilya Fedin";

            await SendMessageAsync(message, userJira);

            await Task.Delay(-1);
        }

        public Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        public async Task<Task> SendMessageAsync(string message, string userJira)
        {
            Console.ReadLine();
            ulong u = service.GetId(userJira);
            IUser? user = client?.GetUserAsync(u).Result;
            await UserExtensions.SendMessageAsync(user, message);
            return Task.CompletedTask;
        }

        public async Task<Task> MessagesHandler(SocketMessage msg) // Обработчик полученных сообщений
        {
            ulong channelID = msg.Channel.Id; // ID чата на сервере дискорд, где было отправлено сообщение
            ulong u = msg.Author.Id; // ID автора сообщения
            if ((!msg.Author.IsBot) && (channelID != 1075691854818983986)) // Условие чтобы бот не выполнял команды в личном чате
            {
                string? message = "";
                string userName = msg.Author.Username; // Имя автора сообщения
                Console.WriteLine($"В чат дискорда было отправлено сообщение от <{userName}>" + $"  |   id <{userName}> - <{u}>");
                /*message = Console.ReadLine(); - Ввод текста сообщения через консоль*/

                IUser? user = client?.GetUserAsync(u).Result; // Получение логина пользователя по его ID

                message = $"Имя пользователя {userName}\n" + // Тело сообщения
                          $"ID пользователя - {u}\n" +
                          $"ID чата сервера - {channelID}\n" +
                          $"Отправленное сообщение: {msg.Content}\n" +
                          $"Логин пользователя: {user}";
                await UserExtensions.SendMessageAsync(user, message); // Отправка сообщения пользователю
                return Task.CompletedTask;
                /*msg.Author.SendMessageAsync($"{msg.Author.Mention}, ваше сообщение <<{msg.Content}>> и ваш id -");*/
            }
            return Task.CompletedTask;
        }
    }
}
