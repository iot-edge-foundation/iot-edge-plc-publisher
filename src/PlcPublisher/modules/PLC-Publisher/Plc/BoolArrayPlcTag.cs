
namespace PLCPublisher.Plc
{
    using libplctag;
    using libplctag.DataTypes;

    public class BoolArrayPlcTag : Tag<BoolPlcMapper, bool[]>, IPlcTag
    {
        public BoolArrayPlcTag(int arrayLength)
        {
            this.ArrayDimensions = new [ ] { arrayLength };
        }

        object IPlcTag.Value { get => this.Value as bool[]; set => this.Value = (bool[])value; }
    }
}