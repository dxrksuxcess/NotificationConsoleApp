using Newtonsoft.Json;
using NotificationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationApp.Service
{
    public class DiscordService
    {
        public ulong GetId(string userJira)
        {
            var fileName = "D:\\Programming\\Internship at Elcomplus\\NotificationApp\\Models\\DiscordBotData.json";
            string? jsonString = File.ReadAllText(fileName);
            var data = JsonConvert.DeserializeObject<List<DiscordBotData>>(jsonString)!;

            ulong result = data.FirstOrDefault(o => o.userJira == userJira)?.userDiscord ?? 0;
            return result;
        }

        public string GetToken()
        {
            var fileName = "D:\\Programming\\Internship at Elcomplus\\NotificationApp\\Models\\DiscordConfig.json";
            string? jsonString = File.ReadAllText(fileName);
            DiscordBotData data = JsonConvert.DeserializeObject<DiscordBotData>(jsonString)!;

            string? token = data.token;

            return token;
        }
    }
}
