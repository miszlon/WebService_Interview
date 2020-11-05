using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeBlog.Api.Settings
{
    public class JwtSettings
    {
        public string ValidIssuer { get; set; } = "https://localhost:44399";
        public string ValidAudience { get; set; } = "https://localhost:44399";
        public string Secret { get; set; } = "1e822158-1e3f-11eb-adc1-0242ac120002";
        public int LifetimeInSeconds { get; set; } = 3600;
    }
}
