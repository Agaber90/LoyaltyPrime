using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyPrime.Data
{
    public interface IEntityTracker
    {
        DateTime Createdate { get; set; }
        DateTime Updatedate { get; set; }
        string Creator { get; set; }
        string Updator { get; set; }
    }
}
