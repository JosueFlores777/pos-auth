using Dominio.Service;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Infraestructura.Filters
{
    public class UnitOfWordFilter : IActionFilter
    {
        private readonly IUnitOfWork unitOfWork;

        public UnitOfWordFilter(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Exception exception = context.Exception;

            if (exception == null)
            {
                unitOfWork.Save();
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           
        }
    }
}
