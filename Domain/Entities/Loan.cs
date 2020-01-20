using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Domain.Entities
{
    public class Loan
    {
        public int LoanId { get; set; }

        public Occupancy Occupancy { get; set; }

        public Purpose Purpose { get; set; }

        public PropertyType PropertyType { get; set; }
    }
}
