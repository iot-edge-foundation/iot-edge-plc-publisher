
using libplctag;

namespace PLCPublisher
{
    public class TagDefinition
    {
        public string Name { get; set; }

        public string Gateway { get; set; }

        public string Path { get; set; }

        public string TagName { get; set; }

        public PlcType PlcType { get; set; } = PlcType.ControlLogix;

        public DataType TagType { get; set; } = DataType.DINT;

        public int ArrayLength { get; set; } = 0;
    }
}