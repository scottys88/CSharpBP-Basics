using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory
    /// </summary>
    public class Product
    {
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;
        public Product()
        {
            this.MinimumPrice = .96m;
        }

        public Product(int productId, 
            string productName, 
            string description): this()
        {
            this.ProductName = productName;
            this.ProductId = productId;
            this.ProductDescription = description;
            if (productName.StartsWith("Bulk"))
            {
                this.MinimumPrice = 9.99m;
            }
        }

        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private string productDescription;

        public string ProductDescription
        {
            get { return productDescription; }
            set { productDescription = value; }
        }

        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get { 
                if(productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor; 
            }
            set { productVendor = value; }
        }

        private DateTime? availabilityDate;

        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }



        public string SayHello()
        {
            var emailService = new EmailService();
            var hey = LoggingService.LogAction("hey");
            return $"Hello {ProductName} {ProductId}: {ProductDescription}, Available on: {AvailabilityDate?.ToShortDateString()}";
        }


    }
}
