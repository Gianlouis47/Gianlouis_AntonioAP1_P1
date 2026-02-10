namespace Parcial1.Services.Toast;

public class ToastService : IToastService
{
    public event Action? OnChange;
    public List<ToastMessage> Items { get; } = new();

    public void ShowSuccess(string message)
        => Add("Éxito", message, ToastLevel.Success);

    public void ShowError(string message)
        => Add("Error", message, ToastLevel.Error);

    private void Add(string title, string message, ToastLevel level)
    {
        Items.Add(new ToastMessage
        {
            Title = title,
            Message = message,
            Level = level
        });
        OnChange?.Invoke();
    }

    public void Dismiss(Guid id)
    {
        var toast = Items.FirstOrDefault(x => x.Id == id);
        if (toast != null)
        {
            Items.Remove(toast);
            OnChange?.Invoke();
        }
    }
}
