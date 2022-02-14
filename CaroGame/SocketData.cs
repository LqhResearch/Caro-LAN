using System;
using System.Drawing;

namespace CaroGame
{
    public enum SocketCommand { SEND_POINT, NOTIFY, NEW_GAME, UNDO, END_GAME, TIME_OUT, QUIT }

    [Serializable]
    public class SocketData
    {
        public SocketData(int command, string message, Point point)
        {
            Command = command;
            Message = message;
            Point = point;
        }

        public int Command { get; set; }
        public string Message { get; set; }
        public Point Point { get; set; }
    }

}
