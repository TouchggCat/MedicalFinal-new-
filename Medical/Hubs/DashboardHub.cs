using Medical.Class;
using Medical.Controllers;
using Medical.Models;
using Medical.ViewModel;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medical.Hubs
{
    public class DashboardHub : Hub
    {
        //private readonly MedicalContext _medicalContext;
        //public DashboardHub(MedicalContext medicalContext)
        //{
        //    _medicalContext = new MedicalContext();
        //}
        //public async Task SendProducts()
        //{
        //    var products = _medicalContext.Products;
        //    await Clients.All.SendAsync("ReceivedProducts", products);
        //}

        private readonly Dashboard dashboard;
        System.Threading.Timer threadTimer;
        public DashboardHub(Dashboard dashboard)
        {
            this.dashboard = dashboard;
        }

        //public List<Product> GetAllProducts()
        //{
        //    return dashboard.GetAllProducts();
        //}

        public async Task  GetAllProducts()
        {
            await Clients.All.SendAsync("ReceivedProducts", dashboard.GetAllProducts());
        }


    }
}
