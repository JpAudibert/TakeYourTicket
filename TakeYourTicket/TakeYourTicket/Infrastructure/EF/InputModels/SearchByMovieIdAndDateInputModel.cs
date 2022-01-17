using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeYourTicket.Infrastructure.EF.InputModels
{
    public class SearchByMovieIdAndDateInputModel
    {
        public string MovieId { get; set; }
        public DateTime? Date { get; set; }
    }
}
