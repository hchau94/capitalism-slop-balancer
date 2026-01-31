namespace SlopBalancer.Views;

using Abstractions;
using Presenters;

public partial class MainView : Form, IView
{
    public event EventHandler? BalanceClicked;
    
    private MainPresenter _presenter;
    private bool _textBoxWasJustPastedInto = false;
    
    public MainView()
    {
        InitializeComponent();

        _presenter = new MainPresenter(this);

        txtTickers.KeyDown += RecordIfPastedFromClipboard;
        txtCurrentShares.KeyDown += RecordIfPastedFromClipboard;
        txtTargets.KeyDown += RecordIfPastedFromClipboard;
        txtTickers.TextChanged += CleanUpTextInput;
        txtCurrentShares.TextChanged += CleanUpTextInput;
        txtTargets.TextChanged += CleanUpTextInput;
        btnBalance.Click += UpdateClickRepeater;
    }
    
    private void RecordIfPastedFromClipboard(object? sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.V)
            _textBoxWasJustPastedInto = true;
    }
    
    private void CleanUpTextInput(object? sender, EventArgs e)
    {
        if (!_textBoxWasJustPastedInto) return;
        _textBoxWasJustPastedInto = false;
        TextBox? textBox = (TextBox?)sender;
        if (textBox == null) return;
        this.BeginInvoke(() =>
        {
            textBox.Text = textBox.Text.Replace("\r\n", ", ");
        });
    }

    private void UpdateClickRepeater(object? sender, EventArgs e)
    {
        BalanceClicked?.Invoke(sender, e);
    }

    public string GetTickers()
    {
        return txtTickers.Text;
    }
}