using CommunityToolkit.Mvvm.ComponentModel;

namespace AppStore.mvvm.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty] private bool isBusy;
    [ObservableProperty] private string title = string.Empty;
}
