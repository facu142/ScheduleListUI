using Plugin.LocalNotification;
using ScheduleListUI.Services;
using ScheduleListUI.ViewModels;
using ScheduleListUI.Views;

namespace ScheduleListUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseLocalNotification()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Services

        builder.Services.AddSingleton<IScheduleService, ScheduleService>();

        // views
        builder.Services.AddSingleton<ScheduleListView>();
        builder.Services.AddTransient<AddUpdateScheduleDetail>();

        // ViewModels
        builder.Services.AddSingleton<ScheduleListViewModel>();
        builder.Services.AddTransient<AddUpdateScheduleDetailViewModel>();

        return builder.Build();
    }
}
