using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Open_Media_Downloader.Models;

namespace Open_Media_Downloader.Services;

public class YoutubeDlService : IYoutubeDlService
{
    public async Task<Video> GetVideoMetadata(string url)
    {
        var proc = new Process 
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "External/yt-dlp.exe",
                Arguments = $"-j {url}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            }
        };
        
        // Log standard output
        string output = "";
        proc.OutputDataReceived += (sender, outline) =>
        {
            output += outline.Data;
        };
        
        proc.Start();
        proc.BeginOutputReadLine(); // WaitForExit will hang forever without this
        await proc.WaitForExitAsync();
        return JsonConvert.DeserializeObject<Video>(output);
    }
}