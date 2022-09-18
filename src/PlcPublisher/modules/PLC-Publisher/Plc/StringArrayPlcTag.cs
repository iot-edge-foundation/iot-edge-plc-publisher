
namespace PLCPublisher.Plc
{
    using libplctag;
    using libplctag.DataTypes;

    public class StringArrayPlcTag : Tag<StringPlcMapper, string[]>, IPlcTag
    {
        public StringArrayPlcTag(int arrayLength)
        {
            this.ArrayDimensions = new [ ] { arrayLength };
        }

        object IPlcTag.Value { get => this.Value as string[]; set => this.Value = (string[])value; }
    }
}