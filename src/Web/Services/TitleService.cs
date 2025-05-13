namespace Web.Services;

public class TitleService
{
    public event Action<string>? OnTitleChanged;

    public void SetTitle(string title)
    {
        OnTitleChanged?.Invoke(title);
    }
}
