﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardGr.Infrastructure.Messaging
{
    public interface IMessageBusService
    {
        Task Publish<T>(T data, string? routingKey = null);
    }
}
