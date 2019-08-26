﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileIOPractice
{
    public partial class frmSaveNewFile : Form
    {
        //I have this on two of my forms, how would you handle this?
        //Pass it through the forms?
        public const string TxtFileFilters = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        private string FilePath;

        public frmSaveNewFile(string message, string fileName)
        {
            InitializeComponent();
            lblMessage.Text = message;
            FilePath = fileName;
        }

        private void FrmSaveNewFile_Load(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Filter = TxtFileFilters,
                RestoreDirectory = true
            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveDialog.FileName;

            }
        }
    }
}
