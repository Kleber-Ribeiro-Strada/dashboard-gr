﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Domain.Shared.Commands.Response
{
    public class CommandResponse
    {
        public CommandResponse(object data)
        {
            Date = DateTime.Now;
            Data = data;
        }

        public CommandResponse(int statusCode, string message, object data)
        {
            StatusCode = statusCode;
            Message = message;
            Date = DateTime.Now;
            Data = data;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; } 
        public DateTime Date { get; private set; }
        public object Data { get; set; }
    }
}
