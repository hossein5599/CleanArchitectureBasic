namespace CA.Blocks.Application.Common.ViewModels;
public class RedirectViewModel
{
    public required string URL { get; set; }
    public string Token { get; set; } = string.Empty;
}