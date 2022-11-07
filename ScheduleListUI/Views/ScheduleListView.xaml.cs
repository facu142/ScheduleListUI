using ScheduleListUI.ViewModels;

namespace ScheduleListUI.Views;

public partial class ScheduleListView : ContentPage
{
	private ScheduleListViewModel _viewModel;

	private bool _isPanelTranslated;
	public ScheduleListView(ScheduleListViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
        this.BindingContext = viewModel;
		panelleft.TranslateTo(-80, 0, 150); // No visible
	}

	private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
	{
		var viewModel = (ScheduleListViewModel)BindingContext;
		viewModel.BindDataToScheduleList();
	}

	private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		if (_isPanelTranslated)
		{
			// No visible
			panelleft.TranslateTo(-80, 0, 150);
		}
		else
		{
			// Visible
			panelleft.TranslateTo(0, 0, 150);
		}
		_isPanelTranslated = !_isPanelTranslated;
    }


	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.GetScheduleListCommand.Execute(null);
    }

}