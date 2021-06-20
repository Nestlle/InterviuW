using InterviuW.Models;

namespace InterviuW.Interfaces
{
    public interface ITokenDao
    {
        void Insert(Token token);
        int GetOrganiserId(string apiToken);
    }
}