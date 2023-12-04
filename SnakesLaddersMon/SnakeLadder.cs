

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
            image = new Image()
            {
                Source = ImageSource.FromFile(fileName),
                WidthRequest = width,
                HeightRequest = height,
                ZIndex = 5,
                Aspect = Aspect.Fill
            };
            grid.Add(image);
        }

        private void placeladderongrid() {
            int Gridheight = StartRow - EndRow + 1;
            int Gridwidth = Math.Abs(StartCol - EndCol) + 1;
            double xStep = grid.WidthRequest/10;
            double yStep = grid.HeightRequest/12;
            if(Gridwidth == 1) {
                CreateImage(yStep * Gridheight-10, xStep, "ladder01.png");
            }
            else {
                double LengthofLadder = Math.Sqrt(Gridheight * Gridheight + Gridwidth * Gridwidth);
                CreateImage( (yStep) * LengthofLadder -20, xStep-10, "ladder01.png");
                double direction = 1.0;
                if (EndCol < StartCol)
                    direction = -1.0;
                double tan = direction*Gridwidth / Gridheight;
                double radian = Math.Atan(tan);
                double degrees = 180 * radian / Math.PI;
                image.Rotation = degrees;
            }
            image.SetValue(Grid.RowProperty, EndRow);
            image.SetValue(Grid.RowSpanProperty, Gridheight);
            if(EndCol < StartCol)
                image.SetValue(Grid.ColumnProperty, EndCol);
            else
                image.SetValue(Grid.ColumnProperty, StartCol);
            image.SetValue(Grid.ColumnSpanProperty, Gridwidth);

        }

        private void placesnakeongrid() {

        }
    }
}
