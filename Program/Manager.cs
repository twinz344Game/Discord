using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

/***
 * データの管理などを主に行う(予定)
 ***/
class Manager
{
    private WebSocketTest webSocketTest = new WebSocketTest();
    private DiscordSocketClient client;
    /// <summary>
    /// メインコード
    /// ここで主に処理を行う
    /// </summary>
    public async Task Main()
    {
        //定義
        client = information.client;

        // ログイン処理
        await client.LoginAsync(TokenType.Bot, information.token);
        await client.StartAsync();

        // 機能の実装
        InfomationSet();

        // 発言の受け取り処理
        client.MessageReceived += CommandCheck;

        // 待機
        Wait();

        await Task.Delay(-1);
    }

    /// <summary>
    /// 使う機能をここにまとめておく
    /// </summary>
    private void InfomationSet()
    {
        // WebSoket(使い方ワカンネ 今後に期待)
        if (function.webhookFlag) webSocketTest.Main();
    }

    /// <summary>
    /// 発言を受け取った時の挙動
    /// </summary>
    /// <param name="client"></param>
    private async Task CommandCheck(SocketMessage message)
    {
        // 自分以外の発言の時
        if (message.Author == client.CurrentUser)
            return;

        // 自分が呼ばれたか判定
        if (0 > message.Content.IndexOf(information.botUser) &&
            function.commandUser != message.Author)
            return;

        // コマンドを現在受け付けていないなら
        if (function.commandUser == null)
        {
            await message.Channel.SendMessageAsync("なんでしょうか\n" + message.Author.ToString() + "さん");
            function.commandUser = message.Author;
        }
        else
        {
            // とりあえず1人だけ情報を保存
            if (function.commandUser != message.Author)
            {
                await message.Channel.SendMessageAsync("他の人の発言ですので\n一旦終了します");
                function.commandUser = null;
            }
            else
            {
                // websocketの機能を使うか判定
                webSocketTest.WebSocketOpenCheck(message);
            }
        }
    }

    /// <summary>
    /// 待機中の挙動
    /// </summary>
    /// <param name="client"></param>
    private void Wait()
    {
        //待つ
        client.Ready += () => {
            //「token」と紐付けられたBOTに接続
            return Task.CompletedTask;
        };
    }
}
