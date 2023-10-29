using System.ComponentModel;

namespace Proj.Manager.Core.Extensions;

public static class EnumExtension
{
    public static string GetDescription(this Enum value)
    {
        var field = value?.GetType()?.GetField(value.ToString()) ?? throw new Exception("Can't get the description. No Enum provided.");

        var atributos = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return atributos.Length > 0 ? atributos[0].Description : "Undefined Description";
    }
}