using AutoMapper;
using Dms.Core.Dto;
using Dms.Core.Models;
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
    public class PaitentController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PaitentController> _logger;
        private readonly IMapper _mapper;


        public PaitentController(IUnitOfWork unitOfWork, ILogger<PaitentController> logger, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetPaitents()
        {
            try
            {
                _logger.LogInformation($"Attempt To Get All Paitents");
                var paitents = _unitOfWork.Paitents.GetPatients();
                var results = _mapper.Map<IList<PaitentDtocs>>(paitents);
                return Ok(results);
            }
            catch (Exception)
            {
                _logger.LogError($"something went wrong in {nameof(GetPaitents)}");
                return StatusCode(500, "Internal server Error");
            }
        }


        [HttpGet("{id:int}",Name = "GetPaitent")]
        public async Task<IActionResult> GetPaitent(int id)
        {
            try
            {
                _logger.LogInformation($"Attempt To Get Paitent id {id}");
                var paitents = _unitOfWork.Paitents.GetPatient(id);
                var results = _mapper.Map<PaitentDtocs>(paitents);
                return Ok(results);
            }
            catch (Exception)
            {
                _logger.LogError($"something went wrong in {nameof(GetPaitent)}");
                return StatusCode(500, "Internal server Error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddPaitent([FromBody] CreatePaitentDtos paitentDtos)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"invalid POSt in {nameof(AddPaitent)}");
                return BadRequest(ModelState);
            }
            try
            {
                _logger.LogInformation($"Attempt To Add Paitent");
                var paitent = _mapper.Map<Patient>(paitentDtos);
                await _unitOfWork.Paitents.Insert(paitent);
                await _unitOfWork.Save();
                return CreatedAtRoute("GetPaitent" , new { id = paitent.Id},paitent);
            }
            catch (Exception)
            {
                _logger.LogError($"something went wrong in {nameof(GetPaitents)}");
                return StatusCode(500, "Internal server Error");
            }
        }
    }

}
