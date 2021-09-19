using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dms.Core.Dto
{
    public class CreateAppointmentDto
    {
        public DateTime StartDateTime { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
    }

    public class AppointmentDto:CreateAppointmentDto
    {
        public int Id { get; set; }
        public PaitentDtocs Patient { get; set; }
        public DoctorDto Doctor { get; set; }


    }
}
