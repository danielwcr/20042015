using Lab.Domain.Interfaces.Repositories;
using Microsoft.Practices.ServiceLocation;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace Lab.Application.Aspect
{
    [MulticastAttributeUsage(MulticastTargets.Method)]
    [Serializable]
    public class UnitOfWorkAspect : OnMethodBoundaryAspect
    {
        protected IUnitOfWork unitOfWork;

        public override void OnEntry(PostSharp.Aspects.MethodExecutionArgs args)
        {
            unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            unitOfWork.BeginTransaction();

            base.OnEntry(args);
        }

        public override void OnExit(PostSharp.Aspects.MethodExecutionArgs args)
        {
            unitOfWork.Dispose();

            base.OnExit(args);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            unitOfWork.Commit();

            base.OnSuccess(args);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            unitOfWork.Rollback();

            base.OnException(args);
        }
    }
}