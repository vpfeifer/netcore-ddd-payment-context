using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        private IList<Payment> _payments;

        public Subscription(DateTime? expiredDate)
        {
            CreatedDate = DateTime.Now;
            LastUpdate = DateTime.Now;
            ExpiredDate = expiredDate;
            IsActive = true;
            _payments = new List<Payment>();
        }

        public DateTime CreatedDate { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public DateTime? ExpiredDate { get; private set; }
        public bool IsActive { get; private set; }
        public IReadOnlyCollection<Payment> Payments 
        {
            get
            {
                return _payments.ToArray();
            }
        }

        public void AddPayment(Payment payment)
        {
            _payments.Add(payment);
        }

        public void Activate()
        {
            IsActive = true;
            LastUpdate = DateTime.Now;
        }

        public void Deactivate()
        {
            IsActive = false;
            LastUpdate = DateTime.Now;
        }
    }
}