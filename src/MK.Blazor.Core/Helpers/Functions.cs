using Microsoft.Extensions.Localization;
using MK.Blazor.Core.Models;

namespace MK.Blazor.Core.Helpers
{
    public class Functions
    {
        public static List<ComboboxEnumItem<TEnum>> FillEnumToCombobox<TEnum>(IStringLocalizer localizer) where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
                .OfType<TEnum>()
                .Select(t => new ComboboxEnumItem<TEnum>
                {
                    Value = t,
                    DisplayName = localizer[$"Enum:{typeof(TEnum).Name}:{t.To<byte>}"]
                }).ToList();
        }
    }
}
