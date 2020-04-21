using System;
using System.Linq;
using FluentAssertions;
using Flunt.Notifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class SubscriptionTests
    {
        [TestMethod]
        public void ShouldCreateSubscriptionActive()
        {
            var subscription = new Subscription(null);
            subscription.IsActive.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldDeactivateSubscriptionAndUpdateLastUpdateDate()
        {
            var subscription = new Subscription(null);
            var creationDate = subscription.LastUpdate;

            subscription.Deactivate();
            subscription.IsActive.Should().BeFalse();
            subscription.LastUpdate.Should().BeAfter(creationDate);
        }

        [TestMethod]
        public void ShouldActivateSubscriptionAndUpdateLastUpdateDate()
        {
            var subscription = new Subscription(null);
            var creationDate = subscription.LastUpdate;

            subscription.Deactivate();
            subscription.Activate();

            subscription.IsActive.Should().BeTrue();
            subscription.LastUpdate.Should().BeAfter(creationDate);
        }

        [TestMethod]
        public void ShouldAddPayment()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment(DateTime.Now.AddDays(-1), DateTime.Now, 100, 100, string.Empty, null, null, null, string.Empty);

            subscription.AddPayment(payment);

            subscription.Payments.Count.Should().Be(1);
            subscription.Payments.First().Should().BeEquivalentTo(payment);
        }

        [TestMethod]
        public void ShouldNotAddPaymentWhenPaidDateIsGreatherThanCurrentDate()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment(DateTime.Now.AddDays(+1), DateTime.Now, 100, 100, string.Empty, null, null, null, string.Empty);

            var notification = new Notification("Subscription.Payments", "The paid date must be greater than current date.");

            subscription.AddPayment(payment);

            subscription.Payments.Count.Should().Be(0);
            subscription.Invalid.Should().BeTrue();
            subscription.Notifications.Count.Should().Be(1);
            subscription.Notifications.First().Should().BeEquivalentTo(notification);
        }
    }
}