
namespace PLCPublisher.Commands.ListUdtTypes.CommandRequest
{
    using libplctag;

    public class ListUdtTypesCommandRequest
    {
        public PlcType PlcType { get; set; } = PlcType.ControlLogix;

        public string Gateway { get; set; }

        public string Path { get; set; }
    }
}