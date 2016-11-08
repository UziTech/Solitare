using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Solitare
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            vegas.Checked = Properties.Settings.Default.vegasScoring;
            standard.Checked = Properties.Settings.Default.standardScoring;
            noScoring.Checked = (!vegas.Checked && !standard.Checked);
            showStatus.Checked = Properties.Settings.Default.showStatus;
            showTimer.Checked = Properties.Settings.Default.showTimer;
            cumulative.Checked = Properties.Settings.Default.cumulativeScoring;
            autoFlip.Checked = Properties.Settings.Default.autoFlip;
            if (System.IO.File.Exists(Properties.Settings.Default.cardBack))
                pictureBox1.Image = MakeBackOfCard(Properties.Settings.Default.cardBack);
            else
                pictureBox1.Image = Properties.Resources.clouds;
            textBox1.Text = Properties.Settings.Default.cardBack;
            if (Properties.Settings.Default.drawCards == 1)
            {
                draw1Cards.Checked = true;
                draw3Cards.Checked = false;
            }
            else
            {
                draw1Cards.Checked = false;
                draw3Cards.Checked = true;
            }
        }
        private void ok_Click(object sender, EventArgs e)
        {
            if (draw1Cards.Checked)
                Properties.Settings.Default.drawCards = 1;
            else
                Properties.Settings.Default.drawCards = 3;
            Properties.Settings.Default.showStatus = showStatus.Checked;
            Properties.Settings.Default.showTimer = showTimer.Checked;
            Properties.Settings.Default.vegasScoring = vegas.Checked;
            Properties.Settings.Default.standardScoring = standard.Checked;
            Properties.Settings.Default.autoFlip = autoFlip.Checked;
            if (vegas.Checked && cumulative.Checked)
                Properties.Settings.Default.cumulativeScoring = true;
            else
                Properties.Settings.Default.cumulativeScoring = false;
            if (System.IO.File.Exists(textBox1.Text) && (textBox1.Text.EndsWith(".bmp") || textBox1.Text.EndsWith(".jpg") || textBox1.Text.EndsWith(".gif") || textBox1.Text.EndsWith(".png")))
                Properties.Settings.Default.cardBack = textBox1.Text;
            else
                Properties.Settings.Default.cardBack = "";
            Properties.Settings.Default.Save();
            Close();
        }
        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (textBox1.Text.Contains('\\') && System.IO.Directory.Exists(textBox1.Text.Substring(0, textBox1.Text.LastIndexOf('\\'))))
            {
                fd.InitialDirectory = textBox1.Text.Substring(0, textBox1.Text.LastIndexOf('\\'));
            }
            else
            {
                fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }
            fd.Title = "Card Back Picture";
            fd.Filter = "J-Peg|*.jpg|Bitmap|*.bmp|Gif|*.gif|PNG|*.png";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fd.FileName;
            }
            if (System.IO.File.Exists(textBox1.Text))
                pictureBox1.Image = MakeBackOfCard(textBox1.Text);
            else
                pictureBox1.Image = Properties.Resources.clouds;
        }
        private Image MakeBackOfCard(string imgLoc)
        {
            Bitmap bm = new Bitmap(imgLoc);
            Bitmap nbm = new Bitmap(90, 130);
            using (Graphics g = Graphics.FromImage(nbm))
                g.DrawImage(bm, 0, 0, 90, 130);
            for (int i = 1; i < 89; i++)
            {
                nbm.SetPixel(i, 0, Color.Black);
                nbm.SetPixel(i, 129, Color.Black);
            }
            for (int i = 1; i < 129; i++)
            {
                nbm.SetPixel(0, i, Color.Black);
                nbm.SetPixel(89, i, Color.Black);
            }
            nbm.SetPixel(1, 1, Color.Black);
            nbm.SetPixel(88, 1, Color.Black);
            nbm.SetPixel(1, 128, Color.Black);
            nbm.SetPixel(88, 128, Color.Black);
            nbm.SetPixel(0, 0, Color.Green);
            nbm.SetPixel(89, 0, Color.Green);
            nbm.SetPixel(0, 129, Color.Green);
            nbm.SetPixel(89, 129, Color.Green);
            return nbm;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(textBox1.Text))
                pictureBox1.Image = MakeBackOfCard(textBox1.Text);
            else
                pictureBox1.Image = Properties.Resources.clouds;
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void vegas_CheckedChanged(object sender, EventArgs e)
        {
            cumulative.Enabled = vegas.Checked;
        }
    }
}
