using Newtonsoft.Json;
using NotificationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationApp.Service
{
    public class DiscordUserId
    {
        public ulong GetId(string userJira)
        {
            var fileName = "D:\\Programming\\Internship at Elcomplus\\NotificationApp\\Models\\DiscordBotData.json";
            string? jsonString = File.ReadAllText(fileName);
            var data = JsonConvert.DeserializeObject<List<DiscordBotData>>(jsonString)!;
            ulong u = 0;
            foreach (var item in data)
            {
                if (item.userJira == userJira)
                {
                    u = (ulong)item.userDiscord;
                    break;
                }
            }
            return u;
        }
        
    }
}
