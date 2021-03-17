using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoyaltyPrime.Data.Enities
{
    public class Account : IEntity, IEntityTracker
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }

        [ForeignKey("Member")]
        public long MemberId { get; set; }
        public virtual Member Member { get; set; }
        public decimal Balance { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime Updatedate { get; set; }

        public bool IsRedeemedPoint { get; set; } = false;
    }
}
