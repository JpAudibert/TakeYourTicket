using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeYourTicket.Infrastructure.EF.InputModels
{
    public class UpdateMovieInputModel
    {
        [MinLength(5, ErrorMessage = "Invalid title length.")]
        public string Title { get; set; }

        public int Duration { get; set; }

        [MinLength(10, ErrorMessage = "Invalid synopsis length.")]
        public string Synopsis { get; set; }
    }
}
