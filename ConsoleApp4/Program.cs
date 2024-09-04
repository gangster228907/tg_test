using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using var cts = new CancellationTokenSource(); 
const string TOKEN = "7392487914:AAEXnS03c79EELcPdBkSLAHzqE31FzJ_1uA";
var bot = new TelegramBotClient(TOKEN, cancellationToken: cts.Token);

bot.OnMessage += OnMessage;

while (Console.ReadKey(true).Key != ConsoleKey.Escape) 
    cts.Cancel(); 

async Task OnMessage(Message msg, UpdateType type) {
    var chatId = msg.Chat.Id;


    switch (msg.ForwardOrigin)
    {
        case MessageOriginChannel m:
            await bot.SendTextMessageAsync(chatId, $"сообщение из канала с Id = {m.Chat.Id}");
            break;
        case MessageOriginChat m:
            await bot.SendTextMessageAsync(chatId, $"сообщение от чата с Id = {m.SenderChat.Id}");
            break;
        case MessageOriginUser m:
            await bot.SendTextMessageAsync(chatId, $"сообщение от юзера с Id = {m.SenderUser.Id}");
            break;
        default:
            await bot.SendTextMessageAsync(chatId, $"сообщение  с Id = {chatId}");
            break;
    }
}