namespace SlopBalancer;

using Abstractions;
using Presenters;

public partial class MainView : Form, IView
{
    public event EventHandler? UpdateClicked;
    
    private MainPresenter _presenter;

    private bool textBoxWasJustPastedInto = false;
    
    public MainView()
    {
        InitializeComponent();

        _presenter = new MainPresenter(this);

        txtTickers.KeyDown += RecordIfPastedFromClipboard;
        txtTickers.TextChanged += CleanUpTextInput;
        btnUpdate.Click += UpdateClickRepeater;
    }
    
    private void RecordIfPastedFromClipboard(object? sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.V)
            textBoxWasJustPastedInto = true;
    }
    
    private void CleanUpTextInput(object? sender, EventArgs e)
    {
        if (!textBoxWasJustPastedInto) return;
        textBoxWasJustPastedInto = false;
        TextBox? textBox = (TextBox?)sender;
        if (textBox == null) return;
        this.BeginInvoke(() =>
        {
            textBox.Text = textBox.Text.Replace("\r\n", ", ");
        });
    }

    private void UpdateClickRepeater(object? sender, EventArgs e)
    {
        UpdateClicked?.Invoke(sender, e);
    }

    public string GetTickers()
    {
        return txtTickers.Text;
    }
}