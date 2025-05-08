using Loyalty.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Domain.Users.Entities
{
    public class Point : BaseEntity<long>
    {
        public int Amount { get; private set; }
        internal Point(int amount)
        {
            Amount = amount;
        }
    }
}
