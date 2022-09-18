
namespace PLCPublisher.Commands.ReadArray
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using PLCPublisher.Commands;
    using PLCPublisher.Commands.ReadArray.CommandRequest;
    using PLCPublisher.Commands.ReadArray.CommandResponse;
    using PLCPublisher.Factories;

    public class ReadArrayCommandHandler : CommandHandlerBase<ReadArrayCommandRequest, ReadArrayResponse>
    {
        private readonly ILogger<ReadArrayCommandHandler> logger;

        private readonly ITagFactory tagFactory;

        public ReadArrayCommandHandler(ILogger<ReadArrayCommandHandler> logger, ITagFactory tagFactory)
            : base(logger)
        {
            this.logger = logger;
            this.tagFactory = tagFactory;
        }

        protected override async Task<ReadArrayResponse> Execute(ReadArrayCommandRequest request)
        {
            this.logger.LogDebug("Reading array {0} from PLC {1}.{2}", request.TagName, request.Gateway, request.Path);

            var myTag = this.tagFactory.Create(request);

            await myTag.ReadAsync();

            var response = new ReadArrayResponse()
            {
                Value = myTag.Value as int[]
            };

            return response;
        }
    }
}