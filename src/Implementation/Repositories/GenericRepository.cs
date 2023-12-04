﻿using Abstraction.IRepositories;
using Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Repositories
{
    public class GenericRepository<T> :IGenericRepository<T> where T : class
    {
        protected readonly CoreContext _context;
        public GenericRepository(CoreContext context)
        {
            _context = context;
        }
        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }
        public async Task<T> Delete(T entity) {  
            _context.Set<T>().Remove(entity);
            return entity;
        }
        public async Task<T> GetByID(string ID) {
            return await _context.Set<T>().FindAsync(ID);
        }
        public async Task<IEnumerable<T>> GetAll() {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
