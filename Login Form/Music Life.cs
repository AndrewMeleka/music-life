using Login_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music_Life_V10
{
    public partial class Music_Life : MetroFramework.Forms.MetroForm
    {
        public Music_Life()
        {
            InitializeComponent(); StyleManager = metroStyleManager1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Files x = new Files();
            x.Show();
        }
        public void colorsbutton()
        {
        }
        public void textcolor()
        {
            label1.ForeColor = Music_Life_V11.Properties.Settings.Default.t;
            lmstate.ForeColor = Music_Life_V11.Properties.Settings.Default.t;
            label2.ForeColor = Music_Life_V11.Properties.Settings.Default.t;
            listBox1.ForeColor = Music_Life_V11.Properties.Settings.Default.t;
        }
        public void back()
        {



        }



        private void Music_Life_Load(object sender, EventArgs e)
        {
            if (Music_Life_V11.Properties.Settings.Default.theme == "dark")
            {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                pictureBox1.Visible = false; pictureBox2.Visible = true;
                listBox1.BackColor = Color.FromArgb(17, 17, 17);
                listBox1.ForeColor = Color.FromArgb(0, 174, 219);
            }
            else if (Music_Life_V11.Properties.Settings.Default.theme == "light")
            {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
                pictureBox1.Visible = true; pictureBox2.Visible = false;
                listBox1.BackColor = Color.FromArgb(255, 255, 255);
                listBox1.ForeColor = Color.FromArgb(0, 174, 219);
            }
            colorsbutton(); back(); textcolor();
            try
            {
                int NumMusic = 0;
                var fileLines = System.IO.File.ReadAllLines(@"usersinfo\data\" + Music_Life_V11.Properties.Settings.Default.mainacc);
                foreach (var singleLine in fileLines)
                {
                    string[] files = Directory.GetFiles(singleLine + "\\");
                    foreach (string file in files)
                    {
                        var checkingExte = Path.GetExtension(file);
                        if (string.Equals(checkingExte, ".mp3", StringComparison.CurrentCultureIgnoreCase) || string.Equals(checkingExte, ".wav", StringComparison.CurrentCultureIgnoreCase) || string.Equals(checkingExte, ".mp4", StringComparison.CurrentCultureIgnoreCase))
                        {
                            listBox1.Items.Add(Path.GetFileNameWithoutExtension(file));
                            NumMusic += 1;
                        }

                    }
                }
                label1.Text = "Total Music : " + NumMusic + " /";
            }
            catch
            {
                MessageBox.Show("There was problem in files path please check it and try again");
                Files x = new Files();
                x.Show();
                this.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button4_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
        bool t = true;
        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fileLines = System.IO.File.ReadAllLines(@"usersinfo\data\" + Music_Life_V11.Properties.Settings.Default.mainacc);
            listBox2.Items.Clear();

            foreach (var line in fileLines)
            {
                listBox2.Items.Add(line + "\\" + listBox1.SelectedItem.ToString());

            }



        }

        private void button9_Click(object sender, EventArgs e)
        {
            Files x = new Files();
            x.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            lmstate.Text = "Music state : Auto Play Music";
            MessageBox.Show("Auto Play Music working");
        }
        bool x = true;
        private void button14_Click(object sender, EventArgs e)
        {

        }
        bool b = true;
        private void button11_Click(object sender, EventArgs e)
        {
            if (b == true)
            {
                if(listBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Select music first");
                }
                else
                {
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    listBox1.Enabled = false;
                    numericUpDown1.Enabled = false;
                    lmstate.Text = "Music state : Repeat Music";
                    MessageBox.Show("Repeat Music working now \\ number : " + numericUpDown1.Value);
                    label2.Visible = true;
                    label3.Text = numericUpDown1.Value.ToString();
                    label2.Text = ("Repeat Number : " + label3.Text);
                    button11.Text = "Stop";
                    b = false;
                }
                   
            }
            else if (b == false)
            {
                label2.Visible = false;
                label3.Text = "0";

                numericUpDown1.Enabled = true;
                button11.Text = "OK";
                lmstate.Text = "Music state : Normal";
                MessageBox.Show("Repeat Music Stopped");
                listBox1.Enabled = true;
                b = true;
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("File Will Delete", "Delete File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                File.Delete(listBox1.SelectedItem.ToString());
            }



        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                timer1.Enabled = true;
            }
        }
        int num;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lmstate.Text == "Music state : Auto Play Music")
            {
                try
                {
                    listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
                    var fileLines = System.IO.File.ReadAllLines(@"usersinfo\data\" + Music_Life_V11.Properties.Settings.Default.mainacc);
                    listBox2.Items.Clear();
                    foreach (var line in fileLines)
                    {
                        listBox2.Items.Add(line + "\\" + listBox1.SelectedItem.ToString());

                        if (File.Exists(line + "\\" + listBox1.SelectedItem.ToString()))
                        {
                            listBox2.SelectedItem = (line + "\\" + listBox1.SelectedItem.ToString());
                            axWindowsMediaPlayer1.URL = (line + "\\" + listBox1.SelectedItem.ToString());
                        }

                    }




                    timer1.Enabled = false;

                }
                catch
                {
                    listBox1.SelectedIndex = (0);
                    axWindowsMediaPlayer1.URL = listBox1.SelectedItem.ToString();
                    timer1.Enabled = false;
                }
            }
            else if (lmstate.Text == "Music state : Last Music")
            {
                Application.Exit();
            }
            else if (lmstate.Text == "Music state : Repeat Music")
            {
                if (label3.Text == "1")
                {
                    label3.Visible = false; label2.Visible = false;
                    label3.Text = "0";
                    numericUpDown1.Enabled = true;
                    button11.Text = "OK";
                    lmstate.Text = "Music state : Normal";
                    MessageBox.Show("Repeat Music Stopped");
                    listBox1.Enabled = true;

                    timer1.Enabled = false;
                    b = true;
                }
                else
                {
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    num = Convert.ToInt32(label3.Text);
                    num -= 1;
                    label3.Text = num.ToString();
                    label2.Text = ("Repeat Number : " + label3.Text);
                    timer1.Enabled = false;
                    b = true;
                }

            }
        }
        bool y = true;
        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            if (MyDialog.ShowDialog() == DialogResult.OK)
                label1.ForeColor = MyDialog.Color;
            lmstate.ForeColor = MyDialog.Color;
            label2.ForeColor = MyDialog.Color;
            listBox1.ForeColor = MyDialog.Color;
            Music_Life_V11.Properties.Settings.Default.t = MyDialog.Color;
            Music_Life_V11.Properties.Settings.Default.Save();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)

                Music_Life_V11.Properties.Settings.Default.bt = colorDialog2.Color;
            Music_Life_V11.Properties.Settings.Default.Save();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)

                Music_Life_V11.Properties.Settings.Default.bcc = colorDialog2.Color;
            Music_Life_V11.Properties.Settings.Default.Save();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Color bc = ColorTranslator.FromHtml("#1A97EA");
            Color b = ColorTranslator.FromHtml("#ECF0F1");
            Color bt = ColorTranslator.FromHtml("#2D2D2E");
            Color bcc = ColorTranslator.FromHtml("#2D2D2E");
            Music_Life_V11.Properties.Settings.Default.bc = bc;
            Music_Life_V11.Properties.Settings.Default.t = bc;
            Music_Life_V11.Properties.Settings.Default.bt = bt;
            Music_Life_V11.Properties.Settings.Default.bcc = bcc;
            Music_Life_V11.Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }
        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {


        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            try
            {
                var fileLines = System.IO.File.ReadAllLines(@"usersinfo\data\" + Music_Life_V11.Properties.Settings.Default.mainacc);
                foreach (var singleLine in fileLines)
                {
                    string[] files = Directory.GetFiles(singleLine + "\\");
                    foreach (string file in files)
                    {
                        listBox1.Items.Add(Path.GetFileName(file));
                    }
                }
            }
            catch
            {
                MessageBox.Show("There was problem in files path please check it and try again");
                Files x = new Files();
                x.Show();
                this.Close();
            }

        }

        private void ptool_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            pictureBox1.Visible = false; pictureBox2.Visible = true;
            Music_Life_V11.Properties.Settings.Default.theme = "dark";
            Music_Life_V11.Properties.Settings.Default.Save();
            listBox1.BackColor = Color.FromArgb(17, 17, 17); listBox1.ForeColor = Color.FromArgb(0, 174, 219);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            pictureBox1.Visible = true; pictureBox2.Visible = false;
            Music_Life_V11.Properties.Settings.Default.theme = "light";
            Music_Life_V11.Properties.Settings.Default.Save();
            listBox1.BackColor = Color.FromArgb(255, 255, 255);
            listBox1.ForeColor = Color.FromArgb(0, 174, 219);
        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void metroScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (x == true)
            {
                panel3.Visible = true;
                x = false;
            }
            else if (x == false)
            {
                panel3.Visible = false;
                x = true;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            lmstate.Text = "Music state : Last Music";
            MessageBox.Show("Last Music working");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (lmstate.Text == "Music state : Auto Play Music")
            {
                lmstate.Text = " Music state : Normal";
                MessageBox.Show("Auto Play Music Stopped");
                metroButton1.Text = "Auto Play Music";
            }
            else
            {
                lmstate.Text = "Music state : Auto Play Music";
                MessageBox.Show("Auto Play Music working");
                metroButton1.Text = "Stop Auto Play Music";
            }

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Files x = new Files();
            x.Show();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void metroButton5_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = (listBox2.SelectedItem.ToString());
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            var fileLines = System.IO.File.ReadAllLines(@"usersinfo\data\" + Music_Life_V11.Properties.Settings.Default.mainacc);
            listBox2.Items.Clear();

            foreach (var line in fileLines)
            {
                listBox2.Items.Add(line + "\\" + listBox1.SelectedItem.ToString());

                if (File.Exists(line + "\\" + listBox1.SelectedItem.ToString() + ".mp3"))
                {
                    listBox2.SelectedItem = (line + "\\" + listBox1.SelectedItem.ToString() + ".mp3");
                    axWindowsMediaPlayer1.URL = (line + "\\" + listBox1.SelectedItem.ToString() + ".mp3");

                }
                else if (File.Exists(line + "\\" + listBox1.SelectedItem.ToString() + ".wav"))
                {
                    listBox2.SelectedItem = (line + "\\" + listBox1.SelectedItem.ToString() + ".wav");
                    axWindowsMediaPlayer1.URL = (line + "\\" + listBox1.SelectedItem.ToString() + ".wav");
                } else if(File.Exists(line + "\\" + listBox1.SelectedItem.ToString() + ".mp4"))
                {
                    listBox2.SelectedItem = (line + "\\" + listBox1.SelectedItem.ToString() + ".mp4");
                    axWindowsMediaPlayer1.URL = (line + "\\" + listBox1.SelectedItem.ToString() + ".mp4");
                }

            }

        }

        private void axWindowsMediaPlayer1_PlayStateChange_1(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                timer1.Enabled = true;
            }
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            int index = listBox1.FindString(this.metroTextBox1.Text);
            if (0 <= index)
            {
                listBox1.SelectedIndex = index;
            }
        }

        private void axWindowsMediaPlayer1_PlayStateChange_2(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                timer1.Enabled = true;
            }
        }

        private void Music_Life_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
