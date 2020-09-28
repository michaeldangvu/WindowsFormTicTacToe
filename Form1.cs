// done following a tutorial on youtube
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// making some changes for git
namespace WindowsFormTicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true; // true = x turn; false = y turn
        int turn_count = 0;
        int xWins = 0, oWins = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Michael Dang", "Tic Tac Toe About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            if (turn)
                turnLabel.Text = "Current turn: X";
            else
                turnLabel.Text = "Current turn: O";
            b.Enabled = false;
            turn_count++;
            checkForWinner();
        }

        private void checkForWinner()
        {
            bool thereIsWinner = false;
            // code to check for winner
            // horizontal checks
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                    thereIsWinner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                    thereIsWinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                    thereIsWinner = true;
            // verical checks
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                thereIsWinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                thereIsWinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                thereIsWinner = true;
            // diagonal checks
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                thereIsWinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                thereIsWinner = true;

            if (thereIsWinner)
            {
                disableButtons();
                if (turn)
                {
                    MessageBox.Show("O wins");
                    oWins++;
                }
                else
                {
                    MessageBox.Show("X wins");
                    xWins++;
                }
                scoreLabel.Text = "Score: X: " + xWins + " O: " + oWins;
            }
            else if (turn_count == 9)
            {
                disableButtons();
                MessageBox.Show("Draw");
            }
            //else no winner/ties yet

        }

        private void disableButtons()
        {
            foreach(Control c in Controls)
            {
                if(c.GetType() == typeof(Button))
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
                b.Text = "";
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
        }
    }
}
