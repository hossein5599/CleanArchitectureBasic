using Humanizer;
namespace CA.Blocks.Application.Common.ViewModels;
public record EnumViewModel(
    int Key,
    string Value,
    string Description
    )
{
    public EnumViewModel(Enum enumValue) : this((int)(object)enumValue, enumValue.ToString(), enumValue.Humanize())
    {
    }
}
