using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dms.Core.Dto
{
    public class DoctorPerPaitentDto
    {
        public string name { get; set; }
        public int value { get; set; }

    }
    public class CreateDoctorDtos {
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsAvailable { get; set; }
        public string Address { get; set; }

    }
    public class DoctorDto : CreateDoctorDtos
    {
        public int Id { get; set; }
        public IList<AppointmentDto> Appointments { get; set; }


    }
}
