namespace SlopBalancer.Views;

public partial class MainView : Form
{
    public MainView()
    {
        InitializeComponent();

        radioAddCash.Click += (_, _) => { txtCash.Enabled = true; };
        radioOnlyCurrent.Click += (_, _) => { txtCash.Enabled = false; };
        
        
    }
    
}