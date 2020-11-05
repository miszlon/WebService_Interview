using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Junior_1._2.Settings
{
    public class JwtSettings
    {
        public string ValidIssuer { get; set; } = "https://localhost:44364";
        public string ValidAudience { get; set; } = "https://localhost:44364";
        public string Secret { get; set; } = "1e822158-1e3f-11eb-adc1-0242ac120002";
        public int LifetimeInSeconds { get; set; } = 3600;
    }
}
