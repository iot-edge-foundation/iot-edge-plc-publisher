
using libplctag;
using libplctag.DataTypes;

namespace PLCPublisher.Plc
{
    public class LrealPlcTag : Tag<LrealPlcMapper, double>, IPlcTag
    {
        object IPlcTag.Value { get => this.Value; set => this.Value = (double)value; }
    }
}