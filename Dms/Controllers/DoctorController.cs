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

    
        [HttpGet("/avaliableDoctors")]
        public async Task<IActionResult> GetAvaliableDoctors()
        {
            try
            {
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            try
            {
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
