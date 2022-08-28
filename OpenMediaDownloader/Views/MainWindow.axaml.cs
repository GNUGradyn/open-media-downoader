using System;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace OpenMediaDownloader.Views
{
    public partial class MainWindow : Window
    {
        public ICommand StartDownload;

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}