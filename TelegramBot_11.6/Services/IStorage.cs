using TelegramBot_11._6.Models;

namespace TelegramBot_11._6.Services
{
    public interface IStorage
    {
        Session GetSession(long ChatId);
    }
}
