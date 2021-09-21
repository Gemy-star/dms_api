using System;
using System.Collections.Generic;
using System.Linq;
using Dms.Core.Dto;
using Dms.Core.Models;
using Dms.Core.ViewModel;

namespace Dms.Core.IRepository
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        IList<DoctorPerPaitentDto> GetDoctorPerPaiitent();

        IList<Appointment> SearchAppointmentRange(SearchAppointmentDto search);

        IEnumerable<Appointment> GetAppointments();
        IEnumerable<Appointment> GetAppointmentWithPatient(int id);
        IEnumerable<Appointment> GetAppointmentByDoctor(int id);
        IEnumerable<Appointment> GetTodaysAppointments(int id);
        IEnumerable<Appointment> GetUpcommingAppointments(int userId);
        IEnumerable<Appointment> GetDaillyAppointments(DateTime getDate);
        IQueryable<Appointment> FilterAppointments(AppointmentSearchVM searchModel);
        bool ValidateAppointment(DateTime appntDate, int id);
        int CountAppointments(int id);
        Appointment GetAppointment(int id);
        void Add(Appointment appointment);

    }
}