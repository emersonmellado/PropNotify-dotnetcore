using System;
using System.Linq;
using NUnit.Framework;
using PropNotify;
using PropNotify.Sample;
using PropNotify.Core;

namespace TrackerTests
{
    public class TrackerInvoiceTest
    {
        [Test]
        public void InvoiceCreatedTest()
        {
            var invoiceCreated = new InvoiceCreated();
            invoiceCreated.AddWatchProperty(p => p.Payment, p => p.Id);

            var tracker = new Tracker<Invoice>();
            Assert.AreEqual(0, tracker.GetObservers().Count);
            tracker.Subscribe(invoiceCreated);
            Assert.AreEqual(1, tracker.GetObservers().Count);

            AssertNotificationsCreated(tracker, 0);

            var invoice11 = new Invoice { Id = 11, Cancelled = false, Payment = 1000.0 };

            tracker.AddOrUpdate(new Invoice { Id = 11, Cancelled = false, Payment = 2000.0 });
            tracker.AddOrUpdate(invoice11);

            AssertNotificationsCreated(tracker, 1);

            Assert.AreEqual(invoice11, tracker.GetObservers().First(o => o.GetType() == typeof(InvoiceCreated)).Notifications.First().Values.First());
        }

        private static void AssertNotificationsCreated(Observable<Invoice> box, int occurrences)
        {
            AssertNotifications(box, typeof(InvoiceCreated), occurrences);
        }

        private static void AssertNotifications(Observable<Invoice> box, Type type, int occurrences)
        {
            Assert.AreEqual(occurrences, box.GetObservers().First(o => o.GetType() == type).Notifications.Count);
        }
    }
}