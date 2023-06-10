using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot_11._6.Services;

namespace TelegramBot_11._6.Controllers
{
    internal class InlineKeyboardController
    {
        private readonly IStorage _memoryStorage;
        private readonly ITelegramBotClient _telegramBotClient;

        public InlineKeyboardController(ITelegramBotClient telegramBotClient, IStorage storage)
        {
            _memoryStorage = storage;
            _telegramBotClient = telegramBotClient;
        }

        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if (callbackQuery?.Data == null)
                return;

            _memoryStorage.GetSession(callbackQuery.From.Id).UserInput = callbackQuery.Data;

            string userChoicse = callbackQuery.Data switch
            {
                "sum" => "Сумма чисел",
                "symbol" => "Количество символов",
                _ => string.Empty,
            };

            await _telegramBotClient.SendTextMessageAsync(callbackQuery.From.Id, $"<b>Вы выбрали функцию - {userChoicse}.{Environment.NewLine}</b>" +
                $"{Environment.NewLine}Можно поменять в главном меню.", cancellationToken: ct, parseMode: ParseMode.Html);
        }
    }
}
