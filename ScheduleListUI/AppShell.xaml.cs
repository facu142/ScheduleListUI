using ScheduleListUI.Views;

namespace ScheduleListUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(AddUpdateScheduleDetail), typeof(AddUpdateScheduleDetail));
	}
}
