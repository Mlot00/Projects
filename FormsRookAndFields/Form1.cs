using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using WindowsFormsApp2.Properties;
using Timer = System.Windows.Forms.Timer;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Color lightColor = Color.White; 
        private Color darkColor = Color.Black;
        Image imageRook = Resources.whiteRook;
        private Timer timer = new Timer();
        private Stopwatch stopwatch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("You can move around the fields with arrows", "infromation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InitializeTimer();
            stopwatch.Start();

        }
        private void InitializeTimer()
        {
            timer.Interval = 1000; 
            timer.Start();
            timer.Tick += Timer_Tick;
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = $"{DateTime.Now.ToString("F")}";
            TimeSpan elapsed = stopwatch.Elapsed;
            toolStripLabel2.Text = $" Elapsed Time: {elapsed.TotalSeconds:F0} seconds";
        }

        int n; 
        PictureBox[,] P; 
        private int currentRow; 
        private int currentCol; 

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            n = 8; 
            P = new PictureBox[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    P[i, j] = new PictureBox();
                    P[i, j].BackColor = (i + j) % 2 == 0 ? lightColor : darkColor;
                    P[i, j].Location = new Point(j * 80, i * 80);
                    P[i, j].Size = new Size(80, 80);
                    panel1.Controls.Add(P[i, j]);
                }
            }
            int randomRow = new Random().Next(n); 
            int randomCol = new Random().Next(n); 
            currentCol = randomCol;
            currentRow = randomRow;
            P[randomRow, randomCol].Image = imageRook;
            P[randomRow, randomCol].SizeMode = PictureBoxSizeMode.Zoom;
        }


        private void RefreshChessboardColors()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    P[i, j].BackColor = (i + j) % 2 == 0 ? lightColor : darkColor;
                }
            }
        }

        private void firstFieldsColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lightColor = colorDialog.Color;
                RefreshChessboardColors();
            }
        }

        private void SecondFieldsColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    darkColor = colorDialog.Color;
                    RefreshChessboardColors();
                }
            }
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageRook = Resources.whiteRook;
            P[currentRow, currentCol].Image = imageRook;
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageRook = Resources.blackRook;
            P[currentRow, currentCol].Image = imageRook;
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape && ESCToolStripMenuItem.Checked)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ESCToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            ESCToolStripMenuItem.Checked = !ESCToolStripMenuItem.Checked;
        }
        private Random random = new Random();


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (currentCol > 0)
                    {
                        P[currentRow, currentCol].Image = null;
                        currentCol--;

                        P[currentRow, currentCol].Image = imageRook;
                        P[currentRow, currentCol].SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    break;
                case Keys.Right:
                    if (currentCol < n - 1)
                    {
                        P[currentRow, currentCol].Image = null;
                        currentCol ++;

                        P[currentRow, currentCol].Image = imageRook;
                        P[currentRow, currentCol].SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    break;
                case Keys.Up:
                    if (currentRow > 0)
                    {
                        P[currentRow, currentCol].Image = null;
                        currentRow--;

                        P[currentRow, currentCol].Image = imageRook;
                        P[currentRow, currentCol].SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    break;

                case Keys.Down:
                    if (currentRow < n - 1)
                    {
                        P[currentRow, currentCol].Image = null;
                        currentRow++;

                        P[currentRow, currentCol].Image = imageRook;
                        P[currentRow, currentCol].SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    break;
            }
        }

        private void enableToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            enableRandLocationMenuItem.Checked = !enableRandLocationMenuItem.Checked;
        }

        private void randomLocationToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if (enableRandLocationMenuItem.Checked)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        P[i, j].Image = null;
                    }
                }
                int row = random.Next(0, n);
                int col = random.Next(0, n);
                currentCol = col;
                currentRow = row;

                P[currentRow, currentCol].Image = imageRook;
                P[row, col].SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

	}
}