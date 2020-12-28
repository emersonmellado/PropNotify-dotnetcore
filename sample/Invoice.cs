using System;

namespace PropNotify.Sample
{
    public class Invoice : IEquatable<Invoice>
    {
        public long Id { get; set; }
        public double Payment { get; set; }
        public bool Cancelled { get; set; }
        
        public bool Equals(Invoice other)
        {
            return Id == other.Id && Payment.Equals(other.Payment) && Cancelled == other.Cancelled;
        }
    }
}