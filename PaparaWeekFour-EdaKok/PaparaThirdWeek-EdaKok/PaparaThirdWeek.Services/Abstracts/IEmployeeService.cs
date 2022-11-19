using PaparaThirdWeek.Domain.Entities;
using PaparaThirdWeek.Services.DTOS;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaparaThirdWeek.Services.Abstracts
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetAll();
        public Task<Employee> Get(int id);
        public Task<int> Add(Employee employee);
        public Task<int> Update(Employee employee);
        public Task<int> Remove(Employee employee);


    }


    
}
