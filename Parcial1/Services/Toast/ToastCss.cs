namespace Parcial1.Services.Toast;

public static class ToastCss
{
    public static string ToCss(this ToastLevel level) => level switch
    {
        ToastLevel.Success => "toast toast-success",
        ToastLevel.Warning => "toast toast-warning",
        ToastLevel.Error => "toast toast-error",
        _ => "toast toast-info"
    };
}
