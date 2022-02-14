using System.Drawing;

namespace CaroGame
{
    class Player
    {
        public Player(string name, Image mark)
        {
            Name = name;
            Mark = mark;
        }

        public string Name { get; set; }
        public Image Mark { get; set; }
    }
}
