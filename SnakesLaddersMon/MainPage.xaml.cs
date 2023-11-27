using Microsoft.Maui.Controls.Shapes;

namespace SnakesLaddersMon
{
    public partial class MainPage : ContentPage
    {
        private Color boardColour = Color.FromArgb("#2B0B98");
        Random random;

        public MainPage() {
            InitializeComponent();
            SetUpEverything();
        }


        private void SetUpEverything() {
            random = new Random();
            CreatetheGrid();
        }

        private int RolltheDice() {
            int amount = random.Next(1, 7);
            return amount;
        }

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

        private void FillDiceGrid(int i, Grid grid) {
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

        private void RollDice_Clicked(object sender, EventArgs e) {
            //DiceLbl.Text = RolltheDice().ToString();
        }
    }


}