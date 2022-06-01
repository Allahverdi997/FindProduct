using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PITask.Core.Messages
{
    public class ClientMessages
    {
        public static string LoginMessage { get; set; } = "Welcome to E-Warehouses Application.";
        public static string ProductMessage { get; set; } = "The following products are available in our warehouses";
        public static string Products { get; set; } = "Products:";
        public static string Space { get; set; } = "-------------------------------------------------------";
        public static string CountrMessage { get; set; } = "Countries which are place warehouses";
        public static string CountryWithId { get; set; } = "Please select Your country (With Id):";
        public static string ProductWithId { get; set; } = "Search Product (With Id):";
        public static string OrderMessage { get; set; } = "If you want to order, click the Y button.";
        public static string NoProduct { get; set; } = "No Products Found in Our Warehouses.";
    }
}
