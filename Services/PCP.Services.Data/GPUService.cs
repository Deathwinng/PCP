﻿namespace PCP.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PCP.Data.Common.Repositories;
    using PCP.Data.Models.GPU;
    using PCP.Services.Mapping;

    public class GPUService : IGPUService
    {
        private readonly IDeletableEntityRepository<GPU> repository;

        public GPUService(IDeletableEntityRepository<GPU> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<T> GetAll<T>(int page, int productsPerPage)
        {
            return this.repository.AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * productsPerPage)
                .Take(productsPerPage)
                .To<T>()
                .ToList();
        }

        public T GetById<T>(string id)
        {
            return this.repository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
        }

        public int GetProductsCount()
        {
            return this.repository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetRandom<T>(int count)
        {
            return this.repository.AllAsNoTracking()
                .OrderByDescending(x => Guid.NewGuid())
                .Take(count)
                .To<T>()
                .ToList();
        }
    }
}
