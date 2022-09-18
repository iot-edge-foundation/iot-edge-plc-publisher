
using libplctag;
using libplctag.DataTypes;

namespace PLCPublisher.Plc
{
    public class SintPlcTag : Tag<SintPlcMapper, sbyte>, IPlcTag
    {
        object IPlcTag.Value { get => this.Value; set => this.Value = (sbyte)value; }
    }
}