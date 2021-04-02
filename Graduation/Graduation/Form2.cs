using java.io;
using java.lang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graduation
{
    public partial class Form2 : Form
    {
        OpenFileDialog fdlg = new OpenFileDialog();
        string text = "";
        string nextChar = "";
        int pointer = 0;
        List<string> dic = new List<string>();//dictionary

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            fdlg.Title = "C#  Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fdlg.FileName;
                Image img = Image.FromFile(textBox1.Text);
                pictureBox1.Image = img;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }

        }

            private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please load image first!");
            }
            string CompChar = "";//compare
            int index = 0, retrn = 0 /*to take another char and check it in dictionary*/;
            text = BitConverter.ToString(imageToByteArray(pictureBox1.Image));
            pictureBox1.Text = "0 " + text[0] + "\n"; // first char
            dic.Add(""); // first element in dictionary is null
            dic.Add(text[0] + "");

            for (int indexText = 1; indexText < text.Length; indexText++)
            {

                CompChar += text[indexText];

                if (dic.IndexOf(CompChar) != -1)
                {
                    index = dic.IndexOf(CompChar);

                    retrn = 1;
                    if (indexText + 1 == text.Length)
                        pictureBox1.Text += index + " null\n";

                }
                else
                {
                    if (retrn == 1)
                        pictureBox1.Text += index + " " + CompChar[CompChar.Length - 1] + "\n";

                    else
                        pictureBox1.Text += "0 " + CompChar + "\n";

                    dic.Add(CompChar);
                    CompChar = "";


                    retrn = 0;

                }

            }



         pictureBox2.Image= byteArrayToImage(Encoding.ASCII.GetBytes(CompChar));
        
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
