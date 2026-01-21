using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using Plugin.Maui.BottomSheet.Navigation;

namespace BottomSheetSample;

public partial class SampleSheetViewModel(
    ILogger<ModalViewModel> logger,
    IBottomSheetNavigationService navigationService)
{
    [RelayCommand]
    private async Task OnCloseSheet()
    {
        logger.LogDebug("Will Close Sheet");
        await navigationService.ClearBottomSheetStackAsync();
    }
}