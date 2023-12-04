
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

        public int[] EndPos
        {
            get
            {
                int[] pos = new int[2];
                pos[0] = EndRow;
                pos[1] = EndCol;
                return pos;
            }
        }

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
            int Gridheight = Math.Abs(StartRow - EndRow) + 1;
            int Gridwidth = Math.Abs(StartCol - EndCol) + 1;
            double xStep = grid.WidthRequest / 10;
            double yStep = grid.HeightRequest / 12;
            if(Gridwidth == 1) {
                place1colsnake(xStep, yStep, Gridheight);
            }
            else if (Gridheight == 4 && Gridwidth == 3) {
                place4x3snake(grid, xStep, yStep);
            }
            else if (Gridheight == 3 && Gridwidth == 2) {
                place3x2snake(grid, xStep, yStep);
            }

        }

        private void place1colsnake(double xStep, double yStep, int Gridheight) {
            CreateImage(yStep * Gridheight - 10, xStep-5, "snake1.png");
            image.SetValue(Grid.RowProperty, StartRow);
            image.SetValue(Grid.RowSpanProperty, Gridheight);
            image.SetValue(Grid.ColumnProperty, EndCol);
            image.SetValue(Grid.ColumnProperty, StartCol);
            image.SetValue(Grid.ColumnSpanProperty, 1);

        }

        private void place4x3snake(Grid grid, double xStep, double yStep) {
            CreateImage(4 * (yStep - 5), 3 * (xStep - 5), "snake3.png");
            if (StartCol < EndCol) {
                image.SetValue(Grid.ColumnProperty, StartCol);
            }
            else {
                image.SetValue(Grid.ColumnProperty, EndCol);
                image.RotationY = 180;
            }
            image.SetValue(Grid.RowProperty, StartRow);
            image.SetValue(Grid.RowSpanProperty, 4);
            image.SetValue(Grid.ColumnSpanProperty, 3);
        }

        private void place3x2snake(Grid grid, double xStep, double yStep) {
            CreateImage(3 * (yStep - 5), 2 * (xStep - 5), "snake2.png");
            if (StartCol < EndCol) {
                image.SetValue(Grid.ColumnProperty, StartCol);
            }
            else {
                image.SetValue(Grid.ColumnProperty, EndCol);
                image.RotationY = 180;
            }
            image.SetValue(Grid.RowProperty, StartRow);
            image.SetValue(Grid.RowSpanProperty, 3);
            image.SetValue(Grid.ColumnSpanProperty, 2);
        }

        public bool IsStartingPlace(int row, int column) {
            /*if (row == StartRow && column == StartCol) return true;
            else return false;*/

            return (row == StartRow && column == StartCol);

        }
    }
}
