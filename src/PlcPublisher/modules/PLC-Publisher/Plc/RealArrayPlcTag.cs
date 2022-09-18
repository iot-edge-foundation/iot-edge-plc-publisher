
namespace PLCPublisher.Plc
{
    using libplctag;
    using libplctag.DataTypes;

    public class RealArrayPlcTag : Tag<RealPlcMapper, float[]>, IPlcTag
    {
        public RealArrayPlcTag(int arrayLength)
        {
            this.ArrayDimensions = new [ ] { arrayLength };
        }

        object IPlcTag.Value { get => this.Value as float[]; set => this.Value = (float[])value; }
    }
}