
namespace PLCPublisher.Commands.ListUdtTypes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using libplctag;
    using libplctag.DataTypes;
    using Microsoft.Extensions.Logging;
    using PLCPublisher.Commands.ListUdtTypes.CommandRequest;
    using PLCPublisher.Commands.ListUdtTypes.CommandResponse;

    public class ListUdtTypesCommandHandler : CommandHandlerBase<ListUdtTypesCommandRequest, UdtType[]>
    {
        private readonly ILogger logger;

        public ListUdtTypesCommandHandler(ILogger<ListUdtTypesCommandHandler> logger)
            : base(logger)
        {
            this.logger = logger;
        }

        static bool TagIsUdt(TagInfo tag)
        {
            const ushort TYPE_IS_STRUCT = 0x8000;
            const ushort TYPE_IS_SYSTEM = 0x1000;

            return ((tag.Type & TYPE_IS_STRUCT) != 0) && !((tag.Type & TYPE_IS_SYSTEM) != 0);
        }

        static int GetUdtId(TagInfo tag)
        {
            const ushort TYPE_UDT_ID_MASK = 0x0FFF;
            return tag.Type & TYPE_UDT_ID_MASK;
        }

        protected override Task<UdtType[]> Execute(ListUdtTypesCommandRequest request)
        {
            var response = new List<UdtType>();

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

            var uniqueUdtTypeIds = tags.Value
                    .Where(tagInfo => TagIsUdt(tagInfo))
                    .Select(tagInfo => GetUdtId(tagInfo))
                    .Distinct();

            foreach (var udtId in uniqueUdtTypeIds)
            {
                using var udtTag = new Tag<UdtInfoPlcMapper, UdtInfo>()
                {
                    Gateway = request.Gateway,
                    Path = request.Path,
                    PlcType = request.PlcType,
                    Protocol = Protocol.ab_eip,
                    Name = $"@udt/{udtId}",
                };

                udtTag.Read();
                var udt = udtTag.Value;

                var type = new UdtType
                {
                    Id = udt.Id,
                    Name = udt.Name,
                    Size = udt.Size,
                };

                type.Fields.AddRange(udt.Fields.Select(x => new UdtField
                {
                    Name = x.Name,
                    Offset = x.Offset,
                    Type = x.Type,
                    Metadata = x.Metadata,
                }));

                response.Add(type);
            }

            if (tags.GetStatus() != Status.Ok)
            {
                throw new Exception($"ListUdtTypesCommandHandler.Execute({request.Gateway}.{request.Path}.{request.PlcType}) failed with status {tags.GetStatus()}");
            }

            return Task.FromResult(response.ToArray());
        }
    }
}