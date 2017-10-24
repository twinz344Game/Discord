using Discord;
using Discord.Net.WebSockets;

/***
 * データの管理などを主に行う(予定)
 * TODO: 0.94verに差し替え予定
 ***/
class Manager
{
    private WebSocketTest webSocketTest = new WebSocketTest();

    /// <summary>
    /// メインコード
    /// ここで主に処理を行う
    /// </summary>
    public void Main()
    {
        //定義
        DiscordClient client = information.client;

        // 機能の実装
        InfomationSet();

        // 発言の受け取り処理
        CommandCheck(client);

        // 待機
        Wait(client);
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
    private void CommandCheck(DiscordClient client)
    {
        //新規に発言を受け取ったとき
        client.MessageReceived += async (s, messageEvent) =>
        {
            // 自分以外の発言の時
            if (messageEvent.Message.IsAuthor)
                return;

            // 自分が呼ばれたか判定
            if (0 > messageEvent.Message.Text.IndexOf(information.botUser))
                return;

            // コマンドを現在受け付けていないなら
            if (function.commandUser == null)
            {
                await messageEvent.Channel.SendMessage("なんでしょうか\n" + messageEvent.Message.User.ToString() + "さん");
                function.commandUser = messageEvent.Message.User;
            }
            else
            {
                // とりあえず1人だけ情報を保存
                if (function.commandUser != messageEvent.Message.User)
                {
                    await messageEvent.Channel.SendMessage("他の人の発言ですので\n一旦終了します");
                    function.commandUser = null;
                }
                else
                {
                    // websocketの機能を使うか判定
                    webSocketTest.WebSocketOpenCheck(messageEvent);
                }
            }
        };
    }

    /// <summary>
    /// 待機中の挙動
    /// </summary>
    /// <param name="client"></param>
    private void Wait(DiscordClient client)
    {
        //待つ
        client.ExecuteAndWait(async () => {
            //「token」と紐付けられたBOTに接続
            await client.Connect(information.token, TokenType.Bot);
        });
    }
}
