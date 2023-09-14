using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Shared.Validator
{
    public static class SharedValidators
    {
        public static bool EhMaiorDe18Anos(DateTime dataNascimento)
        {
            var idade = DateTime.Today.Year - dataNascimento.Year;
            if (dataNascimento.Date > DateTime.Today.AddYears(-idade)) idade--;

            return idade >= 18;
        }
    }
}
