using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoyaltyPrime.Data.Enities
{
    public class Member : IEntity, IEntityTracker
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime Updatedate { get; set; }
    }
}
