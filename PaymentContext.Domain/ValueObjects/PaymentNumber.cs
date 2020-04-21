using System;

namespace PaymentContext.Domain.ValueObjects
{
    public class PaymentNumber
    {
        public PaymentNumber()
        {
            Number = Guid.NewGuid().ToString()
                            .Replace("-", "")
                            .Substring(0, 10)
                            .ToUpper();
        }

        public string Number { get; private set; }
    }
}