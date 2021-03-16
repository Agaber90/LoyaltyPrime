using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyPrime.DTO.Models
{
    public class DTOAccountData
    {
        public string Name { get; set; }
        public int Balance { get; set; }
        public string Status { get; set; }
    }

    public class DTOMemberData
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<DTOAccountData> Accounts { get; set; }

    }
