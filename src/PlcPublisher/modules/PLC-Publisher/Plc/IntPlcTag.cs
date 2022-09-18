
using libplctag;
using libplctag.DataTypes;

namespace PLCPublisher.Plc
{
    public class IntPlcTag : Tag<IntPlcMapper, short>, IPlcTag
    {
        object IPlcTag.Value { get => this.Value; set => this.Value = (short)value; }
    }
}