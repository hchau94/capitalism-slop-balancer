namespace SlopBalancer.Presenters;

using Abstractions;

public class MainPresenter
{
    private readonly IView _view;
    
    public MainPresenter(IView view)
    {
        _view = view;

        _view.UpdateClicked += OnUpdateClick;
    }
    
    private void OnUpdateClick(object? sender, EventArgs e)
    {
        var text = _view.GetTickers();
    }
}