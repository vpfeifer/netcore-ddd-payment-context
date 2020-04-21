using System;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(DateTime paidDate, DateTime expiredDate, decimal total, 
                            decimal totalPaid, string payer, string document, string address, 
                            string email, string transactionCode) 
                            : base(paidDate, expiredDate, total, totalPaid, payer, document, address)
        {
            Email = email;
            TransactionCode = transactionCode;
        }

        public string Email { get; private set; }
        public string TransactionCode { get; private set; }
    }
}