using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(DateTime paidDate, DateTime expiredDate, decimal total,
                            decimal totalPaid, string payer, Document document, Address address, 
                            string barCode, string boletoNumber) 
            : base(paidDate, expiredDate, total, totalPaid, payer, document, address)
        {
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
    }
}