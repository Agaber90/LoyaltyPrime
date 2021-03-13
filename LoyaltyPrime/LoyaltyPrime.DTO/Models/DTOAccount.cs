using LoyaltyPrime.Ground;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyPrime.DTO.Models
{
    public class DTOAccount
    {
        public long? Id { get; set; }

        public long MemberId { get; set; }

        public string Name { get; set; }
        public AccountStatus Status { get; set; }

        public long Balance { get; set; }
    }
}
