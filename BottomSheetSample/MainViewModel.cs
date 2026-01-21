using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using MPowerKit.Navigation.Interfaces;

namespace BottomSheetSample;

public partial class MainViewModel(ILogger<MainViewModel> logger, INavigationService navigationService)
{
    [RelayCommand]
    private async Task OnOpenModal()
    {
        var navigationResult = await navigationService.NavigateAsync(nameof(ModalPage), modal: true);
        
        if (!navigationResult.Success)
        {
            logger.LogError(navigationResult.Exception, "Failed to open modal page");
        }
        else
        {
            logger.LogDebug("Navigation to Modal: Success");
        }
    }
}