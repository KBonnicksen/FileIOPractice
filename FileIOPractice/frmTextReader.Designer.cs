namespace FileIOPractice
{
    partial class frmTextReader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstDataReader = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstDataReader
            // 
            this.lstDataReader.FormattingEnabled = true;
            this.lstDataReader.ItemHeight = 16;
            this.lstDataReader.Location = new System.Drawing.Point(0, 0);
            this.lstDataReader.Name = "lstDataReader";
            this.lstDataReader.Size = new System.Drawing.Size(801, 452);
            this.lstDataReader.TabIndex = 0;
            // 
            // frmTextReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstDataReader);
            this.Name = "frmTextReader";
            this.Text = "frmTextReader";
            this.Load += new System.EventHandler(this.FrmTextReader_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstDataReader;
    }
}