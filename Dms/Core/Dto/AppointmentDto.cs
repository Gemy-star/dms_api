using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dms.Core.Dto
{
    public class SearchAppointmentDto
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int DoctorId { get; set; }


    }
    public class CreateAppointmentDto
    {
        public DateTime StartDateTime { get; set; }
        public string Detail { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

    }

    public class AppointmentDto:CreateAppointmentDto
    {
        public int Id { get; set; }
        public PaitentDtocs Patient { get; set; }
        public DoctorDto Doctor { get; set; }


    }
}
