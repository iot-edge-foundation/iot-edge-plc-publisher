
namespace PLCPublisher.Commands.ListPrograms.CommandRequest
{
    using libplctag;

    public class ListProgramsCommandRequest
    {
        public PlcType PlcType { get; set; } = PlcType.ControlLogix;

        public string Gateway { get; set; }

        public string Path { get; set; }
    }
}