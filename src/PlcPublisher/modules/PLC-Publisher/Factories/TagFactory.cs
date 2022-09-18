

namespace PLCPublisher.Factories
{
    using System;
    using libplctag;
    using Microsoft.Extensions.Logging;
    using PLCPublisher.Plc;

    public class TagFactory : ITagFactory
    {
        private ILogger logger;

        public TagFactory(ILogger<TagFactory> logger)
        {
            this.logger = logger;
        }

        public IPlcTag Create(TagDefinition tagDefinition, Nullable<TimeSpan> timeout)
        {
            IPlcTag tag = this.Create(tagDefinition.TagType, tagDefinition.ArrayLength);

            tag.Name = tagDefinition.TagName;
            tag.Gateway = tagDefinition.Gateway;
            tag.Path = tagDefinition.Path;
            tag.PlcType = tagDefinition.PlcType;
            tag.Protocol = Protocol.ab_eip;
            tag.Timeout = timeout ?? TimeSpan.FromSeconds(1);

            return tag;
        }

        private IPlcTag Create(DataType type, int arrayLength)
        {
            switch (type)
            {
                case DataType.BOOL: return new BoolPlcTag();
                case DataType.DINT: return new DintPlcTag();
                case DataType.INT: return new IntPlcTag();
                case DataType.LINT: return new LintPlcTag();
                case DataType.LREAL: return new LrealPlcTag();
                case DataType.REAL: return new RealPlcTag();
                case DataType.SINT: return new SintPlcTag();
                case DataType.STRING: return new StringPlcTag();
                case DataType.ARRAY_BOOL: return new BoolArrayPlcTag(arrayLength);
                case DataType.ARRAY_DINT: return new DintArrayPlcTag(arrayLength);
                case DataType.ARRAY_INT: return new IntArrayPlcTag(arrayLength);
                case DataType.ARRAY_LINT: return new LintArrayPlcTag(arrayLength);
                case DataType.ARRAY_LREAL: return new LrealArrayPlcTag(arrayLength);
                case DataType.ARRAY_REAL: return new RealArrayPlcTag(arrayLength);
                case DataType.ARRAY_SINT: return new SintArrayPlcTag(arrayLength);
                case DataType.ARRAY_STRING: return new StringArrayPlcTag(arrayLength);
                default:
                    this.logger.LogError("TagFactory.Create() failed. Unknown data type {0}", type);
                    throw new ArgumentException("Unknown data type");
            };
        }
    }
}