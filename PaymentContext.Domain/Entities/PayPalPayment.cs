using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(DateTime paidDate, DateTime expiredDate, decimal total, 
                            decimal totalPaid, string payer, Document document, Address address, 
                            Email email, string transactionCode) 
                            : base(paidDate, expiredDate, total, totalPaid, payer, document, address)
        {
            Email = email;
            TransactionCode = transactionCode;
        }

        public Email Email { get; private set; }
        public string TransactionCode { get; private set; }
    }
}