﻿using DataCentre.Api.Contracts;
using DataCentre.Api.Contracts.Supplier;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.Entity.Models.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Repository.Supplier
{
    public class SupplierContactDataRepository : RepositoryBase<SupplierContact>, ISupplierContactDataRepository
    {
        public SupplierContactDataRepository(DapperContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}