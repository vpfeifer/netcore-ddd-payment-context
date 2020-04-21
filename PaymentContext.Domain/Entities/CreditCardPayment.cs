using System;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(DateTime paidDate, DateTime expiredDate, decimal total, 
                                decimal totalPaid, string payer, string document, string address, 
                                string cardNumber, string cardHolderName, string lastTransactionNumber) 
            : base(paidDate, expiredDate, total, totalPaid, payer, document, address)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardNumber { get; private set; }
        public string CardHolderName { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}