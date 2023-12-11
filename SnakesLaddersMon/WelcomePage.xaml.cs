namespace SnakesLaddersMon;

public partial class WelcomePage : ContentPage
{
    int numberplayers;
	public WelcomePage()
	{
		InitializeComponent();
        numberplayers = 2;
        noPlayersText.Text = numberplayers + " players selected";
        HideSomeRows();
    }

    private void stepPlayers_ValueChanged(object sender, ValueChangedEventArgs e) {
        numberplayers = (int)stepPlayers.Value;
        noPlayersText.Text = numberplayers + " players selected";
        HideSomeRows();
    }

    private void HideSomeRows() {
        if (numberplayers == 4)
            PlayerNameGrid.RowDefinitions[3].Height = 50;
        else
            PlayerNameGrid.RowDefinitions[3].Height = 0;
        if (numberplayers >= 3)
            PlayerNameGrid.RowDefinitions[2].Height = 50;
        else
            PlayerNameGrid.RowDefinitions[2].Height = 0;
        PlayerNameGrid.HeightRequest = 50 * numberplayers;
    }

    private async void PlayGame_Clicked(object sender, EventArgs e) {
        //Navigate to MainPage
        Preferences.Default.Set("numberplayers", numberplayers);
        await Shell.Current.GoToAsync("//MainPage");
    }
}