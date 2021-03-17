using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyPrime.DTO.Models
{
    public class DTOAccountData
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public bool Status { get; set; }
    }

    public class DTOMemberData
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<DTOAccountData> Accounts { get; set; }

    }

    public class DTODownloadSearchCreateria
    {
        public bool Status { get; set; }

        public decimal Points { get; set; }
    }
}
