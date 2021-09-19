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


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPaitent(int id)
        {
            try
            {
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
    }
}
