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

namespace FileIOPractice
{
    public partial class frmTextReader : Form
    {
        private readonly string FilePath;
        public frmTextReader(String filePath)
        {
            FilePath = filePath;
            InitializeComponent();
        }

        private void FrmTextReader_Load(object sender, EventArgs e)
        {
            //StreamReader reader = new StreamReader(FilePath);
            //string text = reader.ReadToEnd();
            //lstDataReader.Text = text;

            List<String> textLines = File.ReadLines(FilePath).ToList();
            foreach (string line in textLines)
            {
                lstDataReader.Items.Add(line);
            }
        }
    }
}
