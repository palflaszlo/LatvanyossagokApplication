namespace LatvanyossagokApplication
{
    partial class Form2
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
            this.vissza_gomb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // vissza_gomb
            // 
            this.vissza_gomb.Location = new System.Drawing.Point(361, 95);
            this.vissza_gomb.Name = "vissza_gomb";
            this.vissza_gomb.Size = new System.Drawing.Size(75, 23);
            this.vissza_gomb.TabIndex = 0;
            this.vissza_gomb.Text = "vissza";
            this.vissza_gomb.UseVisualStyleBackColor = true;
            this.vissza_gomb.Click += new System.EventHandler(this.vissza_gomb_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.vissza_gomb);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button vissza_gomb;
    }
}