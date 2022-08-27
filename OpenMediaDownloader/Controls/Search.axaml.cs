using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace OpenMediaDownloader.Controls;

public class Search : TemplatedControl
{
    public static readonly StyledProperty<string> SearchInputProperty = AvaloniaProperty.Register<Search, string>(nameof(SearchInput));

    public bool Loading
    {
        get { return this.FindControl<Avalonia.Svg.Skia.Svg>("LoadingSvg").IsVisible; }
        set { this.FindControl<Avalonia.Svg.Skia.Svg>("LoadingSvg").IsVisible = value; }
    }
    
    public string SearchInput
    {
        get { return GetValue(SearchInputProperty); }
        set { SetValue(SearchInputProperty, value); }
    }
}