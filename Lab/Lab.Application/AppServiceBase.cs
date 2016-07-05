using Microsoft.Practices.ServiceLocation;
using Lab.Application.Interfaces;
using Lab.Domain.Interfaces.Repositories;
using Lab.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Application
{
    public abstract class AppServiceBase
    {
        public IUnitOfWork BeginTransaction()
        {
            var unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>();

            unitOfWork.BeginTransaction();

            return unitOfWork;
        }
    }
}
