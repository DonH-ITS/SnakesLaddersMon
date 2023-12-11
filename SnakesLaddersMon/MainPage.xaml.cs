using Microsoft.Maui.Controls.Shapes;

namespace SnakesLaddersMon
{
    public partial class MainPage : ContentPage
    {
        private Color boardColour = Color.FromArgb("#2B0B98");
        Random random;
        private bool dicerolling;
        private List<SnakeLadder> snakesladders;
        private List<Player> players;
        private int playerGo;

        public bool DiceRolling
        {
            get => dicerolling;
            set
            {
                if (dicerolling == value)
                    return;
                dicerolling = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NotDiceRolling));
            }
        }

        public bool NotDiceRolling => !DiceRolling;

        public MainPage() {
            InitializeComponent();
            SetUpEverything();
            BindingContext = this;
        }


        private void SetUpEverything() {
            random = new Random();
            dicerolling = false;
            CreatetheGrid();
            FillDiceGrid(1, DiceGrid);
            PlaceSnakesLadders();
            InitialisePlayers();
        }

        private void PlaceSnakesLadders() {
            SnakeLadder.grid = GridGameTable; 
            snakesladders = new List<SnakeLadder>();
            snakesladders.Add(new SnakeLadder(9, 8, 3, 6));
            snakesladders.Add(new SnakeLadder(7, 2, 7, 4));

            //Straight snakes
            snakesladders.Add(new SnakeLadder(0, 5, 2, 2));
            snakesladders.Add(new SnakeLadder(8, 9, 2, 2));

            //4x3 snakes
            snakesladders.Add(new SnakeLadder(0, 3, 4, 6));
            snakesladders.Add(new SnakeLadder(3, 6, 9, 7));

            //3x2 snakes
            snakesladders.Add(new SnakeLadder(5, 7, 4, 3));
            snakesladders.Add(new SnakeLadder(7, 9, 1, 2));

            //Diagonal snakes
            snakesladders.Add(new SnakeLadder(7, 8, 6, 5));
            snakesladders.Add(new SnakeLadder(0, 1, 1, 2));
        }

        private void InitialisePlayers() {
            Player.grid = GridGameTable;
            players = new List<Player>();
            playerGo = 0;
            players.Add(new Player(player1piece));
        }

       /* private int RolltheDice() {
            int amount = random.Next(1, 7);
            return amount;
        }*/

        private int whichnumber(int row, int column) {
            if( row % 2 == 0 ) {
                int start = 100 - (row * 10);
                return start - column;
            }
            else {
                int start = (9 - row) * 10 + 1;
                return start + column;
            }
        }

        private LayoutOptions horizontaloption(int row) {
            if (row % 2 == 0) return LayoutOptions.Start;
            else return LayoutOptions.End;
        }


        public void CreatetheGrid() {
            for(int i=0; i < 10; ++i) {
                for(int j=0; j < 10; ++j) {
                    Border border = new Border
                    {
                        StrokeThickness = 2,
                        Background = boardColour,
                        Padding = new Thickness(3, 3),
                        HorizontalOptions = LayoutOptions.Fill,
                        VerticalOptions = LayoutOptions.Fill,
                        StrokeShape = new RoundRectangle
                        {
                            CornerRadius = new CornerRadius(4, 4, 4, 4)
                        },
                        Stroke = new LinearGradientBrush
                        {
                            EndPoint = new Point(0, 1),
                            GradientStops = new GradientStopCollection
                            {
                                new GradientStop { Color = Colors.Orange, Offset = 0.1f },
                                new GradientStop { Color = Colors.Brown, Offset = 1.0f }
                            },
                        },
                        Content = new Label
                        {
                            Text = whichnumber(i, j).ToString(),
                            TextColor = Colors.White,
                            FontSize = 10,
                            FontAttributes = FontAttributes.Bold,
                            //VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = horizontaloption(i)
                        }
                    };
                    GridGameTable.Add(border, j, i);
                }
            }
        }

        private Ellipse drawcircle() {
            Ellipse ell = new Ellipse()
            {
                Fill = Color.FromArgb("#000000"),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            return ell;
        }

        private void CleartheGrid(Grid grid) {
            List<View> childrenToRemove = new();
            foreach (var item in grid.Children) {
                if (item.GetType() == typeof(Ellipse)) {
                    childrenToRemove.Add((Ellipse)item);
                }
            }
            foreach (var item in childrenToRemove) {
                grid.Remove(item);
            }
        }

        private void FillDiceGrid(int i, Grid grid) {
            CleartheGrid(grid);
            switch (i) {
                case 1:
                    grid.Add(drawcircle(), 1, 1);
                    break;
                case 2:
                    grid.Add(drawcircle(), 0, 0);
                    grid.Add(drawcircle(), 2, 2);
                    break;
                case 3:
                    for (int j = 0; j < 3; j++) {
                        grid.Add(drawcircle(), j, j);
                    }
                    break;
                case 4:
                    for (int j = 0; j < 3; j += 2) {
                        for (int k = 0; k < 3; k += 2) {
                            grid.Add(drawcircle(), j, k);
                        }
                    }
                    break;
                case 5:
                    for (int j = 0; j < 3; j += 2) {
                        for (int k = 0; k < 3; k += 2) {
                            grid.Add(drawcircle(), j, k);
                        }
                    }
                    grid.Add(drawcircle(), 1, 1);
                    break;
                case 6:
                    for (int j = 0; j < 3; j += 2) {
                        for (int k = 0; k < 3; ++k) {
                            grid.Add(drawcircle(), k, j);
                        }
                    }
                    break;
            }
        }

        private async Task RollDiceUsingGrid() {
            int howmanyspins = random.Next(4, 10);
            int amount = 0;
            int lastthrow = 0;
            for (int i = 0; i < howmanyspins; i++) {
                await DiceBorder.RotateYTo(DiceBorder.RotationY+90, 150);
                do {
                    amount = random.Next(1, 7);
                } while (amount == lastthrow);
                lastthrow = amount;
                FillDiceGrid(amount, DiceGrid);
                await DiceBorder.RotateYTo(DiceBorder.RotationY + 90, 150);
            }
            await players[playerGo].MovePlayer(amount);
            int[] plpos = players[playerGo].PlayerPos; 
            foreach (var boardpiece in snakesladders) {
                if (boardpiece.IsStartingPlace(plpos[0], plpos[1])) {
                    await players[playerGo].MovePlayerSnakeLadder(boardpiece.EndPos[0], boardpiece.EndPos[1]);
                    break;
                }
            }
        }

        private async Task RollDiceUsingImages() {
            /*   int howmany = random.Next(4, 10);
               int which = 0;
               int last = 0;
               for(int i= 0; i < howmany; ++i) {
                   await DiceImg.RotateYTo(DiceImg.RotationY+90, DICE_DELAY / 2);
                   do {
                       which = random.Next(1, 7);
                   } while (which == last);
                   last = which;
                   DiceImg.Source = ImageSource.FromFile("dice" + which + ".png");
                   await DiceImg.RotateYTo(DiceImg.RotationY + 90, DICE_DELAY / 2);     
               }

               rollingdice = false;*/
        }

        private async void RollDice_Clicked(object sender, EventArgs e) {
            //DiceLbl.Text = RolltheDice().ToString();
            if (DiceRolling)
                return;
            DiceRolling = true;
            await RollDiceUsingGrid();
            DiceRolling = false;
        }
    }


}