using System.Drawing;

namespace CaroGame
{
    public class PlayInfo
    {
        public PlayInfo(Point point, int currentPlayer)
        {
            this.Point = point;
            this.CurrentPlayer = currentPlayer;
        }

        public Point Point { get; set; }
        public int CurrentPlayer { get; set; }
    }
}
