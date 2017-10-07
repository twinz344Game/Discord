using Discord;

/***
 * データの管理などを主に行う(予定)
 ***/
class Manager
{
    public void Start()
    {
        //定義
        DiscordClient client = information.client;

        //新規に発言を受け取ったとき
        client.MessageReceived += async (s, e) =>
        {
            //自分以外
            if (!e.Message.IsAuthor)
                //受け取ったままの発言を返す
                await e.Channel.SendMessage(e.Message.Text);
        };

        //待つ
        client.ExecuteAndWait(async () => {
            //「token」と紐付けられたBOTに接続
            await client.Connect(information.token, TokenType.Bot);
        });
    }

}
