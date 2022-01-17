using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeYourTicket.Infrastructure.EF.InputModels
{
    public class CreateSaleInputModel
    {
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Quantity must be at least 0")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "SessionId is required.")]
        public string SessionId { get; set; }
    }
}
