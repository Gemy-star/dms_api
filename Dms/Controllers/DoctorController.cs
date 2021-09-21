using AutoMapper;
using Dms.Core.Dto;
using Dms.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DoctorController> _logger;
        private readonly IMapper _mapper;


        public DoctorController(IUnitOfWork unitOfWork , ILogger<DoctorController> logger , IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            try
            {
                _logger.LogInformation($"Attempt To GetAll Doctors ");
                var doctors = _unitOfWork.Doctors.GetDectors();
                var results = _mapper.Map<IList<DoctorDto>>(doctors);
                return Ok(results);
            }
            catch (Exception)
            {
                _logger.LogError($"something went wrong in {nameof(GetDoctors)}");
                return StatusCode(500, "Internal server Error");
            }
        }



        [HttpGet]
        [Route("GetDoctorPerPaitent")]
        public async Task<IActionResult> GetDoctorPerPaitent()
        {
            try
            {
                _logger.LogInformation($"Attempt for Get Avaliable Doctors ");
                var doctors = _unitOfWork.Apointments.GetDoctorPerPaiitent();

                return Ok(doctors);
            }
            catch (Exception)
            {
                _logger.LogError($"something went wrong in {nameof(GetDoctorPerPaitent)}");
                return StatusCode(500, "Internal server Error");
            }
        }


        [HttpGet]
        [Route("GetAvaliableDoctors")]
        public async Task<IActionResult> GetAvaliableDoctors()
        {
            try
            {
                _logger.LogInformation($"Attempt for Get Avaliable Doctors ");
                var doctors = _unitOfWork.Doctors.GetAvailableDoctors();
                var results = _mapper.Map<IList<DoctorDto>>(doctors);
                return Ok(results);
            }
            catch (Exception)
            {
                _logger.LogError($"something went wrong in {nameof(GetAvaliableDoctors)}");
                return StatusCode(500, "Internal server Error");
            }
        }


        [HttpGet]
        [Route("GetDoctorById")]
        public async Task<IActionResult> GetDoctor([FromQuery(Name ="id")]int id)
        {
            try
            {
                _logger.LogInformation($"Attempt To Get Doctor {id} ");
                var doctors = _unitOfWork.Doctors.GetDoctor(id);
                var results = _mapper.Map<DoctorDto>(doctors);
                return Ok(results);
            }
            catch (Exception)
            {
                _logger.LogError($"something went wrong in {nameof(GetDoctor)}");
                return StatusCode(500, "Internal server Error");
            }
        }


    }
}
