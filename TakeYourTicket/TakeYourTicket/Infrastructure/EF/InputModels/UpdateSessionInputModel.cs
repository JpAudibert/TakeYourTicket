using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeYourTicket.Infrastructure.EF.InputModels
{
    public class UpdateSessionInputModel
    {
        public int NumberOfSeats { get; set; }
        public double Price { get; set; }
        public DateTime ExhibitionDate { get; set; }
        public string MovieId { get; set; }
    }
}
