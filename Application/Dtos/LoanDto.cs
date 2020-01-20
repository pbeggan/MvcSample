using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Entities;

namespace Application.Dtos
{
    public class LoanDto
    {
        public Occupancy Occupancy { get; set; }

        public Purpose Purpose { get; set; }

        public PropertyType PropertyType { get; set; }

        public Loan Map()
        {
            return new Loan
            {
                Occupancy = Occupancy,
                Purpose = Purpose,
                PropertyType = PropertyType
            };
        }
    }
}
