namespace VigenereCracker
{
    partial class VigenereCracker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VigenereCracker));
            this.tbUserInput = new System.Windows.Forms.TextBox();
            this.btnEncryptCaesar = new System.Windows.Forms.Button();
            this.gbCaesar = new System.Windows.Forms.GroupBox();
            this.lKeyCaesar = new System.Windows.Forms.Label();
            this.nuKeyCaesar = new System.Windows.Forms.NumericUpDown();
            this.btnBreakCaesar = new System.Windows.Forms.Button();
            this.btnDecryptCaesar = new System.Windows.Forms.Button();
            this.lLanguageCaesar = new System.Windows.Forms.Label();
            this.cbbLanguage = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.gbVigenere = new System.Windows.Forms.GroupBox();
            this.btnFindKeyValueChart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nuKeyLenghtVigenere = new System.Windows.Forms.NumericUpDown();
            this.btnFindKeyValueAuto = new System.Windows.Forms.Button();
            this.tbKeyVigenere = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBreakVigenere = new System.Windows.Forms.Button();
            this.btnDecryptVigenere = new System.Windows.Forms.Button();
            this.btnEncryptVigenere = new System.Windows.Forms.Button();
            this.lTitleInput = new System.Windows.Forms.Label();
            this.lTitleOutput = new System.Windows.Forms.Label();
            this.tbUserOutput = new System.Windows.Forms.TextBox();
            this.btnOutputToInput = new System.Windows.Forms.Button();
            this.gbCaesar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuKeyCaesar)).BeginInit();
            this.gbVigenere.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuKeyLenghtVigenere)).BeginInit();
            this.SuspendLayout();
            // 
            // tbUserInput
            // 
            this.tbUserInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserInput.Location = new System.Drawing.Point(12, 41);
            this.tbUserInput.Multiline = true;
            this.tbUserInput.Name = "tbUserInput";
            this.tbUserInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbUserInput.Size = new System.Drawing.Size(470, 230);
            this.tbUserInput.TabIndex = 0;
            this.tbUserInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUserInput_KeyPress);
            // 
            // btnEncryptCaesar
            // 
            this.btnEncryptCaesar.Location = new System.Drawing.Point(203, 19);
            this.btnEncryptCaesar.Name = "btnEncryptCaesar";
            this.btnEncryptCaesar.Size = new System.Drawing.Size(81, 35);
            this.btnEncryptCaesar.TabIndex = 2;
            this.btnEncryptCaesar.Text = "Encrypt";
            this.btnEncryptCaesar.UseVisualStyleBackColor = true;
            this.btnEncryptCaesar.Click += new System.EventHandler(this.btnEncryptCaesar_Click);
            // 
            // gbCaesar
            // 
            this.gbCaesar.Controls.Add(this.lKeyCaesar);
            this.gbCaesar.Controls.Add(this.nuKeyCaesar);
            this.gbCaesar.Controls.Add(this.btnBreakCaesar);
            this.gbCaesar.Controls.Add(this.btnDecryptCaesar);
            this.gbCaesar.Controls.Add(this.btnEncryptCaesar);
            this.gbCaesar.Location = new System.Drawing.Point(12, 295);
            this.gbCaesar.Name = "gbCaesar";
            this.gbCaesar.Size = new System.Drawing.Size(466, 73);
            this.gbCaesar.TabIndex = 3;
            this.gbCaesar.TabStop = false;
            this.gbCaesar.Text = "Caesar Cipher";
            // 
            // lKeyCaesar
            // 
            this.lKeyCaesar.Location = new System.Drawing.Point(15, 29);
            this.lKeyCaesar.Name = "lKeyCaesar";
            this.lKeyCaesar.Size = new System.Drawing.Size(39, 19);
            this.lKeyCaesar.TabIndex = 6;
            this.lKeyCaesar.Text = "Key : ";
            this.lKeyCaesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nuKeyCaesar
            // 
            this.nuKeyCaesar.Location = new System.Drawing.Point(60, 28);
            this.nuKeyCaesar.Maximum = new decimal(new int[] {
            28,
            0,
            0,
            0});
            this.nuKeyCaesar.Name = "nuKeyCaesar";
            this.nuKeyCaesar.Size = new System.Drawing.Size(71, 20);
            this.nuKeyCaesar.TabIndex = 5;
            this.nuKeyCaesar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBreakCaesar
            // 
            this.btnBreakCaesar.Location = new System.Drawing.Point(377, 19);
            this.btnBreakCaesar.Name = "btnBreakCaesar";
            this.btnBreakCaesar.Size = new System.Drawing.Size(81, 35);
            this.btnBreakCaesar.TabIndex = 4;
            this.btnBreakCaesar.Text = "Break";
            this.btnBreakCaesar.UseVisualStyleBackColor = true;
            this.btnBreakCaesar.Click += new System.EventHandler(this.btnBreakCaesar_Click);
            // 
            // btnDecryptCaesar
            // 
            this.btnDecryptCaesar.Location = new System.Drawing.Point(290, 19);
            this.btnDecryptCaesar.Name = "btnDecryptCaesar";
            this.btnDecryptCaesar.Size = new System.Drawing.Size(81, 35);
            this.btnDecryptCaesar.TabIndex = 3;
            this.btnDecryptCaesar.Text = "Decrypt";
            this.btnDecryptCaesar.UseVisualStyleBackColor = true;
            this.btnDecryptCaesar.Click += new System.EventHandler(this.btnDecryptCaesar_Click);
            // 
            // lLanguageCaesar
            // 
            this.lLanguageCaesar.Location = new System.Drawing.Point(13, 526);
            this.lLanguageCaesar.Name = "lLanguageCaesar";
            this.lLanguageCaesar.Size = new System.Drawing.Size(78, 19);
            this.lLanguageCaesar.TabIndex = 7;
            this.lLanguageCaesar.Text = "Language : ";
            this.lLanguageCaesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbLanguage
            // 
            this.cbbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLanguage.FormattingEnabled = true;
            this.cbbLanguage.Items.AddRange(new object[] {
            "English",
            "French",
            "Swedish"});
            this.cbbLanguage.Location = new System.Drawing.Point(96, 526);
            this.cbbLanguage.Name = "cbbLanguage";
            this.cbbLanguage.Size = new System.Drawing.Size(194, 21);
            this.cbbLanguage.TabIndex = 8;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(376, 518);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 35);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // gbVigenere
            // 
            this.gbVigenere.Controls.Add(this.btnFindKeyValueChart);
            this.gbVigenere.Controls.Add(this.label3);
            this.gbVigenere.Controls.Add(this.label2);
            this.gbVigenere.Controls.Add(this.nuKeyLenghtVigenere);
            this.gbVigenere.Controls.Add(this.btnFindKeyValueAuto);
            this.gbVigenere.Controls.Add(this.tbKeyVigenere);
            this.gbVigenere.Controls.Add(this.label1);
            this.gbVigenere.Controls.Add(this.btnBreakVigenere);
            this.gbVigenere.Controls.Add(this.btnDecryptVigenere);
            this.gbVigenere.Controls.Add(this.btnEncryptVigenere);
            this.gbVigenere.Location = new System.Drawing.Point(16, 387);
            this.gbVigenere.Name = "gbVigenere";
            this.gbVigenere.Size = new System.Drawing.Size(466, 117);
            this.gbVigenere.TabIndex = 10;
            this.gbVigenere.TabStop = false;
            this.gbVigenere.Text = "Vigenère Cipher";
            // 
            // btnFindKeyValueChart
            // 
            this.btnFindKeyValueChart.Image = ((System.Drawing.Image)(resources.GetObject("btnFindKeyValueChart.Image")));
            this.btnFindKeyValueChart.Location = new System.Drawing.Point(416, 70);
            this.btnFindKeyValueChart.Name = "btnFindKeyValueChart";
            this.btnFindKeyValueChart.Size = new System.Drawing.Size(38, 35);
            this.btnFindKeyValueChart.TabIndex = 13;
            this.btnFindKeyValueChart.UseVisualStyleBackColor = true;
            this.btnFindKeyValueChart.Click += new System.EventHandler(this.btnFindKeyValueChart_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(278, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Find key value : ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(117, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Key length : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nuKeyLenghtVigenere
            // 
            this.nuKeyLenghtVigenere.Location = new System.Drawing.Point(199, 79);
            this.nuKeyLenghtVigenere.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuKeyLenghtVigenere.Name = "nuKeyLenghtVigenere";
            this.nuKeyLenghtVigenere.Size = new System.Drawing.Size(71, 20);
            this.nuKeyLenghtVigenere.TabIndex = 10;
            this.nuKeyLenghtVigenere.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nuKeyLenghtVigenere.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuKeyLenghtVigenere.ValueChanged += new System.EventHandler(this.nuKeyLenghtVigenere_ValueChanged);
            // 
            // btnFindKeyValueAuto
            // 
            this.btnFindKeyValueAuto.Location = new System.Drawing.Point(373, 70);
            this.btnFindKeyValueAuto.Name = "btnFindKeyValueAuto";
            this.btnFindKeyValueAuto.Size = new System.Drawing.Size(38, 35);
            this.btnFindKeyValueAuto.TabIndex = 8;
            this.btnFindKeyValueAuto.Text = "Auto";
            this.btnFindKeyValueAuto.UseVisualStyleBackColor = true;
            this.btnFindKeyValueAuto.Click += new System.EventHandler(this.btnFindKeyValueAuto_Click);
            // 
            // tbKeyVigenere
            // 
            this.tbKeyVigenere.Location = new System.Drawing.Point(54, 27);
            this.tbKeyVigenere.Name = "tbKeyVigenere";
            this.tbKeyVigenere.Size = new System.Drawing.Size(129, 20);
            this.tbKeyVigenere.TabIndex = 7;
            this.tbKeyVigenere.TextChanged += new System.EventHandler(this.tbKeyVigenere_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Key : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBreakVigenere
            // 
            this.btnBreakVigenere.Location = new System.Drawing.Point(14, 70);
            this.btnBreakVigenere.Name = "btnBreakVigenere";
            this.btnBreakVigenere.Size = new System.Drawing.Size(97, 35);
            this.btnBreakVigenere.TabIndex = 4;
            this.btnBreakVigenere.Text = "Find key length";
            this.btnBreakVigenere.UseVisualStyleBackColor = true;
            this.btnBreakVigenere.Click += new System.EventHandler(this.btnFindVigenereKeyLength_Click);
            // 
            // btnDecryptVigenere
            // 
            this.btnDecryptVigenere.Location = new System.Drawing.Point(286, 19);
            this.btnDecryptVigenere.Name = "btnDecryptVigenere";
            this.btnDecryptVigenere.Size = new System.Drawing.Size(81, 35);
            this.btnDecryptVigenere.TabIndex = 3;
            this.btnDecryptVigenere.Text = "Decrypt";
            this.btnDecryptVigenere.UseVisualStyleBackColor = true;
            this.btnDecryptVigenere.Click += new System.EventHandler(this.btnDecryptVigenere_Click);
            // 
            // btnEncryptVigenere
            // 
            this.btnEncryptVigenere.Location = new System.Drawing.Point(199, 19);
            this.btnEncryptVigenere.Name = "btnEncryptVigenere";
            this.btnEncryptVigenere.Size = new System.Drawing.Size(81, 35);
            this.btnEncryptVigenere.TabIndex = 2;
            this.btnEncryptVigenere.Text = "Encrypt";
            this.btnEncryptVigenere.UseVisualStyleBackColor = true;
            this.btnEncryptVigenere.Click += new System.EventHandler(this.btnEncryptVigenere_Click);
            // 
            // lTitleInput
            // 
            this.lTitleInput.AutoSize = true;
            this.lTitleInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitleInput.Location = new System.Drawing.Point(12, 14);
            this.lTitleInput.Name = "lTitleInput";
            this.lTitleInput.Size = new System.Drawing.Size(68, 24);
            this.lTitleInput.TabIndex = 12;
            this.lTitleInput.Text = "Input :";
            // 
            // lTitleOutput
            // 
            this.lTitleOutput.AutoSize = true;
            this.lTitleOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitleOutput.Location = new System.Drawing.Point(508, 14);
            this.lTitleOutput.Name = "lTitleOutput";
            this.lTitleOutput.Size = new System.Drawing.Size(84, 24);
            this.lTitleOutput.TabIndex = 13;
            this.lTitleOutput.Text = "Output :";
            // 
            // tbUserOutput
            // 
            this.tbUserOutput.BackColor = System.Drawing.SystemColors.Window;
            this.tbUserOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserOutput.Location = new System.Drawing.Point(510, 41);
            this.tbUserOutput.Multiline = true;
            this.tbUserOutput.Name = "tbUserOutput";
            this.tbUserOutput.ReadOnly = true;
            this.tbUserOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbUserOutput.Size = new System.Drawing.Size(470, 513);
            this.tbUserOutput.TabIndex = 11;
            this.tbUserOutput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUserInput_KeyPress);
            // 
            // btnOutputToInput
            // 
            this.btnOutputToInput.Location = new System.Drawing.Point(483, 118);
            this.btnOutputToInput.Name = "btnOutputToInput";
            this.btnOutputToInput.Size = new System.Drawing.Size(25, 71);
            this.btnOutputToInput.TabIndex = 14;
            this.btnOutputToInput.UseVisualStyleBackColor = true;
            this.btnOutputToInput.Click += new System.EventHandler(this.btnOutputToInput_Click);
            // 
            // VigenereCracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.btnOutputToInput);
            this.Controls.Add(this.lTitleOutput);
            this.Controls.Add(this.lTitleInput);
            this.Controls.Add(this.tbUserOutput);
            this.Controls.Add(this.gbVigenere);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cbbLanguage);
            this.Controls.Add(this.lLanguageCaesar);
            this.Controls.Add(this.gbCaesar);
            this.Controls.Add(this.tbUserInput);
            this.Name = "VigenereCracker";
            this.Text = "Vigenère Cracker Tool";
            this.Load += new System.EventHandler(this.VigenereCracker_Load);
            this.gbCaesar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nuKeyCaesar)).EndInit();
            this.gbVigenere.ResumeLayout(false);
            this.gbVigenere.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuKeyLenghtVigenere)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUserInput;
        private System.Windows.Forms.Button btnEncryptCaesar;
        private System.Windows.Forms.GroupBox gbCaesar;
        private System.Windows.Forms.ComboBox cbbLanguage;
        private System.Windows.Forms.Label lLanguageCaesar;
        private System.Windows.Forms.Label lKeyCaesar;
        private System.Windows.Forms.NumericUpDown nuKeyCaesar;
        private System.Windows.Forms.Button btnBreakCaesar;
        private System.Windows.Forms.Button btnDecryptCaesar;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox gbVigenere;
        private System.Windows.Forms.TextBox tbKeyVigenere;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBreakVigenere;
        private System.Windows.Forms.Button btnDecryptVigenere;
        private System.Windows.Forms.Button btnEncryptVigenere;
        private System.Windows.Forms.Label lTitleInput;
        private System.Windows.Forms.Label lTitleOutput;
        private System.Windows.Forms.TextBox tbUserOutput;
        private System.Windows.Forms.Button btnOutputToInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nuKeyLenghtVigenere;
        private System.Windows.Forms.Button btnFindKeyValueAuto;
        private Label label3;
        private Button btnFindKeyValueChart;

    }
}

