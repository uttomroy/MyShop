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
        public string AccessTokenKey { get; set; }
        
        public int TokenExpirationInMin { get; set; }
    }
}
