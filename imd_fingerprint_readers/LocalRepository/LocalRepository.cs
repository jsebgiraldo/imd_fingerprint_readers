using imd_fingerprint_readers.Devices.FingerprintReaders.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace imd_fingerprint_readers
{
    /// <summary>
    /// Local repository. This repository stores the Person records on disk in the given folder.
    /// </summary>
    public class LocalRepository
    {
        private readonly string storagePath;
        private Dictionary<string, Person> persons = new Dictionary<string, Person>();
        private Matcher matcher;

        /// <summary>
        /// Creates a new instance of the LocalRepository class.
        /// </summary>
        /// <param name="storagePath"> The path of the database.</param>
        /// <param name="matcher">The matcher instance.</param>
        public LocalRepository(string storagePath, Matcher matcher)
        {
            this.storagePath = storagePath;
            this.matcher = matcher;
        }

        /// <summary>
        /// Initializes the local repository.
        /// </summary>
        public void Initialize()
        {
            LoadRecords();
        }

        /// <summary>
        /// Loads all the records of the local repository.
        /// </summary>
        private void LoadRecords()
        {
            if (!Directory.Exists(storagePath))
            {
                Directory.CreateDirectory(storagePath);
            }
            else
            {
                foreach (var file in Directory.GetFiles(storagePath, "*.json"))
                {
                    var person = DeserializePerson(file);
                    if (person != null)
                    {
                        persons[Path.GetFileNameWithoutExtension(file)] = person;
                    }
                }
            }
        }

        /// <summary>
        /// Adds a new record to the local repository.
        /// </summary>
        /// <param name="person">The person record to be added.</param>
        public bool AddRecord(Person person)
        {
            if (persons.ContainsKey(person.Id))
            {
                return false;
            }

            persons[person.Id] = person;
            SerializePerson(Path.Combine(storagePath, $"{person.Id}.json"), person);

            return true;
        }

        /// <summary>
        /// Removes a record from the database.
        /// </summary>
        /// <param name="id">The id of the record to remove.</param>
        /// <returns>true if the record was removed; otherwise; false.</returns>
        public bool RemoveRecord(string id)
        {
            if (!persons.ContainsKey(id))
            {
                return false;
            }

            persons.Remove(id);
            File.Delete(Path.Combine(storagePath, $"{id}.json"));
            return true;
        }

        /// <summary>
        /// Get all the persons in the repository.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetAllPersons()
        {
            return persons.Values;
        }

        /// <summary>
        /// Finds a person in the repository given its fingerprint.
        /// </summary>
        /// <param name="fingerprint">The fingerprint to find.</param>
        /// <param name="matchScore">The score to be considered a match.</param>
        /// <returns>The person if found; null otherwise.</returns>
        public Person FindByFingerprint(Fingerprint fingerprint, int matchScore)
        {
            foreach (Person person in GetAllPersons())
            {
                if (this.matcher.Match(fingerprint, person.Fingerprint) >= matchScore)
                    return person;
            }

            return null;
        }

        /// <summary>
        /// Finds a person by its ID.
        /// </summary>
        /// <param name="id">The ID of the person to find.</param>
        /// <returns>The person if found; null otherwise.</returns>
        public Person FindById(string id)
        {
            foreach (Person person in GetAllPersons())
            {
                if (person.Id == id)
                    return person;
            }

            return null;
        }

        /// <summary>
        /// Finds a person by its Name.
        /// </summary>
        /// <param name="name">The Name of the person to find.</param>
        /// <returns>The person if found; null otherwise.</returns>
        public Person FindByName(string name)
        {
            foreach (Person person in GetAllPersons())
            {
                if (person.Name == name)
                    return person;
            }

            return null;
        }

        /// <summary>
        /// Serializes the Person instance to JSON.
        /// </summary>
        /// <param name="filePath">The path where to store the record.</param>
        /// <param name="person">The person instance.</param>
        private void SerializePerson(string filePath, Person person)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(person, options);
            File.WriteAllText(filePath, jsonString);
        }

        /// <summary>
        /// Deserializes a person instance located in a given path.
        /// </summary>
        /// <param name="filePath">The path of the serialized data.</param>
        /// <returns></returns>
        private Person DeserializePerson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Person>(jsonString);
        }
    }
}
