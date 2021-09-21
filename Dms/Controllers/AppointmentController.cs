using AutoMapper;
using Dms.Core.Dto;
using Dms.Core.Models;
using Dms.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AppointmentController> _logger;
        private readonly IMapper _mapper;

        public AppointmentController(IUnitOfWork unitOfWork, ILogger<AppointmentController> logger, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            try
            {
                _logger.LogInformation($"Attempt To Get Appointment id={id} ");
                var appointment = _unitOfWork.Apointments.GetAppointment(id);
                var results = _mapper.Map<AppointmentDto>(appointment);
                return Ok(results);
            }
            catch (Exception)
            {
                _logger.LogError($"something went wrong in {nameof(GetAppointment)}");
                return StatusCode(500, "Internal server Error");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            try
            {
                _logger.LogInformation($"Attempt To GetAll Appointments ");
                var appointments = _unitOfWork.Apointments.GetAppointments();
                var results = _mapper.Map<IList<AppointmentDto>>(appointments);
                return Ok(results);
            }
            catch (Exception)
            {
                _logger.LogError($"something went wrong in {nameof(GetAppointments)}");
                return StatusCode(500, "Internal server Error");
            }
        }

        [HttpGet]
        [Route("GetTodayAppointment")]
        public async Task<IActionResult> GetTodayAppointments([FromQuery(Name = "id")] int id)
        {
            try
            {
                _logger.LogInformation($"Attempt To Get Appointments ");
                var appointments = _unitOfWork.Apointments.GetTodaysAppointments(id);
                var results = _mapper.Map<IList<AppointmentDto>>(appointments);
                return Ok(results);
            }
            catch (Exception)
            {
                _logger.LogError($"something went wrong in {nameof(GetTodayAppointments)}");
                return StatusCode(500, "Internal server Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromBody] CreateAppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"invalid POSt in {nameof(AddAppointment)}");
                return BadRequest(ModelState);
            }
            try
            {
                _logger.LogInformation($"Attempt To Add Paitent");
                var appointment = _mapper.Map<Appointment>(appointmentDto);
                await _unitOfWork.Apointments.Insert(appointment);
                await _unitOfWork.Save();
                return CreatedAtRoute("GetPaitent", new { id = appointment.Id }, appointment);
            }
            catch (Exception)
            {
                _logger.LogError($"something went wrong in {nameof(AddAppointment)}");
                return StatusCode(500, "Internal server Error");
            }
        }




        [HttpPost]
        [Route("FilterAppointment")]
        public async Task<IActionResult> FilterAppointment([FromBody] SearchAppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"invalid POSt in {nameof(FilterAppointment)}");
                return BadRequest(ModelState);
            }
            try
            {
                _logger.LogInformation($"Attempt To Add Paitent");
                var result = _unitOfWork.Apointments.SearchAppointmentRange(appointmentDto);
                var data = _mapper.Map<IList<AppointmentDto>>(result);


                return Ok(data);
            }
            catch (Exception)
            {
                _logger.LogError($"something went wrong in {nameof(FilterAppointment)}");
                return StatusCode(500, "Internal server Error");
            }
        }
    }
}
