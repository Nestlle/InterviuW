using System.Collections.Generic;
using InterviuW.Models;

namespace InterviuW.Interfaces
{
    public interface IStorage
    {
        List<EventElement> GetEvents();
        List<Token> GetTokens();
    }
}