
namespace PLCPublisher.Commands.ListTags.CommandRequest
{
    using libplctag;

    public class ListTagsCommandRequest
    {
        public PlcType PlcType { get; set; } = PlcType.ControlLogix;

        public string Gateway { get; set; }

        public string Path { get; set; }
    }
}