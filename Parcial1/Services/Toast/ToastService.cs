namespace Parcial1.Services.Toast;

public sealed class ToastService : IToastService
{
    private readonly List<ToastMessage> _items = new();
    public IReadOnlyList<ToastMessage> Items => _items;

    public event Action? OnChange;

    public void Success(string message, string title = "OK") => Add("toast-success", title, message);
    public void Error(string message, string title = "Error") => Add("toast-error", title, message);
    public void Info(string message, string title = "Info") => Add("toast-info", title, message);

    private void Add(string css, string title, string message)
    {
        _items.Add(new ToastMessage(css, title, message));
        OnChange?.Invoke();
        _ = AutoRemoveAsync();
    }

    private async Task AutoRemoveAsync()
    {
        await Task.Delay(2800);
        if (_items.Count == 0) return;
        _items.RemoveAt(0);
        OnChange?.Invoke();
    }
}
