using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models.Configs
{
    public class JWTConfig
    {
        public const string Name = "JWTConfig";

        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string AccessTokenKey { get; set; }
        public string RefreshTokenKey { get; set; }
    }
}
