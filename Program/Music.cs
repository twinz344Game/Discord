using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Music
{ 
    public async Task JoinCanncel(IVoiceCannnel cannel = null)
    {
        cannel = cannel ?? (msg.Author as IGuildUser)?.VoiceChanncel;
        if(cannel == null) { await msg.Cannel.SendMassageAsync(""); return; }
    }

    private var audioClient = await cannel.ConnectAsync();

    private Process CreateStream(string path)
    {
        var ffmpeg = new PocessStarInfo
        {
            FileName = "ffmpeg",
            Arguments = $" -i {path} -ac 2 -f s16le -ar 48000 pipe:1",
            UseShellxecute = false,
            RedirectStandardOutput = true,
        };

        return Process.Start(ffmpeg);
    }

    private async Task SendAync(IAudioClient client, string path)
    {
        var ffmpeg = CreateStream(path);
        var output = ffmpeg.StandardOutput.BaseStream;
        var discord = client.CreatePCMStream(AudioApplication.Mixed);
        await output.CopyToAync(discord);
        await discord.FlushAsync();
    }
}