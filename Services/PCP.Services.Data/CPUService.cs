namespace PCP.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PCP.Data.Common.Repositories;
    using PCP.Data.Models.CPU;
    using PCP.Services.Mapping;

    public class CPUService : ICPUService
    {
        private readonly IDeletableEntityRepository<CPU> cpuRepo;

        public CPUService(IDeletableEntityRepository<CPU> cpuRepo)
        {
            this.cpuRepo = cpuRepo;
        }

        public IEnumerable<T> GetAll<T>(int page, int productsPerPage)
        {
            return this.cpuRepo.AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * productsPerPage)
                .Take(productsPerPage)
                .To<T>()
                .ToList();
        }

        public T GetById<T>(string id)
        {
            return this.cpuRepo.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
        }

        public int GetProductsCount()
        {
            return this.cpuRepo.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetRandom<T>(int count)
        {
            return this.cpuRepo.AllAsNoTracking()
                .OrderByDescending(x => Guid.NewGuid())
                .Take(count)
                .To<T>()
                .ToList();
        }
    }
}
