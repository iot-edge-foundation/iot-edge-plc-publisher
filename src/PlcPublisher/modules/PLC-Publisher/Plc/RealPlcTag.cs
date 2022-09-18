
using libplctag;
using libplctag.DataTypes;

namespace PLCPublisher.Plc
{
    public class RealPlcTag : Tag<RealPlcMapper, float>, IPlcTag
    {
        object IPlcTag.Value { get => this.Value; set => this.Value = (float)value; }
    }
}