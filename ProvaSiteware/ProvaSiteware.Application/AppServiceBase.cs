using Microsoft.Practices.ServiceLocation;
using ProvaSiteware.Application.Interfaces;
using ProvaSiteware.Domain.Interfaces.Repositories;
using ProvaSiteware.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaSiteware.Application
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
