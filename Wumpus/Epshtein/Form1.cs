using System;
using System.Windows.Forms;

namespace Epshtein
{
    public partial class Form1 : Form
    {
        private GameLocations gameLocations;
        private Player player;
        public Form1()
        {
            InitializeComponent();
        }

        private void ConstructorButton_Click(object sender, EventArgs e)
        {
        }

        private void PlayerConstructorButton_Click(object sender, EventArgs e)
        {
            player = new Player();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonmovewump_Click(object sender, EventArgs e)
        {
            if(gameLocations != null)
            {
                gameLocations.moveWumpus(2);
            }
        }

        private void buttonMovePlayer_Click(object sender, EventArgs e)
        {
            
        }
    }
}