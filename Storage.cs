using System.Collections.Generic;
using InterviuW.Models;
using InterviuW.Interfaces;

namespace InterviuW
{
    /// <summary>
    /// Keeps a storage at process level using AddSingleton from startup class
    /// </summary>
    public class Storage : IStorage
    {
        private List<EventElement> _events;
        private List<Token> _tokens;
        public List<EventElement> GetEvents() { return _events;}
        public List<Token> GetTokens(){return _tokens;}
        public Storage()
        {
            _events = new List<EventElement>();
            _tokens = new List<Token>();
        }

    }
}