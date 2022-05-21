using Telegram.Bot;
using Telegram.Bot.Types;

namespace pasha.Services.Notification;

public class TelegramNotify : INotify
{
    public void Notify(string text)
    {
        bot.SendTextMessageAsync(new ChatId(758652859), "test");
    }
    
    static ITelegramBotClient bot = new TelegramBotClient("5233946390:AAEchdgM-3tqJhb44xaLMQ3CvjOEj5JW77I");
    // public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    // {
    //     // Некоторые действия
    //     Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
    //     if(update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
    //     {
    //         var message = update.Message;
    //         if (message.Text.ToLower() == "/start")
    //         {
    //             await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать на борт, добрый путник!");
    //             return;
    //         }
    //         await botClient.SendTextMessageAsync(message.Chat, "Привет-привет!!");
    //     }
    // }
    //
    // public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    // {
    //     // Некоторые действия
    //     Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
    // }
}