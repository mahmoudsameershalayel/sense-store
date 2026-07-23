using Sense.Application.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.WalletDTOs
{
    public class WalletForCreateDto
    {
        public double Balance { get; set; }
        public DateTime? CreatedAt{ get; set; }

        public int CustomerId { get; set; }

    }
}
