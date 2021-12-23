using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursova_Chess
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
            createGrid();
            errout.Visible = false;
        }

        static CBoard board = new CBoard();
        public static Button[,] buttons; // board tiles
        bool GUIfigures = true;
        bool GUImoves = true;

        private void createGrid()
        {
            buttons = new Button[8, 8];
            panel1.Height = panel1.Width;
            Size btnSize = panel1.Size / CBoard.boardSize;
            panel1.Size = btnSize * CBoard.boardSize;

            for (int i = 0; i < CBoard.boardSize; i++) // red
                for (int j = 0; j < CBoard.boardSize; j++) // kolona
                {
                    // create button
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = btnSize;
                    buttons[i, j].Click += My_Click;
                    panel1.Controls.Add(buttons[i, j]);
                    buttons[i, j].Location = new Point(i * btnSize.Height, j * btnSize.Width);

                    // make transparent and add piece
                    buttons[i, j].FlatStyle = FlatStyle.Flat;
                    buttons[i, j].BackColor = Color.Transparent;
                    buttons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    buttons[i, j].BackgroundImage = board.getImage(i, j);
                    buttons[i, j].Text = "";
                    buttons[i, j].Tag = board.getCell(i, j) + i + j;
                }
        }

        private void drawFigures(bool draw)
        {
            if (draw) // kartini
            {
                for (int i = 0; i < CBoard.boardSize; i++) // red
                    for (int j = 0; j < CBoard.boardSize; j++) // kolona
                    {
                        buttons[i, j].BackgroundImage = board.getImage(i, j);
                        buttons[i, j].Text = "";
                    }
            }
            else // tekst
            {
                for (int i = 0; i < CBoard.boardSize; i++)
                    for (int j = 0; j < CBoard.boardSize; j++)
                    {
                        buttons[i, j].Text = board.getCell(i, j) == "EE" ? "E" : board.getCell(i, j);
                        buttons[i, j].BackgroundImage = null;
                    }
            }
        }

        private void btnStart_Click(object sender, EventArgs e) // button Start
        {
            panel1.Visible = false;
            board = new CBoard();
            drawFigures(GUIfigures);
            panel1.Visible = true;
            btnStart.Text = "New Game";
            btnSwitchView.Visible = true;
            btnShowLegal.Visible = true;
            scrW.Visible = true;
            scrB.Visible = true;
            scrW.Text = "White: " + board.getScore().White;
            scrB.Text = "Black: " + board.getScore().Black;
            lPlayerTurn.Visible = true;
            lPlayerTurn.Text = "White moves";
            errout.Text = "";
        }

        private void btnSwitchView_Click(object sender, EventArgs e) // button Switch View
        {
            if (GUIfigures) GUIfigures = false;
            else GUIfigures = true;
            drawFigures(GUIfigures);
        }

        private void btnShowLegal_Click(object sender, EventArgs e) // button Show legal moves
        {
            if (GUImoves)
            {
                btnShowLegal.Text = "Moves: Off";
                GUImoves = false;
            }
            else
            {
                btnShowLegal.Text = "Moves: On";
                GUImoves = true;
            }
        }

        private void My_Click(object sender, EventArgs e) // chess board buttons
        {
            Button bt = (Button)sender;

            // koordinati na natisnat buton
            string pc = bt.Tag.ToString();
            int x = int.Parse(pc[2].ToString());
            int y = int.Parse(pc[3].ToString());
            CPiece piece = board.getPiece(x, y);

            errout.Text = board.PickOrDropPiece(x, y); // moving a piece
            try
            {
                if (errout.Text[4] == 'p')
                {
                    buttons[x, y].BackColor = Color.FromArgb(150, Color.Gray);
                    if (GUImoves)
                        foreach (loc lc in piece.getMoveset())
                        {
                            try { buttons[x + lc.x, y + lc.y].BackColor = Color.FromArgb(150, Color.Green); }
                            catch (IndexOutOfRangeException) { }
                        }
                }
                if (errout.Text[4] == 'd' || errout.Text[0] == 'C')
                {
                    foreach (Button b in buttons) b.BackColor = Color.Transparent;
                    drawFigures(GUIfigures);
                }
            }catch(IndexOutOfRangeException) { errout.Text = "PickOrDropPiece dialog error"; }

            // update score
            Score sc = board.getScore();
            scrW.Text = "White: " + sc.White;
            scrB.Text = "Black: " + sc.Black;
            
            // update turn
            lPlayerTurn.Text = board.getTurn().ToString() + " moves";

            // end game
            string caption = "Game Won";
            string message="";
            if (sc.White >= 100) { message = "White wins!";  }
            if (sc.Black >= 100) {  message = "Black wins!"; }
            errout.Text = message;
            message += "\nDo you want to play again?";
            MessageBoxButtons mbt = MessageBoxButtons.YesNo;
            DialogResult result;
            if (sc.White >= 100 || sc.Black >= 100)
            {
                result = MessageBox.Show(message, caption, mbt);
                if (result == DialogResult.Yes) { btnStart.PerformClick(); }
            }

        } // My_Click

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
