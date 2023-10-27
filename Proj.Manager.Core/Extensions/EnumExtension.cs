using System.ComponentModel;

namespace Proj.Manager.Core.Extensions;

public static class EnumExtension
{
    public static string GetDescription(this Enum value)
    {
        var field = value?.GetType()?.GetField(value.ToString());

        if (field == null) return value.ToString();

        var atributos = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return atributos.Length > 0 ? atributos[0].Description : value.ToString();
    }
}