using ScheduleListUI.ViewModels;

namespace ScheduleListUI.Views;

public partial class AddUpdateScheduleDetail : ContentPage
{
	public AddUpdateScheduleDetail(AddUpdateScheduleDetailViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}
