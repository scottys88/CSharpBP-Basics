﻿using Acme.Common;
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
        public Product()
        {

        }

        public Product(int productId, 
            string productName, 
            string description): this()
        {
            this.ProductName = productName;
            this.ProductId = productId;
            this.ProductDescription = description;            
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


        public string SayHello()
        {
            var emailService = new EmailService();
            var hey = LoggingService.LogAction("hey");
            return $"Hello {ProductName} {ProductId}: {ProductDescription}";
        }


    }
}
