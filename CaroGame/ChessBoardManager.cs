using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame
{
    class ChessBoardManager
    {
        #region Properties
        private Panel ChessBoard { get; set; } // Bàn chơi
        private Guna2TextBox PlayerName { get; set; } // Tên người chơi
        private PictureBox Mark { get; set; } // Kí tự đánh
        private List<Player> PlayersList { get; set; } // Danh sách người chơi
        private List<List<Button>> Matrix;
        private int CurrentPlayer { get; set; } // Người chơi hiện tại

        private event EventHandler<ButtonClickEvent> playerMarked;
        public event EventHandler<ButtonClickEvent> PlayerMarked { add { playerMarked += value; } remove { playerMarked -= value; } }

        private event EventHandler endedGame;
        public event EventHandler EndedGame { add { endedGame += value; } remove { endedGame -= value; } }

        private Stack<PlayInfo> PlayTimeLine { get; set; }
        #endregion
        #region Initalize
        public ChessBoardManager(Panel chessBoard, Guna2TextBox playerName, PictureBox mark)
        {
            this.ChessBoard = chessBoard;
            this.PlayerName = playerName;
            this.Mark = mark;
            this.PlayersList = new List<Player>()
            {
                new Player("ABC", Image.FromFile(Application.StartupPath + @"\..\..\images\X.png")),
                new Player("DEF", Image.FromFile(Application.StartupPath + @"\..\..\images\O.png")),
            };
        }
        #endregion
        #region Common methods
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage != null)
                return;
            ChangeMark(btn);

            PlayTimeLine.Push(new PlayInfo(GetChessPoint(btn), CurrentPlayer));
            CurrentPlayer = (CurrentPlayer == 0) ? 1 : 0;

            ChangePlayer();
            if (playerMarked != null)
                playerMarked(this, new ButtonClickEvent(GetChessPoint(btn)));
            if (isEndGame(btn))
                EndGame();
        }

        public void DrawChessBoard()
        {
            ChessBoard.Enabled = true;
            ChessBoard.Controls.Clear();
            this.CurrentPlayer = 0;
            PlayTimeLine = new Stack<PlayInfo>();
            ChangePlayer();
            Matrix = new List<List<Button>>();
            Button oldBtn = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Contents.CELLS_HEIGHT; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Contents.CELLS_WIDTH; j++)
                {
                    Button btn = new Button()
                    {
                        BackColor = SystemColors.Control,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Location = new Point(oldBtn.Location.X + oldBtn.Width, oldBtn.Location.Y),
                        Size = new Size(Contents.CELL_SIZE, Contents.CELL_SIZE),
                        Tag = i.ToString(),
                    };
                    btn.Click += btn_Click;
                    ChessBoard.Controls.Add(btn);
                    Matrix[i].Add(btn);
                    oldBtn = btn;
                }
                oldBtn.Location = new Point(0, oldBtn.Location.Y + Contents.CELL_SIZE);
                oldBtn.Size = new Size(0, 0);
            }
        }

        private Point GetChessPoint(Button btn)
        {
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix[vertical].IndexOf(btn);
            Point point = new Point(horizontal, vertical);
            return point;
        }
        #endregion
        #region Change
        public void OtherPlayerMark(Point point)
        {
            Button btn = Matrix[point.Y][point.X];
            if (btn.BackgroundImage != null)
                return;
            ChangeMark(btn);

            PlayTimeLine.Push(new PlayInfo(GetChessPoint(btn), CurrentPlayer));
            CurrentPlayer = (CurrentPlayer == 0) ? 1 : 0;

            ChangePlayer();
            if (isEndGame(btn))
                EndGame();
        }

        private void ChangeMark(Button btn)
        {
            btn.BackgroundImage = PlayersList[CurrentPlayer].Mark;
        }

        private void ChangePlayer()
        {
            this.PlayerName.Text = PlayersList[CurrentPlayer].Name;
            this.Mark.BackgroundImage = PlayersList[CurrentPlayer].Mark;
        }
        #endregion
        #region Undo quân cờ
        public bool Undo()
        {
            if (PlayTimeLine.Count < 1)
                return false;
            bool isUndo1 = UndoAStep();
            bool isUndo2 = UndoAStep();
            PlayInfo oldPlayInfo = PlayTimeLine.Peek();
            CurrentPlayer = PlayTimeLine.Peek().CurrentPlayer == 0 ? 1 : 0;
            return isUndo1 && isUndo2;
        }

        private bool UndoAStep()
        {
            if (PlayTimeLine.Count < 1)
                return false;
            PlayInfo oldPlayInfo = PlayTimeLine.Pop();
            Button btn = Matrix[oldPlayInfo.Point.Y][oldPlayInfo.Point.X];

            btn.BackgroundImage = null;
            if (PlayTimeLine.Count < 1)
                CurrentPlayer = 0;
            else
                oldPlayInfo = PlayTimeLine.Peek();
            ChangePlayer();
            return false;
        }
        #endregion
        #region End game
        public void EndGame()
        {
            if (endedGame != null)
                endedGame(this, new EventArgs());
        }
        #endregion
        #region Kiểm tra chiến thắng 5 quân
        private bool isEndGame(Button btn)
        {
            if (isEndHorizontal(btn) || isEndVertical(btn) || isEndPrimaryDiagonal(btn) || isEndSecondaryDiagonal(btn))
                return true;
            return false;
        }

        private bool isEndHorizontal(Button btn)
        {
            Point point = GetChessPoint(btn);
            int countLeft = 0;
            for (int i = point.X; i >= 0; i--)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                    countLeft++;
                else
                    break;
            }

            int countRight = 0;
            for (int i = point.X + 1; i < Contents.CELLS_WIDTH; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                    countRight++;
                else
                    break;
            }
            return countLeft + countRight >= 5;
        }

        private bool isEndVertical(Button btn)
        {
            Point point = GetChessPoint(btn);
            int countTop = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                    countTop++;
                else
                    break;
            }

            int countBottom = 0;
            for (int i = point.Y + 1; i < Contents.CELLS_HEIGHT; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                    countBottom++;
                else
                    break;
            }
            return countTop + countBottom >= 5;
        }

        private bool isEndPrimaryDiagonal(Button btn)
        {
            Point point = GetChessPoint(btn);
            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.Y - i < 0 || point.X - i < 0)
                    break;
                if (Matrix[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
                    countTop++;
                else
                    break;
            }

            int countBottom = 0;
            for (int i = 1; i <= Contents.CELLS_WIDTH - point.X; i++)
            {
                if (point.Y + i >= Contents.CELLS_HEIGHT || point.X + i >= Contents.CELLS_WIDTH)
                    break;
                if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                    countBottom++;
                else
                    break;
            }
            return countTop + countBottom >= 5;
        }

        private bool isEndSecondaryDiagonal(Button btn)
        {
            Point point = GetChessPoint(btn);
            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.Y - i < 0 || point.X + i >= Contents.CELLS_WIDTH)
                    break;
                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                    countTop++;
                else
                    break;
            }

            int countBottom = 0;
            for (int i = 1; i <= Contents.CELLS_WIDTH - point.X; i++)
            {
                if (point.Y + i >= Contents.CELLS_HEIGHT || point.X - i < 0)
                    break;
                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                    countBottom++;
                else
                    break;
            }
            return countTop + countBottom >= 5;
        }
        #endregion
    }

    public class ButtonClickEvent : EventArgs
    {
        public ButtonClickEvent(Point clickPoint)
        {
            ClickPoint = clickPoint;
        }

        public Point ClickPoint { get; set; }
    }
}