using System.ComponentModel;
using System.ComponentModel.Design;

namespace user_control_notify
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            foreach (UserControlWithNotify userControlWithNotify in this.Controls.OfType<UserControlWithNotify>())
            {
                userControlWithNotify.PropertyChanged += AnyUserControlWithNotify_PropertyChanged;
            }
        }

        private void AnyUserControlWithNotify_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender is UserControlWithNotify userControlWithNotify)
            {
                richTextBox.Clear();
                richTextBox.AppendText("Control Name: ", Color.Blue, style: FontStyle.Bold);
                richTextBox.AppendText(userControlWithNotify.Name, newLine: true);
                richTextBox.AppendText("Property Name: ", Color.Blue, style: FontStyle.Bold);
                richTextBox.AppendText(e.PropertyName, newLine: true);
                richTextBox.AppendText("New Value: ", Color.Blue, style: FontStyle.Bold);
                richTextBox.AppendText(
                    $"{typeof(UserControlWithNotify)
                    .GetProperty(e.PropertyName)
                    .GetValue(userControlWithNotify)}", newLine: true);
            }
        }
    }
    static class Extensions
    {
        public static void AppendText(
            this RichTextBox textBox,
            string text,
            Color? color = null,
            FontStyle? style = FontStyle.Regular,
            bool newLine = false)
        {
            var colorB4 = textBox.SelectionColor;
            var fontB4 = textBox.SelectionFont;
            if (color.HasValue) textBox.SelectionColor = color.Value;
            if (style.HasValue) textBox.SelectionFont = new Font(textBox.SelectionFont, style.Value);
            textBox.AppendText(text);
            if(newLine) textBox.AppendText(Environment.NewLine);
            textBox.SelectionColor = colorB4;
            textBox.SelectionFont = fontB4;
        }
    }
}
