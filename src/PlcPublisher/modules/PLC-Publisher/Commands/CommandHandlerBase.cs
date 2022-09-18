
namespace PLCPublisher.Commands
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.Devices.Client;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    public abstract class CommandHandlerBase<TRequest, TResponse> : ICommandHandler
        where TRequest : class
        where TResponse : class
    {
        
        protected ILogger Logger { get; private set;}

        protected MethodRequest Request { get; private set; }

        protected CommandHandlerBase(ILogger logger)
        {
            this.Logger = logger;
        }

        protected abstract Task<TResponse> Execute(TRequest request);

        public async Task<MethodResponse> Handle(MethodRequest methodRequest)
        {
            this.Logger.LogInformation($"{this.GetType().Name}.Handle()");

            this.Request = methodRequest;

            try
            {
                var request = JsonConvert.DeserializeObject<TRequest>(methodRequest.DataAsJson);

                var response = await this.Execute(request);
                
                return new MethodResponse(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response)), 200);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, $"{this.GetType().Name}.Handle()");

                return new MethodResponse(500);
            }
        }
    }
}