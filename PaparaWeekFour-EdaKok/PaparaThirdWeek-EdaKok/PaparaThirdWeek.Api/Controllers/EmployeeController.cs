using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaparaThirdWeek.Domain;
using PaparaThirdWeek.Domain.Entities;
using PaparaThirdWeek.Services.Abstracts;
using PaparaThirdWeek.Services.Concretes;
using PaparaThirdWeek.Services.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaparaThirdWeek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.mapper = mapper;

        }




        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var companies = await employeeService.GetAll();

                return Ok();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500);
            }
        }

        [HttpGet("{id}", Name = "EmployeeById")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var employee = await employeeService.Get(id);
                if (employee==null)
                    return NotFound();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Employee employee)
        {
            try
            {
                var emp = await employeeService.Update(employee);
                return Ok();

            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500);
            }
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Remove(Employee employee,int id)
        {
            try
            {
                var emp = await employeeService.Get(id);
                    if (emp==null)
                    return NotFound();

                await employeeService.Remove(emp);
                return Ok();


            }
            catch
            {
                return StatusCode(500);
            }
        }       

    }
}


      
