using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Carga.Models
{
    public class Result
    {
        public bool isSuccessStatusCode { get; set; }
        public int statusCode { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }
        public string data { get; set; }
    }

}
