using System;
using System.Windows.Forms;
using System.IO; //File operations

namespace ComputerCleanup
{
    public partial class Form1 : Form
    {
        int FileRemoved;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteTemporaryFiles();
        }

        private void DeleteTemporaryFiles()
        {
            DirectoryInfo directory = new DirectoryInfo(Path.GetTempPath());

            foreach (FileInfo file in directory.GetFiles())
            {
                try
                {
                    file.Delete();
                    FileRemoved++;
                }
                catch { }
            }

            foreach (DirectoryInfo directory2 in directory.GetDirectories())
            {
                try
                {
                    directory2.Delete(true);
                    FileRemoved++;
                }
                catch { }
            }

            MessageBox.Show($"Removed {FileRemoved} Files and Directories!");
        }
    }
}
