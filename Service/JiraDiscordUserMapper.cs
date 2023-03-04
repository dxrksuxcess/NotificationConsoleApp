using Newtonsoft.Json;
using NotificationApp.Models;

namespace NotificationApp.Service
{
    public class JiraDiscordUserMapper
    {

        public ulong GetId(string userJira)
        {
            string path = Directory.GetCurrentDirectory() + "\\DiscordBotData.json";
            var fileName = path;
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
