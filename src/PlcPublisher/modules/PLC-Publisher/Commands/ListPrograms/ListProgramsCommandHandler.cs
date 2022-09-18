
namespace PLCPublisher.Commands.ListPrograms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using libplctag;
    using libplctag.DataTypes;
    using Microsoft.Extensions.Logging;
    using PLCPublisher.Commands.ListPrograms.CommandRequest;

    public class ListProgramsCommandHandler : CommandHandlerBase<ListProgramsCommandRequest, string[]>
    {
        private readonly ILogger logger;

        public ListProgramsCommandHandler(ILogger<ListProgramsCommandHandler> logger)
            : base(logger)
        {
            this.logger = logger;
        }

        static bool TagIsProgram(TagInfo tag, out string prefix)
        {
            if (tag.Name.StartsWith("Program:"))
            {
                prefix = tag.Name;
                return true;
            }
            else
            {
                prefix = string.Empty;
                return false;
            }
        }

        protected override Task<string[]> Execute(ListProgramsCommandRequest request)
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
                throw new Exception($"ListProgramsMethodHandler.Execute({request.Gateway}.{request.Path}.{request.PlcType}) failed with status {tags.GetStatus()}");
            }

            var programs = new List<string>();

            foreach (var tag in tags.Value)
            {
                if (TagIsProgram(tag, out string programTagListingPrefix))
                {
                    using var programsTag = new Tag<TagInfoPlcMapper, TagInfo[]>()
                    {
                        Gateway = request.Gateway,
                        Path = request.Path,
                        PlcType = request.PlcType,
                        Protocol = Protocol.ab_eip,
                        Name = $"{programTagListingPrefix}.@tags",
                        Timeout = TimeSpan.FromSeconds(10)
                    };

                    programsTag.Read();

                    programs.AddRange(programsTag.Value.Select(x => x.Name));
                }
            }

            return Task.FromResult(programs.ToArray());
        }
    }
}