
using libplctag;
using libplctag.DataTypes;

namespace PLCPublisher.Plc
{
    public class LintPlcTag : Tag<LintPlcMapper, long>, IPlcTag
    {
        object IPlcTag.Value { get => this.Value; set => this.Value = (long)value; }
    }
}