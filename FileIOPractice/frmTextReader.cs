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
        public const string TxtFileFilters = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        private readonly string FilePath;

        public frmTextReader(String filePath)
        {
            FilePath = filePath;
            InitializeComponent();
        }

        private void FrmTextReader_Load(object sender, EventArgs e)
        {
            ReadFileInfo();
        }

        /// <summary>
        /// Reads text from a file and adds each line to lstDataReader
        /// </summary>
        private void ReadFileInfo()
        {
            List<String> textLines = File.ReadLines(FilePath).ToList();
            foreach (string line in textLines)
            {
                lstDataReader.Items.Add(line);
            }
        }

        /// <summary>
        /// Verifies that the file is not already encrypted.
        /// If not yet encrypted, file is encrypted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            FileAttributes attributes = File.GetAttributes(FilePath);
            if((attributes & FileAttributes.Encrypted) == FileAttributes.Encrypted)
                MessageBox.Show("File is already encrypted.");
            else
            {
                File.Encrypt(FilePath);
                
                SaveNewFile("Successfully encrypted.");
            }
        }

        /// <summary>
        /// If wanted by user, changed file contents are saved to a new 
        /// file of the users choosing
        /// </summary>
        /// <param name="caption"></param>
        private void SaveNewFile(String caption)
        {
            var result = MessageBox.Show(this, "Would you like to save this content to a new file?", caption, MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string alteredData = File.ReadAllText(FilePath);
                SaveFileDialog saveDialog = new SaveFileDialog()
                {
                    Filter = TxtFileFilters,
                    RestoreDirectory = true
                };
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveDialog.FileName;
                    File.WriteAllText(savePath, alteredData);
                    File.Encrypt(savePath);
                }
            }
            ImportAnotherFile();
        }

        /// <summary>
        /// Asks user if an additional file is needed to be uploaded.
        /// If yes, user is redirected to Form frmImportFile
        /// </summary>
        private void ImportAnotherFile()
        {
            var yesNo = MessageBox.Show("Would you like to upload another file?", string.Empty, MessageBoxButtons.YesNo);

            if (yesNo == DialogResult.Yes)
            {
                Form initForm = new frmImportFile();
                this.Dispose();

                initForm.ShowDialog();
            }
        }

        /// <summary>
        /// Decrypts file if file is encrypted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            FileAttributes attributes = File.GetAttributes(FilePath);

            if ((attributes & FileAttributes.Encrypted) == FileAttributes.Encrypted)
            {
                File.Decrypt(FilePath);
                string decryptedData = File.ReadAllText(FilePath);
                SaveNewFile("Successfully decrypted.");
            }
            else
            {
                MessageBox.Show("This file is not encrypted.");
            }
        }
    }
}
