namespace Parcial1.Services.Toast;

public sealed record ToastMessage(
    ToastLevel Level,
    string Title,
    string Message,
    int DurationMs = 3500
)
{
    private string css;

    public ToastMessage(string css, string title, string message)
    {
        this.css = css;
        Title = title;
        Message = message;
    }
}