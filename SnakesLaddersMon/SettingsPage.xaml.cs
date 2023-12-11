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
        bool returnvalue = base.OnBackButtonPressed();
        set.SaveSettingsJson();
        GoingBackToMain?.Invoke(this, true);
		return returnvalue;
        
    }
}