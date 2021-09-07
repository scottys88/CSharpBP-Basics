﻿using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages the vendors from whom we purchase our inventory.
    /// </summary>
    public class Vendor 
    {
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Sends a product order to the vendor
        /// </summary>
        /// <param name="product">Product to order</param>
        /// <param name="qunatity">Quantiy of the product to order</param>
        /// /// <param name="deliverBy">The date to be delivered by</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity, DateTimeOffset? deliverBy, string instructions)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            if (deliverBy <= DateTimeOffset.Now)
                throw new ArgumentOutOfRangeException(nameof(deliverBy));

            var success = false;

            var orderText = $"Order from Acme";

            if (deliverBy.HasValue)
            {
                orderText += System.Environment.NewLine + "Deliver By:" + deliverBy.Value.ToString("d");
            }

            if(!string.IsNullOrWhiteSpace(instructions))
            {
                orderText += System.Environment.NewLine + "Instructions: " + instructions;
            }

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);

            if (confirmation.StartsWith("Message sent:"))
            {
                success = true;
            }

            var operationResult = new OperationResult(success, orderText);

            return operationResult;
        }

        /// <summary>
        /// Sends a product order to the vendor
        /// </summary>
        /// <param name="product">Product to order</param>
        /// <param name="qunatity">Quantiy of the product to order</param>
        /// /// <param name="deliverBy">The date to be delivered by</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity, DateTimeOffset? deliverBy)
        {
            return PlaceOrder(product, quantity, deliverBy, null);
        }

        /// <summary>
        /// Sends a product order to the vendor
        /// </summary>
        /// <param name="product"></param>
        /// <param name="qunatity"></param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity)
        {
            return PlaceOrder(product, quantity, null, null);
        }

        /// <summary>
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ("Hello " + this.CompanyName).Trim();
            var confirmation = emailService.SendMessage(subject,
                                                        message, 
                                                        this.Email);
            return confirmation;
        }
    }
}
