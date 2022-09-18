
namespace PLCPublisher.Commands.ReadTag
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using PLCPublisher.Commands;
    using PLCPublisher.Commands.ReadTag.CommandRequest;
    using PLCPublisher.Commands.ReadTag.CommandResponse;
    using PLCPublisher.Factories;

    public class ReadTagCommandHandler : CommandHandlerBase<ReadTagCommandRequest, ReadTagResponse>
    {
        private readonly ITagFactory tagFactory;

        public ReadTagCommandHandler(ILogger<ReadTagCommandHandler> logger, ITagFactory tagFactory)
            : base(logger)
        {
            this.tagFactory = tagFactory;
        }

        protected override async Task<ReadTagResponse> Execute(ReadTagCommandRequest request)
        {
            this.Logger.LogDebug("Reading tag {0} from PLC {1}.{2}", request.TagName, request.Gateway, request.Path);

            using var myTag = this.tagFactory.Create(request);

            await myTag.ReadAsync();

            return new ReadTagResponse()
            {
                Value = myTag.Value
            };
        }
    }
}