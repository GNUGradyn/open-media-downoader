using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OpenMediaDownloader.Views;

public partial class NewDownload : Window
{
    public NewDownload()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}