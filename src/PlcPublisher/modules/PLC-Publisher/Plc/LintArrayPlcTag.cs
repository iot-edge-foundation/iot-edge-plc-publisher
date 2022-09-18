
namespace PLCPublisher.Plc
{
    using libplctag;
    using libplctag.DataTypes;

    public class LintArrayPlcTag : Tag<LintPlcMapper, long[]>, IPlcTag
    {
        public LintArrayPlcTag(int arrayLength)
        {
            this.ArrayDimensions = new [ ] { arrayLength };
        }

        object IPlcTag.Value { get => this.Value as long[]; set => this.Value = (long[])value; }
    }
}