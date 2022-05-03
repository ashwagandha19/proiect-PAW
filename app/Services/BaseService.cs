﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.Repository.Interfaces;

namespace library.Services
{
    public class BaseService
    {
        protected IRepositoryWrapper repositoryWrapper;
        public BaseService(IRepositoryWrapper iRepositoryWrapper)
        {
            repositoryWrapper = iRepositoryWrapper;
        }

        public void Save()
        {
            repositoryWrapper.Save();
        }
    }
}
