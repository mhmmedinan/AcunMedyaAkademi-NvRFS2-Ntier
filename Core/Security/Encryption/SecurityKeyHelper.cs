﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Security.Encryption;

public class SecurityKeyHelper
{
    //token  oluşturma sürecinde kullanılan şifreleme anahtarı
    public static SecurityKey CreateSecurityKey(string securityKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}
