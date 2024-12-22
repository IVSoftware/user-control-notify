namespace user_control_notify
{
    partial class UserControlWithNotify
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox = new TextBox();
            numericUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            SuspendLayout();
            // 
            // textBox
            // 
            textBox.Location = new Point(4, 7);
            textBox.Margin = new Padding(4);
            textBox.Name = "textBox";
            textBox.PlaceholderText = "Enter text";
            textBox.Size = new Size(257, 34);
            textBox.TabIndex = 0;
            // 
            // numericUpDown
            // 
            numericUpDown.Location = new Point(275, 7);
            numericUpDown.Margin = new Padding(4);
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(105, 34);
            numericUpDown.TabIndex = 1;
            numericUpDown.TextAlign = HorizontalAlignment.Center;
            // 
            // UserControlWithNotify
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(numericUpDown);
            Controls.Add(textBox);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UserControlWithNotify";
            Size = new Size(384, 45);
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox;
        private NumericUpDown numericUpDown;
    }
}
