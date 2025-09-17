//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static DataLayer.GenericCURDOperation;

//namespace DataLayer
//{
//    internal class GenericCURDOperation
//    {
//        public class Repository<T> 
//        {
//            private readonly Clinicdb_context __context;
//            private readonly DbSet<T> _dbSet;

//            public Repository(T  _context)
//            {
              
//            }

//            public async Task<T> GetByIdAsync(int id)
//            {
//                return await _dbSet.FindAsync(id); // EF Core هيعمل SELECT FROM Table WHERE Id = ...
//            }

//            public async Task<IEnumerable<T>> GetAllAsync()
//            {
//                return await _dbSet.ToListAsync(); // EF Core هيجيب كل البيانات
//            }

//            public async Task AddAsync(T entity)
//            {
//                await _dbSet.AddAsync(entity); // EF Core هيعمل INSERT
//            }

//            public void Update(T entity)
//            {
//                _dbSet.Update(entity); // EF Core هيعمل UPDATE
//            }

//            public void Delete(T entity)
//            {
//                _dbSet.Remove(entity) // EF Core هيعمل DELETE
//            }
//        }
//    }
//}
