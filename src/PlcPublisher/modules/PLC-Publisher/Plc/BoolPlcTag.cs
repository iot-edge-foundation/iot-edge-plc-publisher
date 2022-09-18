
namespace PLCPublisher.Plc
{
    using libplctag;
    using libplctag.DataTypes;

    public class BoolPlcTag : Tag<BoolPlcMapper, bool>, IPlcTag
    {
        object IPlcTag.Value { get => (bool)this.Value; set => this.Value = (bool)value; }
    }
}