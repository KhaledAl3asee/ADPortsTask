using AutoMapper;
using ADPortsTask.Controllers.Bases;
using ADPortsTask.Data.Models;
using ADPortsTask.DTOs;
using ADPortsTask.DTOs.Employee;
using ADPortsTask.Helpers;
using ADPortsTask.Services;
using ADPortsTask.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADPortsTask.Controllers
{
    /// <remarks>
    /// This class-controller can add, edit, delete and getting Employee.
    /// </remarks>
    public class EmployeeController : EntityControllerBase
    {
        IEmployeeService service;
        readonly IMapper mapper;

        public EmployeeController(IEmployeeService s)
        {
            service = s;
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeBaseDto>();
                cfg.CreateMap<Employee, EmployeeMinimalDto>().ReverseMap();
            }));
        }

        /// <summary>
        /// Creating Employee
        /// <summary>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("api/Employee")]
        public async Task<IActionResult> Index()
        {
            //IsAdmin
            var models = await service.GetEmployees();
            IEnumerable <EmployeeBaseDto> dtos = mapper.Map<IEnumerable<EmployeeBaseDto>>(models);
            return Ok(dtos);
        }

        /// <summary>
        /// Getting Employee on id
        /// <summary>
        /// <param name="id">Id Employee.</param>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("api/Employee/{id}")]
        [Authorize(Roles = RoleTypes.Admin)]
        public async Task<IActionResult> Detail(int id)
        {
            EmployeeBaseDto EmployeeDto = mapper.Map<EmployeeBaseDto>(await service.GetDetail(id));
            return Ok(EmployeeDto);
        }

        /// <summary>
        /// Creating Employee
        /// <summary>
        /// <param name="EmployeeDto">Tdo model EmployeeCrUpDto.</param>
        /// <response code="201">Success created</response>
        /// <response code="400">Invalid argument</response>
        /// <response code="404">Resources or rule not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("api/Employee")]
        [Authorize(Roles = RoleTypes.Admin)]
        public async Task<IActionResult> Create([FromBody]EmployeeMinimalDto EmployeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var itemModel = mapper.Map<Employee>(EmployeeDto);

            await service.Create(UserId, itemModel);
            return Created(
                this.BaseApiUrl + "/" + itemModel.Id,
                new { EmployeeId = itemModel.Id }
            );
        }

        /// <summary>
        /// Updating Employee
        /// <summary>
        /// <param name="EmployeeDto">Tdo model EmployeeCrUpDto.</param>
        /// <response code="200">Success update</response>
        /// <response code="401">Error. Only admin and owner can update booking data</response>
        /// <respomse code="404">Error. Non exist booking id passed</respomse>
        /// <response code="500">Internal server error</response>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("api/Employee/{id}")]
        [Authorize(Roles = RoleTypes.Admin)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody]EmployeeMinimalDto EmployeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            await service.Update(id, UserId, mapper.Map<Employee>(EmployeeDto));
            return Ok("Employee updated successfully.");  
        }

        /// <summary>
        /// Deleting Employee
        /// <summary>
        /// <param name="tree">Tdo model EmployeeCrUpDto.</param>
        /// <response code="200">Success deleted</response>
        /// <response code="401">Error. Only admin and owner can update booking data</response>
        /// <respomse code="404">Error. Non exist booking id passed</respomse>
        /// <response code="500">Error. Internal server</response>
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("api/Employee/{id}")]
        [Authorize(Roles = RoleTypes.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            await service.Delete(id);
            return Ok("Employee deleted.");
        }
    }
}