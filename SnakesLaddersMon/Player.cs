

namespace SnakesLaddersMon
{
    public class Player
    {
        private int position;
        private int row;
        private int col;
        private Image plyimg;
        private Grid grid;

        public int[] PlayerPos
        {
            get
            {
                int[] pos = new int[2];
                pos[0] = row;
                pos[1] = col;
                return pos;
            }
        }

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

        public async Task MovePlayerSnakeLadder(int moverow, int movecol) {
            
            double xStep = grid.Width / 10;
            double yStep = grid.Height / 12;
            int moveHeight = moverow - row;
            int moveWidth = movecol - col;
            await plyimg.TranslateTo(xStep * moveWidth, yStep*moveHeight, 350);
            plyimg.TranslationY = 0;
            plyimg.TranslationX = 0;
            row = moverow;
            col = movecol;
            position = whichnumber(row, col);
            plyimg.SetValue(Grid.ColumnProperty, col);
            plyimg.SetValue(Grid.RowProperty, row);
        }

        private static int whichnumber(int row, int column) {
            if (row % 2 == 0) {
                int start = 100 - (row * 10);
                return start - column;
            }
            else {
                int start = (9 - row) * 10 + 1;
                return start + column;
            }
        }
    }
}
