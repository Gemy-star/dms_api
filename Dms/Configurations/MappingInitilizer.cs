using AutoMapper;
using Dms.Core.Dto;
using Dms.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dms.Configurations
{
    public class MappingInitilizer:Profile
    {
        public MappingInitilizer()
        {
            CreateMap<Patient, PaitentDtocs>().ReverseMap();
            CreateMap<Patient, CreatePaitentDtos>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Doctor, CreateDoctorDtos>().ReverseMap();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Appointment, CreateAppointmentDto>().ReverseMap();
            CreateMap<Specialization, SpecializationDto>().ReverseMap();
            CreateMap<Specialization, CreateSpecializationDto>().ReverseMap();
            CreateMap<PatientStatus, PaitentStatusDto>().ReverseMap();
            CreateMap<PatientStatus, CreatePaitentStatusDto>().ReverseMap();



        }
    }
}
