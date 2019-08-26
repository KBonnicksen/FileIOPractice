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
    public partial class frmImportFile : Form
    {
        /// <summary>
        /// File path of the file being uploaded
        /// </summary>
        private string FilePath = string.Empty;
        public const string TxtFileFilters = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

        public frmImportFile()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Allows the user to upload a file to this project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                InitialDirectory =
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = TxtFileFilters
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = openDialog.FileName;
                txtFilePath.Text = FilePath;
            }
        }

        /// <summary>
        /// If user file path is valid, opens a new window that 
        /// reads the contents of the users file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRead_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(FilePath))
                MessageBox.Show("Please choose a valid text file.");
            else
            {
                Form reader = new frmTextReader(FilePath);
                reader.ShowDialog();
            }
        }
    }
}
