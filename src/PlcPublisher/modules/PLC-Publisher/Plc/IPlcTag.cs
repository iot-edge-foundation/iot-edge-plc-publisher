
namespace PLCPublisher.Plc
{
    using libplctag;

    public interface IPlcTag : ITag
    {
        object Value { get; set; }
    }
}