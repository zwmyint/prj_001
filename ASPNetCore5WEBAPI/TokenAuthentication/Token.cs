using System;

namespace ASPNetCore5WEBAPI.TokenAuthentication
{
    public class Token
    {

        public string Value { get; set; }
        public DateTime ExpiryDate { get; set; }

    }
}