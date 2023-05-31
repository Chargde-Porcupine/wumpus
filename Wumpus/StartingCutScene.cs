﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cao;

namespace Wumpus
{
    public partial class StartingCutScene : Form
    {
        private GameControl gc;
        public int SelectedMode = 1;
        public StartingCutScene(GameControl gc)
        {
            this.gc = gc;
            InitializeComponent();
            //sets mode to "normal"
            diffiultySelector.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            gc.showMenu();
        }

        private void diffiultySelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedMode = diffiultySelector.SelectedIndex;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
