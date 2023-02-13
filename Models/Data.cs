using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NotificationApp.Models
{
    public class DataBase
    {
        public string? SenderEmail { get; set; }
        public string? SenderName { get; set; }
        public string? PasswordOfSenderEmail { get; set; }
        public string? MailRuServerSmtp { get; set; }
        public int DefPortSmtp { get; set; }
        public int ReservePortSmtp { get; set; }

    }
}
