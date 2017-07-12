using System.Collections.Generic;

namespace Hqv.CSharp.Common.Ordering
{
    /// <summary>
    /// Describes how to map source properties to destination properties
    /// 
    /// For example, a string Name can be mapped to a property FirstName descending and a property LastName
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    public class PropertyMapping<TSource, TDestination> : IPropertyMapping
    {
        public Dictionary<string, PropertyMappingValue> MappingDictionary { get; private set; }

        public PropertyMapping(Dictionary<string, PropertyMappingValue> mappingDictionary)
        {
            MappingDictionary = mappingDictionary;
        }
    }
}