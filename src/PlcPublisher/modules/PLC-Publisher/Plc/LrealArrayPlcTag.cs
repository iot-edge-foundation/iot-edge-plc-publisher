
namespace PLCPublisher.Plc
{
    using libplctag;
    using libplctag.DataTypes;

    public class LrealArrayPlcTag : Tag<LrealPlcMapper, double[]>, IPlcTag
    {
        public LrealArrayPlcTag(int arrayLength)
        {
            this.ArrayDimensions = new [ ] { arrayLength };
        }

        object IPlcTag.Value { get => this.Value as double[]; set => this.Value = (double[])value; }
    }
}