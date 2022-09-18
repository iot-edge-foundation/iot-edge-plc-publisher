
namespace PLCPublisher.Plc
{
    using libplctag;
    using libplctag.DataTypes;

    public class SintArrayPlcTag : Tag<SintPlcMapper, sbyte[]>, IPlcTag
    {
        public SintArrayPlcTag(int arrayLength)
        {
            this.ArrayDimensions = new [ ] { arrayLength };
        }

        object IPlcTag.Value { get => this.Value as sbyte[]; set => this.Value = (sbyte[])value; }
    }
}