using Music_Life_V10;
using Music_Life_V11;
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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent(); StyleManager = metroStyleManager1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {







            metroTextBox1.Text = Music_Life_V11.Properties.Settings.Default.rmbu;
            metroTextBox2.Text = Music_Life_V11.Properties.Settings.Default.rmbp;
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
        bool user = true;
        bool pass = true;


       
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "" || metroTextBox2.Text == "")
            {
                MessageBox.Show("Please check inputs field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (File.Exists(@"usersinfo\info\" + metroTextBox1.Text))
                {
                    StreamReader r = new StreamReader(@"usersinfo\info\" + metroTextBox1.Text);
                    label1.Text = r.ReadLine();
                    label1.Text = label1.Text.Replace("R", "r").Replace("N", "t").Replace("Y>", "y").Replace("u<", "u").Replace("i++", "i").Replace("Oo", "o").Replace("pP", "p").Replace("2A0", "a").Replace("Ts", "s").Replace("Fd", "d").Replace("Df", "f").Replace("Hg", "g").Replace("Gh", "h").Replace("Kj", "j").Replace("Jk", "k").Replace("R", "r").Replace("life", "l").Replace("Uz", "z").Replace("60", "v").Replace("Nb", "b").Replace("Bn", "n").Replace("music", "m").Replace("dot", ".");
                    if (metroTextBox2.Text == label1.Text)
                    {
                        if (metroCheckBox2.Checked == true)
                        {
                            Music_Life_V11.Properties.Settings.Default.rmbu = metroTextBox1.Text;
                            Music_Life_V11.Properties.Settings.Default.rmbp = metroTextBox2.Text;
                        }
                        Music_Life_V11.Properties.Settings.Default.mainacc = metroTextBox1.Text;
                        Music_Life_V11.Properties.Settings.Default.Save();
                        this.Hide();
                        try
                        {
                            StreamReader cc = new StreamReader(@"usersinfo\data\" + metroTextBox1.Text);
                            if (cc.ReadLine() == "")
                            { Files x = new Files(); x.Show(); }
                            else
                            { Music_Life xx = new Music_Life(); xx.Show(); }
                            cc.Close();
                        }
                        catch
                        {
                            Files x = new Files(); x.Show();
                        }

                    }
                    else
                    { MessageBox.Show("Wrong Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                    r.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            if (user == true)
            {
                metroTextBox1.Text = "";
                user = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {
            if (pass == true)
            {
                metroTextBox2.Text = "";
                metroTextBox2.PasswordChar = '*';
                pass = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Create_New_Account x = new Create_New_Account();
            x.Show();
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {

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

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            aboutus x = new aboutus();
            x.Show();
        }
    }
}
