/*Scenario: A reporting system that needs to generate
  different report formats (CSV, XML, JSON) without
  modifying existing code.*/

/*

 * Structure:

  Order: Class representing an order with relevant data (e.g., ID, customer, product, etc.).
  ReportGenerator: Interface defining the GenerateReport(List<Order>) method.
  CsvReportGenerator: Concrete implementation generating CSV reports.
  XmlReportGenerator: Concrete implementation generating XML reports.
  JsonReportGenerator: Concrete implementation generating JSON reports.
  ReportService: Class facilitating report generation using dependency injection.
  Test: Entry point driving the application and showcasing report generation.
 */

using System;
using System.Collections.Generic;

namespace OCP
{
    public class Order
    {
        public int ID { get; set; }
        public string Customer { get; set; }
        public string Product { get; set; }
        public decimal Amount { get; set; }

        public Order(int id, string customer, string product, decimal amount)
        {
            ID = id;
            Customer = customer;
            Product = product;
            Amount = amount;
        }

        /*public Order()
        {
            throw new NotImplementedException();
        }*/

        // Additional logic as needed (examples):

        public decimal CalculateDiscount(decimal dis_Rate)
        {
            return Amount * dis_Rate;
        }
    }

    public interface IReportGenerator
    {
        string GenerateReport(List<Order> orders);
    }

    public class CsvReportGenerator : IReportGenerator
    {
        public string GenerateReport(List<Order> orders)
        {
            // Build CSV string with header and order data manually
            var report = "OrderId,Customer,Product,Amount\n";
            foreach (Order csv in orders)
            {
                report += $"{csv.ID},{csv.Customer},{csv.Product},{csv.Amount}\n";
            }

            return report;
        }
    }

    public class XmlReportGenerator : IReportGenerator
    {
        public string GenerateReport(List<Order> orders)
        {
            // Build XML string with order elements manually
            var report = "<Orders>\n";
            foreach (Order Xml in orders)
            {
                report += $"  <Order ID=\"{Xml.ID}\">\n";
                report += $"    <Customer>{Xml.Customer}</Customer>\n";
                report += $"    <Product>{Xml.Product}</Product>\n";
                report += $"    <Amount>{Xml.Amount}</Amount>\n";
                report += $"  </Order>\n";
            }

            report += "</Orders>";
            return report;
        }
    }

    public class JsonReportGenerator : IReportGenerator
    {
        public string GenerateReport(List<Order> orders)
        {
            // Build JSON string manually
            var report = "[\n";
            foreach (Order JSON in orders)
            {
                report += $"  {{\n";
                report += $"    \"ID\": {JSON.ID},\n";
                report += $"    \"Customer\": \"{JSON.Customer}\",\n";
                report += $"    \"Product\": \"{JSON.Product}\",\n";
                report += $"    \"Amount\": {JSON.Amount}\n";
                report += $"  }},";
            }

            report = report.TrimEnd(','); // Remove trailing comma
            report += "\n]";
            return report;
        }
    }

    public class ReportService
    {
        private readonly IReportGenerator _reportGenerator;

        public ReportService(IReportGenerator reportGenerator) //dependency injection
        {
            _reportGenerator = reportGenerator;
        }

        public string GenerateReport(List<Order> orders)
        {
            return _reportGenerator.GenerateReport(orders);
        }
    }

    class Test
    {
        public static void Main(string[] args)
        {
            var orders = new List<Order>()
            {
                new Order(121314, "Rayhan Chowdhury", "C# BOOK", 480.50m),
                new Order(919293, "Sohel Chowdhury", "English BOOK", 550.50m),
                new Order(343536, "Rasel Chowdhury", "Arabic BOOK", 750.50m),
                new Order(143, "YOU", "Flowers", 1000.00m),
            };

            Console.WriteLine("CSV Report: ");
            var CSV = new ReportService(new CsvReportGenerator());
            Console.WriteLine(CSV.GenerateReport(orders));

            Console.WriteLine("\nXML Report:");
            var XML = new ReportService(new XmlReportGenerator());
            Console.WriteLine(XML.GenerateReport(orders));

            Console.WriteLine("\nJSON Report:");
            var JSON = new ReportService(new JsonReportGenerator());
            Console.WriteLine(JSON.GenerateReport(orders));

            Console.WriteLine("\n\nDiscount: \n");
            foreach (Order user in orders)
            {
                Console.WriteLine($"For {user.Customer} is : {user.CalculateDiscount(0.10m)} On {user.Product}.");
            }

            Console.ReadKey();
        }
    }
}
/*Open-Closed Principle (OCP) in this code:

Open for extension: New report formats can be added easily by creating new classes that implement the IReportGenerator interface, without changing existing code.
Closed for modification: The core ReportService class remains unchanged, ensuring its stability and reducing the risk of introducing bugs.
Key OCP elements:

Interface: The IReportGenerator interface defines a contract for report generation, allowing different implementations to be swapped in seamlessly.
Dependency injection: The ReportService class receives the specific IReportGenerator implementation at runtime, promoting flexibility and testability.
Benefits:

Extensibility: New report formats can be added without disrupting existing functionality.
Maintainability: Changes are isolated to specific implementations, reducing the impact of modifications.
Testability: Different report generators can be tested independently.*/