using System;
namespace SourceGenSampleAPI.Attributes
{

    [AttributeUsage(AttributeTargets.Class)]
    public class MapModelAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MapModelIgnoreAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MapModelPropertyNameAttribute : Attribute
    {
        public MapModelPropertyNameAttribute(string proprtyName) {
            PropertyName = proprtyName;
        }

        public string PropertyName { get; set; }
    }
}
