
namespace PLCPublisher.Commands.ListUdtTypes.CommandResponse
{
    public class UdtField
    {
        public string Name { get; set; }

        public uint Offset { get; set; }

        public ushort Metadata { get; set; }

        public ushort Type { get; set; }
    }
}