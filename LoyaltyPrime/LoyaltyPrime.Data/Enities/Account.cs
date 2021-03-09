using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoyaltyPrime.Data.Enities
{
    public class Account : IEntity, IEntityTracker
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public virtual Member Member { get; set; }
        public long Balance { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime Updatedate { get; set; }
    }
}
