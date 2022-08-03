using Medical.Hubs;
using Medical.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;



namespace Medical.Class
{
    public class Dashboard : IDashboard
    {
        private readonly IConfiguration _config;
        private readonly IHubContext<DashboardHub> _context;
        string connectionString = "";
        public Dashboard(IConfiguration configuration, IHubContext<DashboardHub> context)
        {
            _config = configuration;
            _context = context;
        }
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();

            connectionString = _config.GetConnectionString("MedicalConnection");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlDependency.Start(connectionString);

                string commandText = "select ProductName, Stock, Shelfdate from dbo.Product";

                SqlCommand cmd = new SqlCommand(commandText, conn);

                SqlDependency dependency = new SqlDependency(cmd);

                dependency.OnChange += new OnChangeEventHandler(dbChangeNotification);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var product = new Product
                    {
                        ProductName = reader["ProductName"].ToString(),
                        Stock = Convert.ToInt32(reader["Stock"]),
                        Shelfdate = Convert.ToInt32(reader["Shelfdate"])
                    };

                    products.Add(product);
                }
            }

            return products;
        }

        private void dbChangeNotification(object sender, SqlNotificationEventArgs e)
        {
            _context.Clients.All.SendAsync("refreshProducts", GetAllProducts());
        }
    }
}
