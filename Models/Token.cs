using System;

namespace InterviuW.Models
{
    public class Token
    {
        public string ApiToken{get;set;}
        public DateTime ExpirationDate{get;set;}
        public int OrganiserId{get;set;}
    }
}