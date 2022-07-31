using Medical.Controllers;
using Medical.Models;
using Medical.Repo;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Medical.Hubs
{
    public class DashboardHub : Hub
    {
        private readonly MedicalContext _medicalContext;
        public DashboardHub(MedicalContext medicalContext)
        {
            _medicalContext = new MedicalContext();
        }
        public async Task SendProducts()
        {
            var products = _medicalContext.Products;
            await Clients.All.SendAsync("ReceivedProducts", products);
        }
    }
}
