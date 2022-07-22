using Medical.Models;
using Medical.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Medical.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            string user = "";
            if (Context.GetHttpContext().Session.Keys.Contains(CDictionary.SK_LOGINED_USE))
            {
                user = "客服";
            }
            else
            {
                user = "訪客";
            }
            await Clients.All.SendAsync("ReceiveMessage",user,message);
        }
    }
}
