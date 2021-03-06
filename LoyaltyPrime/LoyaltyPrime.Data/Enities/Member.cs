using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoyaltyPrime.Data.Enities
{
    public class Member : IEntity
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
