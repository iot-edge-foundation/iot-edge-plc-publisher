
namespace PLCPublisher.Plc
{
    using libplctag;
    using libplctag.DataTypes;

    public class DintArrayPlcTag : Tag<DintPlcMapper, int[]>, IPlcTag
    {
        public DintArrayPlcTag(int arrayLength)
        {
            this.ArrayDimensions = new [ ] { arrayLength };
        }

        object IPlcTag.Value { get => this.Value as int[]; set => this.Value = (int[])value; }
    }
}