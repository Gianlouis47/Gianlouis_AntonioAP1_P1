namespace Parcial1.Services.Toast;

public interface IToastService
{
    event Action? OnChange;
    List<ToastMessage> Items { get; }

    void ShowSuccess(string message);
    void ShowError(string message);
    void Dismiss(Guid id);
}

