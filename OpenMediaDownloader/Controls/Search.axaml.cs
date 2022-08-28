using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace OpenMediaDownloader.Controls;

public class Search : TemplatedControl
{
    public static readonly StyledProperty<string> SearchInputProperty = AvaloniaProperty.Register<Search, string>(nameof(SearchInput));
    public static readonly StyledProperty<bool> SearchLoadingProperty = AvaloniaProperty.Register<Search, bool>(nameof(SearchLoading));

    public string SearchInput
    {
        get { return GetValue(SearchInputProperty); }
        set { SetValue(SearchInputProperty, value); }
    }
    
    public bool SearchLoading
    {
        get { return GetValue(SearchLoadingProperty); }
        set { SetValue(SearchLoadingProperty, value); }
    }
}