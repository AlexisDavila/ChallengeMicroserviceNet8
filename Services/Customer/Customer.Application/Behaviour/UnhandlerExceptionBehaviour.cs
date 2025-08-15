using System;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Customer.Application.Behaviour;

public class UnhandlerExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
   where TRequest : IRequest<TResponse>
{
   private readonly ILogger<TRequest> _logger;
   public UnhandlerExceptionBehaviour(ILogger<TRequest> logger)
   {
      _logger = logger;
   }

   public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
   {
      try
      {
         return await next();
      }
      catch (Exception ex)
      {
         var requestName = typeof(TRequest).Name;
         // Log the exception with the request name
         _logger.LogError(ex, $"Unhandled exception occurred while processing the request {requestName}, {request}");
         throw; 
      }
   }
}
