using System.ComponentModel;

namespace Proj.Manager.Core.Extensions;

public static class EnumExtension
{
    public static string RetornarDescricao(this Enum value)
    {
        var campo = value.GetType().GetField(value.ToString());
        var atributos = (DescriptionAttribute[])campo.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return atributos.Length > 0 ? atributos[0].Description : value.ToString();
    }
}