namespace MainForm
{
    partial class Mainscreen
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
            this.nameInput = new System.Windows.Forms.TextBox();
            this.regionDropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.proceedButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameInput
            // 
            this.nameInput.BackColor = System.Drawing.Color.LightSkyBlue;
            this.nameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameInput.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameInput.Location = new System.Drawing.Point(263, 536);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(252, 37);
            this.nameInput.TabIndex = 0;
            this.nameInput.Text = "Petrovic258";
            this.nameInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // regionDropdown
            // 
            this.regionDropdown.BackColor = System.Drawing.Color.LightSkyBlue;
            this.regionDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regionDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.regionDropdown.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regionDropdown.FormattingEnabled = true;
            this.regionDropdown.Items.AddRange(new object[] {
            "EUW",
            "NA"});
            this.regionDropdown.Location = new System.Drawing.Point(582, 535);
            this.regionDropdown.Name = "regionDropdown";
            this.regionDropdown.Size = new System.Drawing.Size(121, 37);
            this.regionDropdown.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Location = new System.Drawing.Point(258, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(414, 58);
            this.label1.TabIndex = 2;
            this.label1.Text = "Summoner Name              Region\r\n\r\n";
            // 
            // proceedButton
            // 
            this.proceedButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.proceedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.proceedButton.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proceedButton.Location = new System.Drawing.Point(786, 535);
            this.proceedButton.Name = "proceedButton";
            this.proceedButton.Size = new System.Drawing.Size(125, 37);
            this.proceedButton.TabIndex = 3;
            this.proceedButton.Text = "Go!";
            this.proceedButton.UseVisualStyleBackColor = false;
            this.proceedButton.Click += new System.EventHandler(this.proceedButton_Click);
            // 
            // Mainscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::MainForm.Properties.Resources.LoL_Icon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1044, 601);
            this.Controls.Add(this.proceedButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.regionDropdown);
            this.Controls.Add(this.nameInput);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Mainscreen";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.ComboBox regionDropdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button proceedButton;
    }
}

