using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace user_control_notify
{
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
}
