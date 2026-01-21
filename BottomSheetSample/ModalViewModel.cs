using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using Plugin.Maui.BottomSheet.Navigation;

namespace BottomSheetSample;

public partial class ModalViewModel(ILogger<ModalViewModel> logger, IBottomSheetNavigationService navigationService)
{
    [RelayCommand]
    private async Task OnOpenSheet()
    {
        logger.LogDebug("Will Open Sheet");
        var navigationResult = await navigationService.NavigateToAsync(nameof(SampleSheet));
        
        if (!navigationResult.Success)
        {
            logger.LogError(navigationResult.Exception, "Failed to open sheet");
        }
        else
        {
            logger.LogDebug("Navigation to Modal: Success");
        }
    }
}