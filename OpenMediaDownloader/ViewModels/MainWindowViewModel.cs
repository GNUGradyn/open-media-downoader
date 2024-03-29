﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Windows.Input;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using MessageBox.Avalonia.DTO;
using Open_Media_Downloader.Services;
using OpenMediaDownloader.Views;
using ReactiveUI;

namespace OpenMediaDownloader.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool searchLoading;

        public bool SearchLoading
        {
            get => searchLoading;
            set => this.RaiseAndSetIfChanged(ref searchLoading, value);
        }

        private string searchInput;

        public string SearchInput
        {
            get => searchInput;
            set => this.RaiseAndSetIfChanged(ref searchInput, value);
        }
        
        private readonly IYoutubeDlService _youtubeDlService;

        public MainWindowViewModel()
        {
            _youtubeDlService = new YoutubeDlService();
        }
        
        public async void StartDownload()
        {
            if (string.IsNullOrEmpty(SearchInput)) return; 
            Console.WriteLine($"Attempting to download {SearchLoading}");

            // Download metadata
            SearchLoading = true;

            var video = await _youtubeDlService.GetVideoMetadata(SearchInput);

            // Handle null check
            if (video == null)
            {
                await MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams
                {
                    ContentTitle = "Error",
                    ContentMessage = "Unable to fetch metadata for the requested video. Please check the URL",
                    Icon = MessageBox.Avalonia.Enums.Icon.Error
                }).Show(); // TODO: Create a dialog service and move this to there
                SearchLoading = false;
                return;
            }

            // Download thumbnail
            Bitmap image;
            using (var client = new HttpClient())
            {
                var bytes = await client.GetByteArrayAsync(RemoveQueryParameters(video.Thumbnail));
                image = new Bitmap(new MemoryStream(bytes));
            }

            // Show download prompt
            SearchLoading = false;

            new NewDownload
            {
                DataContext = new NewDownloadViewModel
                {
                    Title = video.Title,
                    Thumbnail = image
                }
            }.Show();
        }

        private string RemoveQueryParameters(string url)
        {
            var uri = new Uri(url);
            return url.Substring(0, url.LastIndexOf(uri.Query));
        }
    }
}