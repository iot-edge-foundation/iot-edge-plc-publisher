
using libplctag;
using libplctag.DataTypes;

namespace PLCPublisher.Plc
{
    public class StringPlcTag : Tag<StringPlcMapper, string>, IPlcTag
    {
        object IPlcTag.Value { get => this.Value; set => this.Value = (string)value; }
    }
}