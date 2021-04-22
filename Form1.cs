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
    enum CurrentPlayer
    {
        Cross,
        Circle
    }
    public partial class Form1 : Form
    {

        CurrentPlayer CurrentPlayer;
        public Form1()
        {
            InitializeComponent();
            CurrentPlayer = CurrentPlayer.Cross;
            changeLabel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Mark(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
            if (CurrentPlayer == CurrentPlayer.Cross)
            {
                senderButton.Text = "X";
                CurrentPlayer = CurrentPlayer.Circle;             
            }
            else
            {
                senderButton.Text = "O";
                CurrentPlayer = CurrentPlayer.Cross;              
            }
            if (checkForWinner())
                showWiner();
            changeLabel();


       
              

        }
       
        public void changeLabel()
        {
            if (CurrentPlayer == CurrentPlayer.Cross)
            {
                CurrentPlayerLabel.Text = "Krzyżyk";
            }
            else
            {
                CurrentPlayerLabel.Text = "Kółko";
            }
        }     
        public bool checkForWinner()
        {
            if(String.Compare(tl.Text,cl.Text) == 0 && String.Compare(cl.Text, bl.Text) == 0)
            {
                return true;
            }
            return false;
            if (String.Compare(tc.Text, cc.Text) == 0 && String.Compare(cc.Text, bc.Text) == 0)
            {
                return true;
            }
            return false;
            if (String.Compare(tr.Text, cr.Text) == 0 && String.Compare(cr.Text, br.Text) == 0)
            {
                return true;
            }
            return false;
        }

        public void showWiner ()
        {
            Form2 victoryScreen = new Form2(this);
            victoryScreen.winner = tl.Text;
            victoryScreen.Show();
        }
        public void clearBoard()
        {
            TableLayoutControlCollection buttons = tableLayoutPanel1.Controls;

            for(int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i] is Button)
                    buttons[i].Text = ""; 
            }
            CurrentPlayer = CurrentPlayer.Cross;    
        }
       
    }
}
