using System.ComponentModel;

namespace DashBoardGr.Domain.Shared
{
    public static class EnumCommon
    {
        public static string? ObterDescricaoDoEnum(this Enum valorEnum)
        {
            if (valorEnum is null)
                return null;
            
            var tipoEnum = valorEnum.GetType();
            var membroEnum = tipoEnum.GetMember(valorEnum.ToString());

            if (membroEnum.Length > 0)
            {
                var atributos = membroEnum[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (atributos.Length > 0)
                {
                    return ((DescriptionAttribute)atributos[0]).Description;
                }
            }

            return valorEnum.ToString();
        }
    }
}