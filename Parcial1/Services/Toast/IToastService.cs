namespace Parcial1.Services.Toast;

public interface IToastService
{
    IReadOnlyList<ToastMessage> Items { get; }
    event Action? OnChange;

    void Success(string message, string title = "OK");
    void Error(string message, string title = "Error");
    void Info(string message, string title = "Info");
}

public sealed record ToastMessage(string Css, string Title, string Message);
