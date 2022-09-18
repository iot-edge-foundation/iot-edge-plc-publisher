
using libplctag;
using libplctag.DataTypes;

namespace PLCPublisher.Plc
{
    public class DintPlcTag : Tag<DintPlcMapper, int>, IPlcTag
    {
        object IPlcTag.Value { get => this.Value; set => this.Value = (int)value; }
    }
}