using LanguageExt.ClassInstances.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stego_extract
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                picextract.Image = Image.FromFile(dialog.FileName);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)

            {
                picextract.Image.Save(dialog.FileName, ImageFormat.Bmp);
            }



        }

        private void ExtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color pedge;
            int e1, r, g, b;
            string bin1, bin2, bin3, sub1, sub2, sub3;
            Bitmap gr = new Bitmap(picextract.Image);
            int width = picextract.Width;
            int height = picextract.Height;
            string s = "";
            string sub;


            //for (int j = 0; j < picextract.Height; j++)
            for (int i = 0; i < picextract.Width; i++)
            {

                int y = (int)((Math.Sin((double)i * 2.0 * Math.PI / width) + 1.0) * (height - 1) / 2.0);


                pedge = gr.GetPixel(i, y);
                r = pedge.R;
                g = pedge.G;
                b = pedge.B;
                bin1 = process.conbinary(r);
                bin2 = process.conbinary(g);
                bin3 = process.conbinary(b);
                sub1 = bin1.Substring(0, 3);
                sub2 = bin2.Substring(0, 3);
                sub3 = bin3.Substring(0, 3);
                if (sub1 == "000")
                {

                    sub = bin1.Substring(6, 2);

                    s += sub;
                    //paytxt.Text = v;




                }
                else
                {
                    sub = bin1.Substring(7, 1);

                    s += sub;
                }

                if (sub2 == "000")
                {

                    sub = bin2.Substring(6, 2);

                    s += sub;
                    //paytxt.Text = v;




                }
                else
                {
                    sub = bin2.Substring(7, 1);

                    s += sub;
                }
                if (sub3 == "000")
                {

                    sub = bin3.Substring(6, 2);

                    s += sub;
                    //paytxt.Text = v;




                }
                else
                {
                    sub = bin3.Substring(7, 1);

                    s += sub;
                }
            }

            string dd = "";

            int len = s.Length;
           
            for (int i = 0; i < len - 8; i += 8)
            {
                string rr = s.Substring(i, 8);
                int u = process.convdecimal(rr);
                char cc = (char)u;




                dd += cc.ToString();


                    


               
                

                
            }
            secretextract.Text =dd ;
        }

        
    }
}

    


