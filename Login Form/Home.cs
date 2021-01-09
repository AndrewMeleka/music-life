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
    public partial class Files : MetroFramework.Forms.MetroForm
    {
        public Files()
        {
            InitializeComponent(); StyleManager = metroStyleManager1;
        }

        private void Home_Load(object sender, EventArgs e)
        {
             metroLabel2.Text = "Welcome : "+Music_Life_V11.Properties.Settings.Default.mainacc;
                List<string> lines = new List<string>();
                using (StreamReader r = new StreamReader(@"usersinfo\data\" + Music_Life_V11.Properties.Settings.Default.mainacc))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        lines.Add(line);
                                    listBox1.Items.Add(line);
                                }


                            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(folderBrowserDialog1.SelectedPath);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                while (listBox1.SelectedIndex != -1)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(openFileDialog1.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(@"usersinfo\data\"+Music_Life_V11.Properties.Settings.Default.mainacc);
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }
            SaveFile.Close();
            Music_Life_V10.Music_Life a = new Music_Life_V10.Music_Life();
            a.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBoxAdv1_DragDrop(object sender, DragEventArgs e)
        {
           
        }
        private void listBoxAdv1_DragEnter(object sender, DragEventArgs e)
        {
           
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            List<string> filepaths = new List<string>();
            foreach (var s in (string[])e.Data.GetData(DataFormats.FileDrop, false))
            {
                if (Directory.Exists(s))
                {
                    //Add files from folder
                    filepaths.AddRange(Directory.GetFiles(s));
                }
                else
                {
                    //Add filepath
                    filepaths.Add(s);
                }
            }
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(folderBrowserDialog1.SelectedPath);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                while (listBox1.SelectedIndex != -1)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(@"usersinfo\data\" + Music_Life_V11.Properties.Settings.Default.mainacc);
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }
            SaveFile.Close();
            Music_Life_V10.Music_Life a = new Music_Life_V10.Music_Life();
            a.Show();
            this.Close();
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

        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(@"usersinfo\data\" + Music_Life_V11.Properties.Settings.Default.mainacc);
            foreach (var item in listBox1.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }
            SaveFile.Close();
            Music_Life_V10.Music_Life a = new Music_Life_V10.Music_Life();
            a.Show();
            this.Close();
        }
    }
}
