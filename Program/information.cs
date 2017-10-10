using Discord;

/**
 * 主に情報をまとめるクラス
 **/

/***
* App
* https://discordapp.com/developers/applications/me
* 
* Token
* "MzY1OTExMzAwMTg3ODgxNDcy.DLlM-g.JwTTcU1nc3SsEwng213SU9nrV0U"
* 
* ルーム呼び出し
* https://discordapp.com/oauth2/authorize?&client_id=365911300187881472&scope=bot&permissions=0  
***/
static class information
{
    // クライアント名
    static public DiscordClient client = new DiscordClient();
    // トークン名
    static public string token = "MzY1OTExMzAwMTg3ODgxNDcy.DLlM-g.JwTTcU1nc3SsEwng213SU9nrV0U";
    // BOT名(ユーザー名)
    static public string botUser = "とぅいんず＠てすとBOT";
}

static class function
{
    static public User commandUser = null;
    static public bool webhookFlag = false;
}
