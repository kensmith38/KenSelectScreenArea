namespace KenSmithConsulting.KenSelectScreenAreaBase
{
    partial class TransparentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransparentForm));
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelInformation2 = new System.Windows.Forms.Label();
            this.ButtonBegin = new System.Windows.Forms.Button();
            this.TitleLine = new System.Windows.Forms.Label();
            this.labelInformation = new System.Windows.Forms.Label();
            this.checkBoxDisplayCoordinates = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(48, 55);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(69, 13);
            this.labelVersion.TabIndex = 23;
            this.labelVersion.Text = "Version 1.1.1";
            // 
            // labelInformation2
            // 
            this.labelInformation2.AutoSize = true;
            this.labelInformation2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInformation2.ForeColor = System.Drawing.Color.Blue;
            this.labelInformation2.Location = new System.Drawing.Point(183, 249);
            this.labelInformation2.Name = "labelInformation2";
            this.labelInformation2.Size = new System.Drawing.Size(413, 48);
            this.labelInformation2.TabIndex = 22;
            this.labelInformation2.Text = "After you begin and see the transparent window you can:\r\n    - double-click insid" +
    "e the transparent window to finalize the selection\r\n    - press the \"esc\" key on" +
    " your keyboard to cancel the selection";
            // 
            // ButtonBegin
            // 
            this.ButtonBegin.Location = new System.Drawing.Point(91, 260);
            this.ButtonBegin.Name = "ButtonBegin";
            this.ButtonBegin.Size = new System.Drawing.Size(75, 23);
            this.ButtonBegin.TabIndex = 21;
            this.ButtonBegin.Text = "Begin";
            this.ButtonBegin.UseVisualStyleBackColor = true;
            this.ButtonBegin.Click += new System.EventHandler(this.ButtonBegin_Click);
            // 
            // TitleLine
            // 
            this.TitleLine.AutoSize = true;
            this.TitleLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLine.Location = new System.Drawing.Point(47, 31);
            this.TitleLine.Name = "TitleLine";
            this.TitleLine.Size = new System.Drawing.Size(363, 24);
            this.TitleLine.TabIndex = 20;
            this.TitleLine.Text = "Ken Smith Consulting: Select Screen Area";
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInformation.Location = new System.Drawing.Point(48, 74);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(719, 112);
            this.labelInformation.TabIndex = 19;
            this.labelInformation.Text = resources.GetString("labelInformation.Text");
            // 
            // checkBoxDisplayCoordinates
            // 
            this.checkBoxDisplayCoordinates.AutoSize = true;
            this.checkBoxDisplayCoordinates.Location = new System.Drawing.Point(102, 216);
            this.checkBoxDisplayCoordinates.Name = "checkBoxDisplayCoordinates";
            this.checkBoxDisplayCoordinates.Size = new System.Drawing.Size(255, 17);
            this.checkBoxDisplayCoordinates.TabIndex = 24;
            this.checkBoxDisplayCoordinates.Text = "Display coordinates and size inside the red frame";
            this.checkBoxDisplayCoordinates.UseVisualStyleBackColor = true;
            // 
            // TransparentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 361);
            this.Controls.Add(this.checkBoxDisplayCoordinates);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelInformation2);
            this.Controls.Add(this.ButtonBegin);
            this.Controls.Add(this.TitleLine);
            this.Controls.Add(this.labelInformation);
            this.DoubleBuffered = true;
            this.Name = "TransparentForm";
            this.Text = "Ken Select Screen Area";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TransparentForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TransparentForm_Paint);
            this.DoubleClick += new System.EventHandler(this.TransparentForm_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TransparentForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TransparentForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TransparentForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TransparentForm_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelInformation2;
        private System.Windows.Forms.Button ButtonBegin;
        private System.Windows.Forms.Label TitleLine;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.CheckBox checkBoxDisplayCoordinates;
    }
}

