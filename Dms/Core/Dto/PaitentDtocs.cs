using Dms.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dms.Core.Dto
{
    public class CreatePaitentDtos
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Name Is Too Long")]
        public string Name { get; set; }
        [Required]
        public Gender Sex { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }


    }
    public class PaitentDtocs : CreatePaitentDtos
    {
        [Required]
        public int Id { get; set; }
        public IList<AppointmentDto> Appointments { get; set; }



    }
}
