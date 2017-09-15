using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GuessTheAnimal.Repository
{
    public class AnimalTextFileRepository : IAnimalRepository
    {
        public string TextFilePath
        {
            get
            {
                var entryAssembly = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                return !string.IsNullOrWhiteSpace(entryAssembly) ? Path.Combine(entryAssembly, Properties.Settings.Default.AnimalsTextFileName) : null;
            } 
        }

        public List<Animal> GetAnimals()
        {
            try
            {
                var animalsJson = File.ReadAllText(TextFilePath);
                var animals = JsonConvert.DeserializeObject<List<Animal>>(animalsJson);
                return animals;
            }
            catch (Exception e)
            {
                // TODO: Log the error
                return new List<Animal>();
            }
        }

        public bool SaveAnimals(List<Animal> animals)
        {
            try
            {
                var animalsJson = JsonConvert.SerializeObject(animals);
                File.WriteAllText(TextFilePath, animalsJson);
                return true;
            }
            catch (Exception e)
            {
                // TODO: Log the error
                return false;
            }
        }
    }
}
