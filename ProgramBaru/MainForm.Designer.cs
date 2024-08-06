namespace ProgramBaru
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            downloadButton = new Button();
            label1 = new Label();
            inputUrl = new TextBox();
            label2 = new Label();
            fileNameInput = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // downloadButton
            // 
            downloadButton.Anchor = AnchorStyles.Right;
            downloadButton.AutoSize = true;
            downloadButton.Location = new Point(608, 203);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(120, 40);
            downloadButton.TabIndex = 0;
            downloadButton.Text = "Download";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += button1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26F);
            label1.Location = new Point(88, 50);
            label1.Name = "label1";
            label1.Size = new Size(584, 60);
            label1.TabIndex = 1;
            label1.Text = "Pendownload File Sederhana";
            // 
            // inputUrl
            // 
            inputUrl.Location = new Point(143, 210);
            inputUrl.Name = "inputUrl";
            inputUrl.Size = new Size(438, 27);
            inputUrl.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(69, 213);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 3;
            label2.Text = "URL: ";
            // 
            // fileNameInput
            // 
            fileNameInput.Location = new Point(143, 268);
            fileNameInput.Name = "fileNameInput";
            fileNameInput.Size = new Size(87, 27);
            fileNameInput.TabIndex = 4;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(43, 271);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 5;
            label3.Text = "Nama File: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(fileNameInput);
            Controls.Add(label2);
            Controls.Add(inputUrl);
            Controls.Add(label1);
            Controls.Add(downloadButton);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            RightToLeftLayout = true;
            Text = "Made by Aran8276 / Zahran SMKN6 Malang";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button downloadButton;
        private Label label1;
        private TextBox inputUrl;
        private Label label2;
        private TextBox fileNameInput;
        private Label label3;
    }
}
