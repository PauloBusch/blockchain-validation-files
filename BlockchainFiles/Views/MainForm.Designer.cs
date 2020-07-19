namespace BlockchainFiles
{
    partial class MainForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnSearchFile = new System.Windows.Forms.Button();
            this.ListFiles = new System.Windows.Forms.ListView();
            this.BtnValidate = new System.Windows.Forms.Button();
            this.BtnViewFiles = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // BtnSearchFile
            // 
            this.BtnSearchFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchFile.Location = new System.Drawing.Point(553, 12);
            this.BtnSearchFile.Name = "BtnSearchFile";
            this.BtnSearchFile.Size = new System.Drawing.Size(226, 58);
            this.BtnSearchFile.TabIndex = 1;
            this.BtnSearchFile.Text = "Buscar arquivo";
            this.BtnSearchFile.UseVisualStyleBackColor = true;
            this.BtnSearchFile.Click += new System.EventHandler(this.BtnSearchFile_Click);
            // 
            // ListFiles
            // 
            this.ListFiles.HideSelection = false;
            this.ListFiles.Location = new System.Drawing.Point(23, 12);
            this.ListFiles.Name = "ListFiles";
            this.ListFiles.Size = new System.Drawing.Size(503, 407);
            this.ListFiles.TabIndex = 3;
            this.ListFiles.UseCompatibleStateImageBehavior = false;
            // 
            // BtnValidate
            // 
            this.BtnValidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnValidate.Location = new System.Drawing.Point(551, 87);
            this.BtnValidate.Name = "BtnValidate";
            this.BtnValidate.Size = new System.Drawing.Size(226, 58);
            this.BtnValidate.TabIndex = 4;
            this.BtnValidate.Text = "Validar Blocos";
            this.BtnValidate.UseVisualStyleBackColor = true;
            this.BtnValidate.Click += new System.EventHandler(this.BtnValidate_Click);
            // 
            // BtnViewFiles
            // 
            this.BtnViewFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnViewFiles.Location = new System.Drawing.Point(551, 361);
            this.BtnViewFiles.Name = "BtnViewFiles";
            this.BtnViewFiles.Size = new System.Drawing.Size(226, 58);
            this.BtnViewFiles.TabIndex = 5;
            this.BtnViewFiles.Text = "Ver Arquivos";
            this.BtnViewFiles.UseVisualStyleBackColor = true;
            this.BtnViewFiles.Click += new System.EventHandler(this.BtnViewFiles_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "OpenFileDialog";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 450);
            this.Controls.Add(this.BtnViewFiles);
            this.Controls.Add(this.BtnValidate);
            this.Controls.Add(this.ListFiles);
            this.Controls.Add(this.BtnSearchFile);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnSearchFile;
        private System.Windows.Forms.ListView ListFiles;
        private System.Windows.Forms.Button BtnValidate;
        private System.Windows.Forms.Button BtnViewFiles;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
    }
}

