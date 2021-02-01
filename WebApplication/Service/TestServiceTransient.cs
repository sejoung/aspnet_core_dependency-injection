using Microsoft.Extensions.Logging;
using WebApplication.DILifeTime;

namespace WebApplication.Service
{
	public class TestServiceTransient
	{
		private readonly ILogger<TestServiceTransient> _logger;
		private readonly IOperationTransient _transientOperation;
		private readonly IOperationSingleton _singletonOperation;
		private readonly IOperationScoped _scopedOperation;

		public TestServiceTransient(ILogger<TestServiceTransient> logger, IOperationTransient transientOperation, IOperationSingleton singletonOperation, IOperationScoped scopedOperation)
		{
			_logger = logger;
			_transientOperation = transientOperation;
			_singletonOperation = singletonOperation;
			_scopedOperation = scopedOperation;
		}
		
		public void Get()
		{
			_logger.LogInformation($"Transient: {_transientOperation.OperationId}");
			_logger.LogInformation($"Scoped: {_scopedOperation.OperationId}");
			_logger.LogInformation($"Singleton: {_singletonOperation.OperationId}");
		}
	}
}