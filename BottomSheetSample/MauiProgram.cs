using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MPowerKit.Navigation;
using MPowerKit.Navigation.Interfaces;
using MPowerKit.Navigation.Utilities;
using Plugin.Maui.BottomSheet.Hosting;
using Plugin.Maui.BottomSheet.Navigation;

namespace BottomSheetSample;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseBottomSheet()
            .UseMPowerKitNavigation(mvvmBuilder =>
            {
                mvvmBuilder
                    .ConfigureServices(services =>
                    {
                        services.RegisterForNavigation<MainPage, MainViewModel>(nameof(MainPage));
                        services.RegisterForNavigation<ModalPage, ModalViewModel>(nameof(ModalPage));
                        services.AddBottomSheet<SampleSheet, SampleSheetViewModel>(nameof(SampleSheet));
                    })
                    .UsePageEventsInRegions()
                    .OnAppStart(async (_, service) =>
                    {
                        await service.NavigateAsync($"/NavigationPage/{nameof(MainPage)}");
                    });
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.SetMinimumLevel(LogLevel.Debug);
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}