using System;
using GuessTheAnimal.Repository;

namespace GuessTheAnimal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please pick an animal in your head from the list below:");
            Console.WriteLine();

            var repository = new AnimalTextFileRepository();
            var animals = repository.GetAnimals();

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.Name);
            }

            Console.WriteLine();
            Console.WriteLine("I will guess the animal in your head. Press enter to continue.");
            Console.ReadLine();
            Console.Clear();

            var found = false;
            string answer;
            foreach (var animal in animals)
            {
                if (!found)
                {
                    Console.WriteLine(animal.Description);
                    Console.WriteLine("Does the animal match the description above (Y/N)?");

                    answer = Console.ReadLine();
                    if (answer?.Trim().ToUpper() == "Y")
                    {
                        Console.WriteLine();
                        Console.WriteLine($"The animal you picked is a {animal.Name}");
                        found = true;
                    }

                    else
                    {
                        Console.Clear();
                    }
                }
            }

            if (!found) Console.WriteLine("Animal could not be identified. Please try again.");
            Console.WriteLine();

            Console.WriteLine("Do you want to add a new animal to the list? (Y/N)");
            answer = Console.ReadLine();

            if (answer?.Trim().ToUpper() == "Y")
            {
                Console.Clear();

                var newAnimal = new Animal();
                Console.WriteLine("What is the name of the animal?");
                newAnimal.Name = Console.ReadLine();

                Console.WriteLine("What is the description of the animal?");
                newAnimal.Description = Console.ReadLine();

                animals.Add(newAnimal);

                var success = repository.SaveAnimals(animals);
                Console.WriteLine(success
                    ? "New animal has been saved. It will be available next time the application runs."
                    : "Save failed. Please try again.");
            }

            Console.WriteLine();
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
