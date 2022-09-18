
namespace PLCPublisher.Commands.ListUdtTypes.CommandResponse
{
    using System.Collections.Generic;

    public class UdtType
    {
        public ushort Id { get; set; }

        public string Name { get; set; }

        public uint Size { get; set; }

        public List<UdtField> Fields { get; set; } = new List<UdtField>();
    }
}