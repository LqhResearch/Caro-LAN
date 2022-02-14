using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace CaroGame
{
    public partial class Chessboard : Form
    {
        #region Properties
        ChessBoardManager chessBoard;
        SocketManager socket;
        #endregion
        #region Default system
        public Chessboard()
        {
            InitializeComponent();
        }

        private void Chessboard_Load(object sender, EventArgs e)
        {
            // Tắt thông báo các tiến trình sai
            Control.CheckForIllegalCrossThreadCalls = false;

            chessBoard = new ChessBoardManager(pnlChessboard, txtPlayerName, picIcon);
            chessBoard.EndedGame += ChessBoard_EndedGame;
            chessBoard.PlayerMarked += ChessBoard_PlayerMarked;

            //Load dữ liệu Contents
            pgbTime.Maximum = Contents.COUNT_DOWN_TIME;
            timerCountDown.Interval = Contents.COUNT_DOWN_INTERVAL;

            socket = new SocketManager();
            chessBoard.DrawChessBoard(); // Vẽ bảng
        }
        #endregion
        #region Function
        private void NewGame()
        {
            undoToolStripMenuItem.Enabled = true;
            timerCountDown.Stop();
            pgbTime.Value = 0;
            chessBoard.DrawChessBoard();
        }

        private void Undo()
        {
            chessBoard.Undo();
        }

        private void EndGame()
        {
            undoToolStripMenuItem.Enabled = false;
            timerCountDown.Stop();
            pnlChessboard.Enabled = false;
        }

        private void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)socket.Receive();
                    ProcessData(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Listen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        pnlChessboard.Enabled = true;
                        chessBoard.OtherPlayerMark(data.Point);
                        undoToolStripMenuItem.Enabled = true;
                        pgbTime.Value = 0;
                        timerCountDown.Start();
                    }));
                    break;
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        pnlChessboard.Enabled = false;
                    }));
                    break;
                case (int)SocketCommand.UNDO:
                    Undo();
                    break;
                case (int)SocketCommand.END_GAME:
                    MessageBox.Show("Đã 5 con");
                    break;
                case (int)SocketCommand.TIME_OUT:
                    MessageBox.Show("Hết giờ");
                    break;
                case (int)SocketCommand.QUIT:
                    timerCountDown.Stop();
                    MessageBox.Show("Người chơi đã thoát");
                    break;
            }
            Listen();
        }
        #endregion
        #region Delegate
        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
            socket.Send(new SocketData((int)SocketCommand.END_GAME, "", new Point(0, 0)));
        }

        private void ChessBoard_PlayerMarked(object sender, ButtonClickEvent e)
        {
            timerCountDown.Start();
            pnlChessboard.Enabled = false;
            pgbTime.Value = 0;
            socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "", e.ClickPoint));
            undoToolStripMenuItem.Enabled = false;
            Listen();
        }
        #endregion
        #region Menu tool strip
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", new Point(0, 0)));
            pnlChessboard.Enabled = true;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chessBoard.Undo();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Events
        private void Chessboard_Shown(object sender, EventArgs e)
        {
            txtIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(txtIP.Text))
                txtIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
        }

        private void Chessboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.OK != MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                e.Cancel = true;
            else
            {
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point(0, 0)));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Form closing: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void timerCountDown_Tick(object sender, EventArgs e)
        {
            pgbTime.Increment(100);
            if (pgbTime.Value == pgbTime.Maximum)
            {
                EndGame();
                socket.Send(new SocketData((int)SocketCommand.TIME_OUT, "", new Point(0, 0)));
            }
        }

        private void btnLAN_Click(object sender, EventArgs e)
        {
            socket.IP = txtIP.Text;
            if (!socket.ConnectServer())
            {
                socket.isServer = true;
                pnlChessboard.Enabled = true;
                socket.CreateServer();
            }
            else
            {
                socket.isServer = false;
                pnlChessboard.Enabled = false;
                Listen();
            }
        }
        #endregion
    }
}