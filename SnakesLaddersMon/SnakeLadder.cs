
namespace SnakesLaddersMon
{
    public class SnakeLadder
    {
        private int StartRow;
        private int EndRow;
        private int StartCol;
        private int EndCol;
        private Image image;
        private Grid grid;

        public SnakeLadder(int startR, int EndR, int StartC, int EndC, Grid grid) {
            this.StartRow = startR;
            this.EndRow = EndR;
            this.StartCol = StartC;
            this.EndCol = EndC;
            this.grid = grid;
            if (StartRow > EndRow) {
                placeladderongrid();
            }
            else
                placesnakeongrid();
        }

        private void CreateImage(double height, double width, string fileName) {
            Image image = new Image()
            {
                Source = ImageSource.FromFile(fileName),
                WidthRequest = width,
                HeightRequest = height,
                Aspect = Aspect.Fill
            };
            grid.Add(image);
        }

        private void placeladderongrid() {
            int Gridheight = StartRow - EndRow + 1;
            int Gridwidth = Math.Abs(StartCol - EndCol) + 1;
            double xStep = grid.Width/10;
            double yStep = grid.Height/12;
            if(Gridwidth == 1) {
                CreateImage(yStep * Gridheight, xStep, "ladder01.png");
                image.SetValue(Grid.RowProperty, EndRow);
                image.SetValue(Grid.RowSpanProperty, Gridheight);
                image.SetValue(Grid.ColumnProperty, EndCol);
                image.SetValue(Grid.ColumnSpanProperty, 1);
            }

        }

        private void placesnakeongrid() {

        }
    }
}
