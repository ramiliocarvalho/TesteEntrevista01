using System.ComponentModel;

namespace WebAppTesteEntrevista01.Enums
{
    public enum TipoCnhEnums
    {
        [Description("Categoria A")] CategoriaA = 1,
        [Description("Categoria B")] CategoriaB = 2,
        [Description("Ambas")] Ambas = 3
    }

    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum value)
        {
            System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
