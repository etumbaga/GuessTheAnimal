using System.Collections.Generic;

namespace GuessTheAnimal.Repository
{
    public interface IAnimalRepository
    {
        List<Animal> GetAnimals();
        bool SaveAnimals(List<Animal> animals);
    }
}
