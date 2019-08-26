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

        //I have this on two of my forms, how would you handle this?
        //Pass it through the forms?
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

        private void ReadFileInfo()
        {
            List<String> textLines = File.ReadLines(FilePath).ToList();
            foreach (string line in textLines)
            {
                lstDataReader.Items.Add(line);
            }
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            File.Encrypt(FilePath);
            //StringBuilder encryptedData = new StringBuilder();
            FileAttributes attributes = File.GetAttributes(FilePath);
            if((attributes & FileAttributes.Encrypted) == FileAttributes.Encrypted)
                MessageBox.Show("Tester: these are encrypted");
           

            string encryptedData = File.ReadAllText(FilePath);


            // TODO: Validate that it was encrypted

            SaveNewFile("Successfully encrypted.", encryptedData);
        }

        private void SaveNewFile(String caption, string altData)
        {
            var result = MessageBox.Show(this, "Would you like to save this content to a new file?", caption, MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                SaveFileDialog saveDialog = new SaveFileDialog()
                {
                    Filter = TxtFileFilters,
                    RestoreDirectory = true
                };
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveDialog.FileName;
                    File.WriteAllText(savePath, altData);
                }
            }
            else
            {
                // "would you like to upload another file?
                // Redirect or just close program
            }
        }

        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            File.Decrypt(FilePath);

            string decryptedData = File.ReadAllText(FilePath);
            // TODO: Validate that it was encrypted

            SaveNewFile("Successfully decrypted.", decryptedData);
        }
    }
}
