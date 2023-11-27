using Microsoft.Maui.Controls.Shapes;

namespace SnakesLaddersMon
{
    public partial class MainPage : ContentPage
    {
        private Color boardColour = Color.FromArgb("#2B0B98");

        public MainPage() {
            InitializeComponent();
            CreatetheGrid();
        }


        public void CreatetheGrid() {
            for(int i=0; i < 10; ++i) {
                for(int j=0; j < 10; ++j) {
                    Border border = new Border
                    {
                        StrokeThickness = 2,
                        Background = boardColour,
                        Padding = new Thickness(2, 2),
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
                            Text = ".NET MAUI",
                            TextColor = Colors.White,
                            FontSize = 7,
                            FontAttributes = FontAttributes.Bold
                        }
                    };
                    GridGameTable.Add(border, j, i);
                }
            }
        }

    }


}