namespace MK.Blazor.Core.Models
{
    public class ComboboxEnumItem<TEnum> where TEnum : Enum
    {
        public TEnum Value { get; set; }
        public string DisplayName { get; set; }
    }
}
