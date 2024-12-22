Your question is about how to _Communicate data from a user control to its parent form_.

The comment and previous answer do a good job explaining why the static event handler works only for calling static methods like `MessageBox.Show()`. I'd like to more broadly answer how a user control might communicate with its parent, and hopefully set you up to win in this endeavor by doing it in a more standard, supportable and scalable way. A strategy that is often used is to have the user control send a `PropertyChanged` notification whenever _any_ of its  properties changes. Since the `sender` argument identifies which user control has changed, and the `e.PropertyName` argument identifies the specific property, all the information required to act on the event is available without having to write a separate event for each and every property that you might add. As a minimal example, here's a `UserControl` set up with this pattern.
___

**User Control that Notifies when Property Changes**


~~~

public partial class UserControlWithNotify : UserControl, INotifyPropertyChanged
{
    public UserControlWithNotify()
    {
        InitializeComponent();
        // Bind the properties to the control instances.
        textBox.KeyDown += TextBox_Commit;      // For example, respond to the Enter key
        textBox.LostFocus += TextBox_Commit;    // For example, respond to the Tab key
        numericUpDown.DataBindings.Add("Value", this, nameof(NumericValue), true, DataSourceUpdateMode.OnPropertyChanged);
    }
    private void TextBox_Commit(object? sender, EventArgs e)
    {
        if (e is KeyEventArgs eKey && eKey.KeyData != Keys.Enter) return;
        TextValue = textBox.Text;
    }
    public int NumericValue
    {
        get => _numericValue;
        set
        {
            if (!Equals(_numericValue, value))
            {
                _numericValue = value;
                OnPropertyChanged();
            }
        }
    }
    int _numericValue = default;

    public string TextValue
    {
        get => _textValue;
        set
        {
            if (!Equals(_textValue, value))
            {
                _textValue = value;
                OnPropertyChanged();
            }
        }
    }
    string _textValue = string.Empty;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public event PropertyChangedEventHandler PropertyChanged;
}
~~~

___

**Setting the Parent up to Listen**

On this example form, two instances of `UserControlWithNotify` that are added e.g. in the Designer will be present in the `Controls` collection of the parent, and this provides a good way to attach the `PropertyChanged` event.


[![form with two instances of user control][1]][1]

~~~
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
~~~


  [1]: https://i.sstatic.net/IY0O3dfW.png