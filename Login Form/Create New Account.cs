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

namespace Login_Form
{
    public partial class Create_New_Account : MetroFramework.Forms.MetroForm
    {
        public Create_New_Account()
        {
            InitializeComponent(); StyleManager = metroStyleManager1; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }
        public void secretpassword()
        {
            metroTextBox2.Text = metroTextBox2.Text.Replace("r", "R").Replace("t", "N").Replace("y", "Y>").Replace("u", "u<").Replace("i", "i++").Replace("o", "Oo").Replace("p", "pP").Replace("a", "2A0").Replace("s", "Ts").Replace("d", "Fd").Replace("f", "Df").Replace("g", "Hg").Replace("h", "Gh").Replace("j", "Kj").Replace("k", "Jk").Replace("r", "R").Replace("l", "life").Replace("z", "Uz").Replace("v", "60").Replace("b", "Nb").Replace("n", "Bn").Replace("m", "music").Replace(".", "dot");
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            metroTextBox1.Text = "";
        }

       

        private void Create_New_Account_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "")
            {
                MessageBox.Show("Please Enter Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                if (metroTextBox2.Text == "")
            {
                MessageBox.Show("Please Enter Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (File.Exists(@"usersinfo\info\" + metroTextBox1.Text))
                {
                    metroTextBox1.Text = ""; metroTextBox2.Text = ""; metroTextBox3.Text = ""; MessageBox.Show("Username already exists, please choose another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (metroTextBox2.Text == metroTextBox3.Text)
                    {
                        secretpassword();
                        StreamWriter t = new StreamWriter(@"usersinfo\info\" + metroTextBox1.Text);
                        t.WriteLine(metroTextBox2.Text);
                        t.Close();

                        StreamWriter tx = new StreamWriter(@"usersinfo\data\" + metroTextBox1.Text);
                        tx.WriteLine("");
                        tx.Close();

                        MessageBox.Show("Your Account Created / Username: " + metroTextBox1.Text + " / Password: ****** / try login now !");
                        Form1 x = new Form1();
                        x.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("please check your password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void Create_New_Account_Load(object sender, EventArgs e)
        {
            if (Music_Life_V11.Properties.Settings.Default.theme == "dark")
            {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                pictureBox1.Visible = false; pictureBox2.Visible = true;

            }
            else if (Music_Life_V11.Properties.Settings.Default.theme == "light")
            {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
                pictureBox1.Visible = true; pictureBox2.Visible = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            pictureBox1.Visible = false; pictureBox2.Visible = true;
            Music_Life_V11.Properties.Settings.Default.theme = "dark";
            Music_Life_V11.Properties.Settings.Default.Save();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            pictureBox1.Visible = true; pictureBox2.Visible = false;
            Music_Life_V11.Properties.Settings.Default.theme = "light";
            Music_Life_V11.Properties.Settings.Default.Save();
        
    }

        private void Create_New_Account_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 x = new Form1();
            x.Show();
         
        }
    }
}
