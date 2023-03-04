using Newtonsoft.Json;
using NotificationApp.Models;

namespace NotificationApp.Service
{
    public class JiraDiscordUserMapper
    {
        public ulong GetId(string userJira)
        {
            string path = Directory.GetCurrentDirectory() + "\\Models\\DiscordBotData.json";
            var fileName = path;
            string? jsonString = File.ReadAllText(fileName);
            var data = JsonConvert.DeserializeObject<List<DiscordBotData>>(jsonString)!;

            ulong result = data.FirstOrDefault(o => o.userJira == userJira)?.userDiscord ?? 0;

            return result;
        }

        public string GetToken()
        {
            string path = Directory.GetCurrentDirectory() + "\\Models\\DiscordConfig.json";
            var fileName = path;
            string? jsonString = File.ReadAllText(fileName);
            DiscordConfig data = JsonConvert.DeserializeObject<DiscordConfig>(jsonString)!;

            string? token = data.token;

            return token!;
        }
    }
}
