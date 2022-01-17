using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeYourTicket.Infrastructure.EF.InputModels
{
    public class CreateSessionInputModel
    {
        [Required(ErrorMessage = "Number of seats is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of seats must be greater than 0")]
        public int NumberOfSeats { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be at least 0")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Exhibition date is required.")]
        public DateTime ExhibitionDate { get; set; }

        [Required(ErrorMessage = "MovieId is required.")]
        public string MovieId { get; set; }
    }
}
