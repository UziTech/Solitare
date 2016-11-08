using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Solitare
{
    partial class AboutBox : Form
    {
        #region Global Variables
        Color[] colorArray = new Color[7];
        int colorIndex = 0;
        #endregion
        public AboutBox()
        {
            InitializeComponent();
            colorArray[0] = Color.Red;
            colorArray[1] = Color.Orange;
            colorArray[2] = Color.Yellow;
            colorArray[3] = Color.Green;
            colorArray[4] = Color.Blue;
            colorArray[5] = Color.Indigo;
            colorArray[6] = Color.Violet;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.ForeColor = ChangeColor(label1.ForeColor);
            label2.ForeColor = ChangeColor(label2.ForeColor);
        }
        private Color ChangeColor(Color color)
        {
            int colorMax = 350;
            if (++colorIndex == colorMax)
            {
                colorIndex = 0;
            }
            int index = colorIndex / (colorMax / 7 + 1);
            float redS = (float)colorArray[index].R;
            float redE = (float)colorArray[(index == 6) ? 0 : index + 1].R;
            float greenS = (float)colorArray[index].G;
            float greenE = (float)colorArray[(index == 6) ? 0 : index + 1].G;
            float blueS = (float)colorArray[index].B;
            float blueE = (float)colorArray[(index == 6) ? 0 : index + 1].B;
            int red = (int)(color.R + (redE - redS) / (colorMax / 7 + 1));
            int green = (int)(color.G + (greenE - greenS) / (colorMax / 7 + 1));
            int blue = (int)(color.B + (blueE - blueS) / (colorMax / 7 + 1));
            if (red < 0)
            {
                red = 0;
            }
            else if (red > 255)
            {
                red = 255;
            }
            if (green < 0)
            {
                green = 0;
            }
            else if (green > 255)
            {
                green = 255;
            }
            if (blue < 0)
            {
                blue = 0;
            }
            else if (blue > 255)
            {
                blue = 255;
            }
            return Color.FromArgb(red, green, blue);
        }
        private void AboutBox_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.freewebs.com/tonysfiles");
        }
    }
}
