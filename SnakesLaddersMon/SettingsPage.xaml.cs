namespace SnakesLaddersMon;

public partial class SettingsPage : ContentPage
{
	Settings set;
	public SettingsPage(Settings mainset)
	{
		InitializeComponent();
		this.set = mainset;
		BindingContext = set;
	}

	public event EventHandler<bool> GoingBackToMain;

    protected override bool OnBackButtonPressed() {
        set.SaveSettingsJson();
        GoingBackToMain?.Invoke(this, true);
		return base.OnBackButtonPressed();
        
    }

    private async void SaveBtn_Clicked(object sender, EventArgs e) {
        set.SaveSettingsJson();
        GoingBackToMain?.Invoke(this, true);
        await Navigation.PopAsync();
    }
}