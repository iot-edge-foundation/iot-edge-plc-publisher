
namespace PLCPublisher.Factories
{
    using System;
    using libplctag;
    using PLCPublisher.Plc;

    public interface ITagFactory
    {
        IPlcTag Create(TagDefinition tagDefinition, Nullable<TimeSpan> timeout = null);
    }
}