﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace UX.SignalR
{
    public class ChatHub : Hub
    {
        public void SendMessage(string userName, string message)
        {
            Clients.All.broadcastMessage(userName, message);
        }
    }
}