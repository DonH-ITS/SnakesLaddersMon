

namespace SnakesLaddersMon
{
    public class Player
    {
        private int position;
        private int row;
        private int col;
        private Image plyimg;
        private Grid grid;

        public Player(Grid grid, Image image) {
            this.row = 9;
            this.col = 0;
            this.position = 1;
            this.grid = grid;
            this.plyimg = image;
        }

        public async Task MovePlayer(int count) {
            double xStep = grid.Width / 10;
            double yStep = grid.Height / 12;
            for (int i=0; i<count; i++) {
                if(position % 10 == 0) {
                    await MoveVertically(yStep);
                }
                else {
                    await MoveHorizontally(xStep);
                }
                position++;
            }
        }

        private async Task MoveHorizontally(double step) {
            int direction = 1;
            if (row % 2 == 0)
                direction = -1;
            col += direction;
            await plyimg.TranslateTo(direction*step, 0, 250);
            plyimg.TranslationX = 0;
            plyimg.SetValue(Grid.ColumnProperty, col);
        }

        private async Task MoveVertically(double step) {
            row--;
            await plyimg.TranslateTo(0, -1 * step, 250);
            plyimg.TranslationY = 0;
            plyimg.SetValue(Grid.RowProperty, row);
        }
    }
}
