using System.Threading.Tasks;
using Open_Media_Downloader.Models;

namespace Open_Media_Downloader.Services;

public interface IYoutubeDlService
{
    Task<Video> GetVideoMetadata(string url);
}