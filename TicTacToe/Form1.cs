using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        int move = 0;
        bool side = true;
        Tuple<char, char> sideIcon = new Tuple<char, char>('X','O');

        public Form1()
        {
            InitializeComponent();
            gameMessage.Text = "Player 1's turn (X)";
        }

        private void label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel.Text == "")
            {
                if (move != -1)
                { 
                    AssignMark(clickedLabel);

                    move++;

                    if (move >= 5)
                    {
                        CheckWin();
                    }
                }
            }
        }
        
        public void AssignMark(Label clickedLabel)
        {
            if (side)
            {
                clickedLabel.Text = char.ToString(sideIcon.Item1);
                gameMessage.Text = "Player 2's turn (O)";
                side = false;
            }
            else
            {
                clickedLabel.Text = char.ToString(sideIcon.Item2);
                gameMessage.Text = "Player 1's turn (X)";
                side = true;
            }
        }

        public void CheckWin()
        {
            //There are 8 possible ways a player can win
            Label[] labels = new Label[9]
            {
                label1, label2, label3, label4, label5, label6, label7, label8, label9
            };
            short[,] winSeq = new short[,]
            {
                {0, 1, 2},
                {3, 4, 5},
                {6, 7, 8},
                {0, 3, 6},
                {1, 4, 7},
                {2, 5, 8},
                {0, 4, 8},
                {2, 4, 6}
            };
            
            for( int i = 0; i < 8; i++ )
            {

                //It's better to just move on and not read this terrible expression
                if (labels[ winSeq[i, 0] ].Text.Equals( labels[ winSeq[i, 1] ].Text ) &&
                    labels[ winSeq[i, 1] ].Text.Equals( labels[ winSeq[i, 2] ].Text ) &&
                   !labels[ winSeq[i, 0] ].Text.Equals( "" ) ) 
                {
                    labels[ winSeq[i,0] ].BackColor = Color.Red;
                    labels[ winSeq[i,1] ].BackColor = Color.Red;
                    labels[ winSeq[i,2] ].BackColor = Color.Red;


                    if ( labels[ winSeq[i, 0] ].Text.Equals("X") )
                    {
                        gameMessage.Text = "Player 1 Wins!";
                    }
                    else
                    {
                        gameMessage.Text = "Player 2 Wins!";
                    }

                    //set to sentient value
                    move = -1;

                    return;
                }
            }

            if( move == 9 )
            {
                gameMessage.Text = "No player won! It's a tie!";
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
