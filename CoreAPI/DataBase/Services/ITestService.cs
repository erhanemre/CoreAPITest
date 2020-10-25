using CoreAPI.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.DataBase.Services
{
    public interface ITestService
    {
        Task<TempTable1> Query1();

        Task<TempTable1> Query2();
            
    }
}
