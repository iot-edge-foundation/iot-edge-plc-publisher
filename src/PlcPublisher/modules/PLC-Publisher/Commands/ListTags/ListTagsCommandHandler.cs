
namespace PLCPublisher.Commands.ListTags
{
    using System;
    using System.Threading.Tasks;
    using libplctag;
    using libplctag.DataTypes;
    using Microsoft.Extensions.Logging;
    using PLCPublisher.Commands.ListTags.CommandRequest;

    public class ListTagsCommandHandler : CommandHandlerBase<ListTagsCommandRequest, TagInfo[]>
    {
        private readonly ILogger logger;

        public ListTagsCommandHandler(ILogger<ListTagsCommandHandler> logger)
            : base(logger)
        {
            this.logger = logger;
        }

        protected override Task<TagInfo[]> Execute(ListTagsCommandRequest request)
        {
            using var tags = new Tag<TagInfoPlcMapper, TagInfo[]>()
            {
                Gateway = request.Gateway,
                Path = request.Path,
                PlcType = request.PlcType,
                Protocol = Protocol.ab_eip,
                Name = "@tags",
                Timeout = base.Request.ResponseTimeout ?? TimeSpan.FromSeconds(30)
            };

            tags.Read();

            if (tags.GetStatus() != Status.Ok)
            {
                throw new Exception($"ListTagsCommandHandler.Execute({request.Gateway}.{request.Path}.{request.PlcType}) failed with status {tags.GetStatus()}");
            }

            return Task.FromResult(tags.Value);
        }
    }
}