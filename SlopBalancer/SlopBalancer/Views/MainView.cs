using System.ComponentModel;
namespace SlopBalancer.Views;

using Abstractions;
using Presenters;

public partial class MainView : Form, IView
{
    public event EventHandler? BalanceClicked;
    
    private MainPresenter _presenter;
    private bool _textBoxWasJustPastedInto = false;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool AddNewCash
    {
        get => chkAddCash.Checked;
        set => chkAddCash.Checked = value;
    }
    
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool UseCurrentSharesOnly
    {
        get => chkCurrentOnly.Checked;
        set => chkCurrentOnly.Checked = value;
    }
    
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool RebalanceOnlyToBands
    {
        get => chkOnlyToBands.Checked;
        set => chkOnlyToBands.Checked = value;
    }
    
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Tickers
    {
        get => txtTickers.Text;
        set => txtTickers.Text = value;
    }
    
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string CurrentShares
    {
        get => txtCurrentShares.Text;
        set => txtCurrentShares.Text = value;
    }
    
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Targets
    {
        get => txtTargets.Text;
        set => txtTargets.Text = value;
    }
    
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string NewCashToAdd
    {
        get => txtCashToAdd.Text;
        set => txtCashToAdd.Text = value;
    }
    
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
        btnBalance.Click += BalanceClickRepeater;
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

    private void BalanceClickRepeater(object? sender, EventArgs e)
    {
        BalanceClicked?.Invoke(sender, e);
    }
}