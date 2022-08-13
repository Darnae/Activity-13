using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class TicTacToeForm : Form
    {
        private int[,] board = new int[3, 3]; // creates board model in memory

        bool turn = true; // true = player, turn false for Ai turn

        int Turn_Limit = 0; // to keep track of turns


        public TicTacToeForm()
        {
            InitializeComponent();
        }

        private void makeBoard() // method to simulate board
        {

            // board spaces 

            board[1, 1] = 1;
            board[1, 2] = 2;
            board[1, 3] = 3;
            board[2, 1] = 4;
            board[2, 2] = 5;
            board[2, 3] = 6;
            board[3, 1] = 7;
            board[3, 2] = 8;
            board[3, 3] = 9;

        }

        private void Button_Click(object sender, EventArgs e) // method for button control and gameplay
        {

            Button button = (Button)sender; // so board registers buttons

            if (turn)
            {
                button.Text = "X";
            }
            else
            {
                button.Text = "O";
            }

            turn = !turn;
            button.Enabled = false;
            Turn_Limit++; // counts turns every click

            CheckforWinner();

        }// button method

        private void CheckforWinner() // to check for wins
        {
            bool winner = false;


            // horizontal victories

            if ((Op1.Text == Op2.Text) && (Op2.Text == Op3.Text) && (!Op1.Enabled))
            {

                winner = true;
            }
            else if ((Op4.Text == Op5.Text) && (Op5.Text == Op6.Text) && (!Op4.Enabled))
            {
                winner = true;
            }
            else if ((Op7.Text == Op8.Text) && (Op8.Text == Op9.Text) && (!Op7.Enabled))
            {
                winner = true;
            }

            // vertical victories

            else if ((Op1.Text == Op4.Text) && (Op4.Text == Op7.Text) && (!Op1.Enabled))
            {
                winner = true;
            }
            else if ((Op2.Text == Op5.Text) && (Op5.Text == Op8.Text) && (!Op2.Enabled))
            {
                winner = true;
            }
            else if ((Op3.Text == Op6.Text) && (Op6.Text == Op9.Text) && (!Op3.Enabled))
            {
                winner = true;
            }

            // Diagonal victories

            else if ((Op1.Text == Op5.Text) && (Op5.Text == Op9.Text) && (!Op1.Enabled))
            {
                winner = true;
            }
            else if ((Op3.Text == Op5.Text) && (Op5.Text == Op7.Text) && (!Op3.Enabled))
            {
                winner = true;
            }

            if (winner) // if a player wins
            {
                endGame();

                string win_dialouge = "";

                if (turn)
                {
                    win_dialouge = "O";
                }

                else
                {
                    win_dialouge = "X";
                }

                MessageBox.Show(win_dialouge + " Wins!");
            }

            else // if there is a draw
            {
                if (Turn_Limit == 9)
                {
                    MessageBox.Show("Match was a draw. Try again.");
                }
            }
        }// check for winner end



        private void endGame() // method for stopping game
        {
            try
            { 
                foreach (Control c in Controls) // accounts for all buttons at once
                {
                    Button button = (Button)c;

                    button.Enabled = false; // ends game when winner is found
                }
            }//end try

            catch { }
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            turn = true;
            Turn_Limit = 0;

            try 
            {
                foreach (Control c in Controls) // accounts for all buttons at once
                {
                    Button button = (Button)c;

                    button.Enabled = true; // ends game when winner is found
                    button.Text = "";

                }
            }//end try

            catch { }

        } //new game button end


    }// for form 1
}// for namespace
