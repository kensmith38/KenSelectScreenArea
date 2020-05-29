namespace KenSmithConsulting.KenSelectScreenAreaTest
{
    partial class Form1
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
            this.TitleLine = new System.Windows.Forms.Label();
            this.ButtonTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxCoordX = new System.Windows.Forms.TextBox();
            this.TextBoxCoordY = new System.Windows.Forms.TextBox();
            this.TextBoxWidth = new System.Windows.Forms.TextBox();
            this.TextBoxHeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBoxSelectionCancelled = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TitleLine
            // 
            this.TitleLine.AutoSize = true;
            this.TitleLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLine.Location = new System.Drawing.Point(47, 31);
            this.TitleLine.Name = "TitleLine";
            this.TitleLine.Size = new System.Drawing.Size(417, 24);
            this.TitleLine.TabIndex = 21;
            this.TitleLine.Text = "Ken Smith Consulting: TEST Select Screen Area";
            // 
            // ButtonTest
            // 
            this.ButtonTest.Location = new System.Drawing.Point(66, 77);
            this.ButtonTest.Name = "ButtonTest";
            this.ButtonTest.Size = new System.Drawing.Size(75, 23);
            this.ButtonTest.TabIndex = 22;
            this.ButtonTest.Text = "Test";
            this.ButtonTest.UseVisualStyleBackColor = true;
            this.ButtonTest.Click += new System.EventHandler(this.ButtonTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Selected X-coord:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Selected Y-coord:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Selected Width:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Selected Height:";
            // 
            // TextBoxCoordX
            // 
            this.TextBoxCoordX.Location = new System.Drawing.Point(163, 148);
            this.TextBoxCoordX.Name = "TextBoxCoordX";
            this.TextBoxCoordX.ReadOnly = true;
            this.TextBoxCoordX.Size = new System.Drawing.Size(100, 20);
            this.TextBoxCoordX.TabIndex = 27;
            // 
            // TextBoxCoordY
            // 
            this.TextBoxCoordY.Location = new System.Drawing.Point(163, 174);
            this.TextBoxCoordY.Name = "TextBoxCoordY";
            this.TextBoxCoordY.ReadOnly = true;
            this.TextBoxCoordY.Size = new System.Drawing.Size(100, 20);
            this.TextBoxCoordY.TabIndex = 28;
            // 
            // TextBoxWidth
            // 
            this.TextBoxWidth.Location = new System.Drawing.Point(163, 200);
            this.TextBoxWidth.Name = "TextBoxWidth";
            this.TextBoxWidth.ReadOnly = true;
            this.TextBoxWidth.Size = new System.Drawing.Size(100, 20);
            this.TextBoxWidth.TabIndex = 29;
            // 
            // TextBoxHeight
            // 
            this.TextBoxHeight.Location = new System.Drawing.Point(163, 226);
            this.TextBoxHeight.Name = "TextBoxHeight";
            this.TextBoxHeight.ReadOnly = true;
            this.TextBoxHeight.Size = new System.Drawing.Size(100, 20);
            this.TextBoxHeight.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Selection cancelled:";
            // 
            // TextBoxSelectionCancelled
            // 
            this.TextBoxSelectionCancelled.Location = new System.Drawing.Point(163, 122);
            this.TextBoxSelectionCancelled.Name = "TextBoxSelectionCancelled";
            this.TextBoxSelectionCancelled.ReadOnly = true;
            this.TextBoxSelectionCancelled.Size = new System.Drawing.Size(100, 20);
            this.TextBoxSelectionCancelled.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 261);
            this.Controls.Add(this.TextBoxSelectionCancelled);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TextBoxHeight);
            this.Controls.Add(this.TextBoxWidth);
            this.Controls.Add(this.TextBoxCoordY);
            this.Controls.Add(this.TextBoxCoordX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonTest);
            this.Controls.Add(this.TitleLine);
            this.Name = "Form1";
            this.Text = "Test: KenSelectScreenArea";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLine;
        private System.Windows.Forms.Button ButtonTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxCoordX;
        private System.Windows.Forms.TextBox TextBoxCoordY;
        private System.Windows.Forms.TextBox TextBoxWidth;
        private System.Windows.Forms.TextBox TextBoxHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextBoxSelectionCancelled;
    }
}

