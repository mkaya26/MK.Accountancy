using DevExpress.XtraReports.UI;
using Microsoft.Extensions.Localization;
using MK.Blazor.Core.Models;
using MK.Blazor.Core.Services;
using System.Reflection;

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
                    DisplayName = localizer[$"Enum:{typeof(TEnum).Name}:{t.To<byte>()}"]
                }).ToList();
        }

        public static string[] RowHeights(params string[] rowHeights)
        {
            return rowHeights;
        }

        public static string[] ColumnWidths(params string[] columnWidths)
        {
            return columnWidths;
        }

        public static string CreateId()
        {
            string AddZero(string value, bool threeDigits = false)
            {
                if (threeDigits)
                    return value.Length switch
                    {
                        1 => "00" + value,
                        2 => "0" + value,
                        _ => value,
                    };

                return value.Length switch
                {
                    1 => "0" + value,
                    _ => value,
                };
            }

            string Id()
            {
                var year = DateTime.Now.Date.Year.ToString();
                var month = AddZero(DateTime.Now.Date.Month.ToString());
                var day = AddZero(DateTime.Now.Date.Day.ToString());
                var hour = AddZero(DateTime.Now.Hour.ToString());
                var minute = AddZero(DateTime.Now.Minute.ToString());
                var second = AddZero(DateTime.Now.Second.ToString());
                var millisecond = AddZero(DateTime.Now.Millisecond.ToString(), true);
                var random = AddZero(new Random().Next(0, 99).ToString());

                return year + month + day + hour + minute + second + millisecond + random;
            }

            return Id();
        }

        public static XtraReport GetReport(Assembly assembly, ICoreListPageService service)
        {
            var assemblyName = assembly.FullName.Split(',')[0];
            var reportFolder = service.ReportFolder == null ? service.BaseReportFolder : $"{service.BaseReportFolder}.{service.ReportFolder.Replace('\\', '.')}";
            //
            return (XtraReport)assembly.CreateInstance($"{assemblyName}.{reportFolder}.{service.SelectedReportName}".Replace(' ', '_'));
        }
    }
}
