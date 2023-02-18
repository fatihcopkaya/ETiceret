using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace CoreLayer.Utilities.Security.Encyption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string security)
		{
			return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(security));
		}
    }
}