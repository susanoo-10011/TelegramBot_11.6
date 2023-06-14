using System.Collections.Concurrent;
using TelegramBot_11._6.Models;

namespace TelegramBot_11._6.Services
{
    public class MemoryStorage : IStorage
    {
        private readonly ConcurrentDictionary<long, Session> _sessinons; 

        public MemoryStorage()
        {
            _sessinons = new ConcurrentDictionary<long, Session>();
        }

        public Session GetSession(long ChatId)
        {
            if(_sessinons.ContainsKey(ChatId))
                return _sessinons[ChatId];

            var newSession = new Session() { UserInput = ""};
            _sessinons.TryAdd(ChatId, newSession);
            return newSession;
        }
    }
}
