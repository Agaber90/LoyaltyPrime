using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyPrime.Data
{
    public interface IEntity
    {
        long ID { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
