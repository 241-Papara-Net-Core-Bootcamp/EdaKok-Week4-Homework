using Dapper;
using Microsoft.EntityFrameworkCore;
using PaparaThirdWeek.Data.Abstracts;
using PaparaThirdWeek.Data.Context;
using PaparaThirdWeek.Domain;
using PaparaThirdWeek.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaparaThirdWeek.Data.Concretes
{
    public class Repository<T> : IRepository <T> where T : BaseEntity
    {
        private readonly DapperContext context;
        public Repository(DapperContext context)
        {
            this.context = context;
        }


        /*  public AppDbContext Context { get; }
          public Repository(AppDbContext context)
          {
              Context = context;
          }
          public void Add(T entity)
          {
              Context.Set<T>().Add(entity);
              Context.SaveChanges();

          }

          public IQueryable<T> Get()
          {
              return Context.Set<T>()
                  .Where(x => !x.IsDeleted)
                  .AsQueryable();

          }

          public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
          {
              return Context.Set<T>()
                  .Where(expression)
                  .AsQueryable();
          }

          public void HardRemove(T entity)
          {
              T existData = Context.Set<T>().Find(entity.Id);
              if (existData != null)
              {
                  Context.Set<T>().Remove(existData);
                  Context.SaveChanges();
              }
          }

          public void Remove(T entity)
          {
              T existData = Context.Set<T>().Find(entity.Id);
              if (existData != null)
              {
                  existData.IsDeleted = true;
                  Context.Entry(existData).State = EntityState.Modified;
                  Context.SaveChanges();
              }
          }

          public void Update(T entity)
          {
              Context.Entry(entity).State = EntityState.Modified;
              Context.SaveChanges();
          }
        */
       public async  Task<int> Add(Employee entity)

        {
            var query = "INSERT INTO Employees (Name , Adress , City , Email, TaxNumber)VALUES (@Name,@Adress ,@City, @Email, @TaxNumber)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", entity.Name, DbType.String);
            parameters.Add("Adress",entity.Adress, DbType.String);
            parameters.Add("City", entity.City, DbType.String);
            parameters.Add("Email", entity.Email, DbType.String);
            parameters.Add("TaxNumber", entity.TaxNumber, DbType.String);
            

            using (var connection = context.CreateConnection())
            {
                return (await connection.ExecuteAsync(query, parameters));
            }
           
        }

        public Task<int> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> Get(int id)
        {

            var query = "SELECT * FROM Employees Where Id= @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using (var connection = context.CreateConnection())
            {
               return ( await connection.QuerySingleOrDefaultAsync<Employee>(query, parameters));
              

            }
                
        }

        public async Task<List<Employee>> GetAll()
        {
            var query = "SELECT * FROM Employees";

            using ( var connection= context.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>(query);
                return employees.ToList();
            }
           
        }

        public async Task<int> Remove(Employee entity)
        {

            var query = "DELETE FROM Employees WHERE Id= @Id";
            var parameters = new DynamicParameters();
            using (var connection = context.CreateConnection())
            {
              return (await connection.ExecuteAsync(query, parameters));
            }

                
        }

        public Task<int> Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update( Employee entity)
        {
            var query = "INSERT INTO Employees (Name , Adress , City , Email, TaxNumber)VALUES (@Name,@Adress ,@City, @Email, @TaxNumber)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", entity.Name, DbType.String);
            parameters.Add("Adress", entity.Adress, DbType.String);
            parameters.Add("City", entity.City, DbType.String);
            parameters.Add("Email", entity.Email, DbType.String);
            parameters.Add("TaxNumber", entity.TaxNumber, DbType.String);


            using (var connection = context.CreateConnection())
            {
               return( await connection.ExecuteAsync(query, parameters));
            }

           
        }

        public Task<int> Update(T entity)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository<T>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<T>> IRepository<T>.GetAll()
        {
            throw new NotImplementedException();
        }
    }

}
