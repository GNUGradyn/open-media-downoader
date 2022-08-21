using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OpenMediaDownloader.Controls;

public partial class Search : UserControl
{
    public Search()
    {
        InitializeComponent();
    }

    public bool Loading
    {
        get { return this.FindControl<Avalonia.Svg.Skia.Svg>("LoadingSvg").IsVisible; }
        set { this.FindControl<Avalonia.Svg.Skia.Svg>("LoadingSvg").IsVisible = value; }
    }

    public string Input
    {
        get { return this.FindControl<TextBox>("TextInput").Text; }
        //get { return TextInput.Text; }

    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}