using System.Linq;
using InterviuW.Exceptions;
using InterviuW.Interfaces;
using InterviuW.Models;

namespace InterviuW.DAO
{
    /// <summary>
    /// Daca access object used to controll operations done on storage
    /// for any token
    /// </summary>
    public class TokenDao : ITokenDao
    {
        private IStorage _storage;
        public TokenDao(IStorage storage)
        {
            _storage = storage;
        }
        public int GetOrganiserId(string apiToken)
        {
            int? organiserId = _storage.GetTokens().Where(x => x.ApiToken == apiToken).FirstOrDefault()?.OrganiserId;
            if(organiserId == null)
                throw new OrganiserNotFoundException("Cannot find any organiser for the given api key");

            return (int) organiserId;
        }

        public void Insert(Token token)
        {
            _storage.GetTokens().Add(token);
        }
    }
}