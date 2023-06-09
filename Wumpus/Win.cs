﻿using _1095652_Roth_HuntTheWumpus;
using Cao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wumpus.Epshtein;

namespace Wumpus
{
    public partial class Win : Form
    {
        private Leaderboard leaderboard;
        private int score;
        private GameControl gameControl;
        public Win(int score, Leaderboard leaderboard, DateTime startTime, GameControl gameControl)
        {
            InitializeComponent();
            label2.Text = "Your score was: " + score.ToString();
            label3.Text = "Your time was: " + leaderboard.endRun(startTime);
            this.leaderboard = leaderboard;
            this.score = score;
            this.gameControl = gameControl;
        }

        private void buttonRetry_Click(object sender, EventArgs e)
        {
            gameControl.showMenu();

            //call control
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //close all forms
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Please enter your name");
                return;
            }
            leaderboard.writeItemsToFile(score, textBoxName.Text);
            MessageBox.Show("Leaderboard entry added! Navigate to the main menu to see where you placed!");
            button2.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            gameControl.showCredits();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            gameControl.showEnd(true);
        }
    }
}
