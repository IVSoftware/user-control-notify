namespace user_control_notify
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
            userControl1 = new UserControlWithNotify();
            userControl2 = new UserControlWithNotify();
            richTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // userControl1
            // 
            userControl1.AutoSize = true;
            userControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            userControl1.BorderStyle = BorderStyle.FixedSingle;
            userControl1.Font = new Font("Segoe UI", 12F);
            userControl1.Location = new Point(46, 112);
            userControl1.Margin = new Padding(4);
            userControl1.Name = "userControl1";
            userControl1.NumericValue = 0;
            userControl1.Size = new Size(386, 47);
            userControl1.TabIndex = 1;
            userControl1.TextValue = "";
            // 
            // userControl2
            // 
            userControl2.AutoSize = true;
            userControl2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            userControl2.BorderStyle = BorderStyle.FixedSingle;
            userControl2.Font = new Font("Segoe UI", 12F);
            userControl2.Location = new Point(46, 172);
            userControl2.Margin = new Padding(4);
            userControl2.Name = "userControl2";
            userControl2.NumericValue = 0;
            userControl2.Size = new Size(386, 47);
            userControl2.TabIndex = 2;
            userControl2.TextValue = "";
            // 
            // richTextBox
            // 
            richTextBox.BackColor = Color.White;
            richTextBox.Location = new Point(45, 12);
            richTextBox.Name = "richTextBox";
            richTextBox.ReadOnly = true;
            richTextBox.Size = new Size(387, 78);
            richTextBox.TabIndex = 0;
            richTextBox.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 253);
            Controls.Add(richTextBox);
            Controls.Add(userControl2);
            Controls.Add(userControl1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControlWithNotify userControl1;
        private UserControlWithNotify userControl2;
        private RichTextBox richTextBox;
    }
}
