
namespace PLCPublisher.Plc
{
    using libplctag;
    using libplctag.DataTypes;

    public class IntArrayPlcTag : Tag<IntPlcMapper, short[]>, IPlcTag
    {
        public IntArrayPlcTag(int arrayLength)
        {
            this.ArrayDimensions = new [ ] { arrayLength };
        }

        object IPlcTag.Value { get => this.Value as short[]; set => this.Value = (short[])value; }
    }
}