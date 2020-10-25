using CoreAPI.DataBase.Context;
using CoreAPI.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.DataBase.Services
{
    public class TestService : ITestService
    {
        private OracleContext _context;
        public TestService(OracleContext context)
        {
            this._context = context;
        }
        public async Task<TempTable1> Query1()
        {
            IQueryable<TempTable1> query = _context.Set<TempTable1>();
            query = query.Where(i => _context.TempTable2.Any(x => x.Flag == 1 && i.EntityCode == x.EntityCode));
            query = query.Where(i => i.Id == 0);
            var result = await query.FirstOrDefaultAsync();
            return result;
        }

        public async Task<TempTable1> Query2()
        {
            IQueryable<TempTable1> query = _context.Set<TempTable1>();
            //query = query.Where(i => _context.TempTable2.Any(x => x.Flag == 1 && i.EntityCode == x.EntityCode));
            query = query.Where(i => i.Id == 0);
            var result = await query.FirstOrDefaultAsync();
            return result;

        }
    }
}
