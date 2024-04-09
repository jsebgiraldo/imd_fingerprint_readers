using imd_fingerprint_readers.Devices.FingerprintReaders.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace imd_fingerprint_readers
{
    /// <summary>
    /// A person.
    /// </summary>
    [Serializable]
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Fingerprint Fingerprint { get; set; }

        /// <summary>
        /// Creates a new instance of the person class.
        /// </summary>
        public Person()
        {
        }

        // Serialize this object to a JSON string
        /// <summary>
        /// Serializes the person instance.
        /// </summary>
        /// <returns>The serialized data.</returns>
        public string Serialize()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };
            return JsonSerializer.Serialize(this, options);
        }

        /// <summary>
        /// Deserializes the person instance.
        /// </summary>
        /// <param name="jsonString">The serialized data</param>
        /// <returns>The person</returns>
        public static Person Deserialize(string jsonString)
        {
            return JsonSerializer.Deserialize<Person>(jsonString);
        }
    }
}
