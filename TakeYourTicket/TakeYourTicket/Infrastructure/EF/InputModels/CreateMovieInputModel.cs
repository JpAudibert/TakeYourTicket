using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeYourTicket.Infrastructure.EF.InputModels
{
    public class CreateMovieInputModel
    {
        [Required(ErrorMessage = "Title is required.")]
        [MinLength(5, ErrorMessage = "Invalid title length.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than 0")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Synopsis is required.")]
        [MinLength(10, ErrorMessage = "Invalid synopsis length.")]
        public string Synopsis { get; set; }
    }
}
