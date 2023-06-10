using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot_11._6.Services;
using TelegramBot_11._6.Utilities;

namespace TelegramBot_11._6.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IStorage _memoryStorage;


        public TextMessageController(ITelegramBotClient TelegramBotClient, IStorage memoryStorage)
        {
            _telegramBotClient = TelegramBotClient;
            _memoryStorage = memoryStorage;
        }

        public async Task Handle(Message message, CancellationToken cancellationToken)
        {
            switch (message.Text)
            {
                case "/start":
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($"Сумма чисел", "sum"),
                        InlineKeyboardButton.WithCallbackData($"Количество символов", "symbol")
                    });

                    await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"<b>  Вы можете посчитать сумму чисел или количество символов в словах</b> {Environment.NewLine}",
                        cancellationToken: cancellationToken, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));
                    break;
            }

            string userInput = _memoryStorage.GetSession(message.Chat.Id).UserInput;
            if (userInput == "sum")
            {
                string sumNumbers = SumNumbers.Sum(message.Text);
                await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"Сумма чисел равна - {sumNumbers}", cancellationToken: cancellationToken);
            }
            else if(userInput == "symbol")
            {
                int symbols = NumberCharacters.СountСharacters(message.Text);
                await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"Количество символов в тексте равно - {symbols}", cancellationToken: cancellationToken);
            }
        }



    }
}
