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

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            File.Encrypt(FilePath);
            MessageBox.Show("Your file has been encrypted.", "Would you like to save its contents to a new file?");
            //OpenSaveForm("Your file has been successfully Encrypted");
        }


        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            File.Decrypt(FilePath);
            //OpenSaveForm("Your file has been successfully Decrypted");
        }

        private static void OpenSaveForm(string message)
        {
            //Form saveYesNo = new frmSaveNewFile(message, FilePath);
            //saveYesNo.ShowDialog();
            //ActiveForm.Dispose();
        }
    }
}
