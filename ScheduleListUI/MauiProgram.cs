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
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        // Services

        // views
        builder.Services.AddSingleton<ScheduleListView>();

        // ViewModels
        builder.Services.AddSingleton<ScheduleListViewModel>();
			
			
		return builder.Build();
	}
}
