using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ColorConvert cc = new ColorConvert();


        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string imagePath;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "image files|*.jpg;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = dialog.FileName;
                cc.rgbimage = new Bitmap(imagePath);
                this.pictureBox1.Image = cc.rgbimage;
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            cc.ConvertRGBimageHSV();
            int width = cc.rgbimage.Width;
            int height = cc.rgbimage.Height;
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < Height; ++j)

                {
                    int tmpH = cc.hsvImage[i, j].h + trackBar1.Value;
                    if (tmpH < 0)
                        cc.hsvImage[i, j].h = (ushort)(tmpH + 360);
                    else if (tmpH >= 360)
                        cc.hsvImage[i, j].h = (ushort)(tmpH - 360);
                    else
                        cc.hsvImage[i, j].h = (ushort)tmpH;

                }
            trackBar1.Value = 0;
            cc.ConvertHSVimagetoRGB();
            pictureBox1.Image = cc.rgbimage;
            this.Cursor = Cursors.Default;


        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            

        }




        private void testconvertimageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cc.ConvertRGBimageHSV();
            cc.ConvertHSVimagetoRGB();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            cc.ConvertRGBimageHSV();
            int height = cc.rgbimage.Height;
            int width = cc.rgbimage.Width;

            for (int i = 0; i < width; ++i)
                for (int j = 0; j < Height; ++j)

                {
                    int tmpH = cc.hsvImage[i, j].h + trackBar2.Value;
                    if (tmpH < 0)
                        cc.hsvImage[i, j].h = 0;
                    else if (tmpH > 100)
                        cc.hsvImage[i, j].h = 100;

                    else
                        cc.hsvImage[i, j].h = (ushort)tmpH;

                }
            trackBar2.Value = 0;
            cc.ConvertHSVimagetoRGB();
            pictureBox1.Image = cc.rgbimage;
            this.Cursor = Cursors.Default;



        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string imagePath;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "image files|*.jpg;*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = saveFileDialog.FileName;
                cc.rgbimage.Save(imagePath);
            }


        }
    }

  
}


