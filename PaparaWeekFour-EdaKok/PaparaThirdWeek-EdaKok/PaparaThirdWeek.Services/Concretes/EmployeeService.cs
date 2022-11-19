using PaparaThirdWeek.Data.Abstracts;
using PaparaThirdWeek.Domain.Entities;
using PaparaThirdWeek.Services.Abstracts;
using PaparaThirdWeek.Services.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaThirdWeek.Services.Concretes
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public async Task<List<Employee>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task<Employee> Get(int id)
        {
            return await _employeeRepository.Get(id)
;
        }

        public async Task<int> Add(Employee employee)
        {
            return await _employeeRepository.Add(employee);
        }

        public async Task<int> Update(Employee employee)
        {
            return await _employeeRepository.Update(employee);
        }
        public async Task<int> Remove(Employee employee)
        {
            return await _employeeRepository.Remove(employee);
        }

       

    }
}
