using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class TravellingPoliceman
{
    static void Main(string[] args)
    {
        var fuel = int.Parse(Console.ReadLine());

        var streets = new List<Street>();

        while (true)
        {
            var input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }

            string[] tokens = input.Split(',').Select(s => s.Trim()).ToArray();
            Street newStreet = new Street(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]), int.Parse(tokens[3]));
            streets.Add(newStreet);
        }

        var result = Fill(streets.ToArray(), fuel);

        StringBuilder output = new StringBuilder();

        output.AppendLine(String.Join(" -> ", result.Select(i => i.Name)))
            .AppendLine($"Total pokemons caught -> {result.Sum(i => i.PokemonCount)}")
            .AppendLine($"Total car damage -> {result.Sum(i => i.CarDamage)}")
            .Append($"Fuel Left -> {fuel - result.Sum(i => i.StreetLength)}");

        Console.WriteLine(output.ToString());
    }

    static List<Street> Fill(Street[] streets, int fuel)
    {
        var maxValues = new int[streets.Length + 1, fuel + 1];
        var itemIncluded = new bool[streets.Length + 1, fuel + 1];

        for (int i = 0; i < streets.Length; i++)
        {
            for (int currCapacity = 1; currCapacity <= fuel; currCapacity++)
            {
                int valueIncluded = 0;
                int fuelCost = streets[i].StreetLength;
                if (fuelCost <= currCapacity)
                {
                    valueIncluded = streets[i].Value + maxValues[i, currCapacity - streets[i].StreetLength];
                }

                if (valueIncluded > maxValues[i, currCapacity])
                {
                    maxValues[i + 1, currCapacity] = valueIncluded;
                    itemIncluded[i + 1, currCapacity] = true;
                }
                else
                {
                    maxValues[i + 1, currCapacity] = maxValues[i, currCapacity];
                }
            }
        }

        List<Street> takenItems = new List<Street>();
        for (int i = streets.Length; i > 0; i--)
        {
            if (!itemIncluded[i, fuel])
            {
                continue;
            }

            Street street = streets[i - 1];
            takenItems.Add(street);

            fuel -= street.StreetLength;
        }

        takenItems.Reverse();
        return takenItems;
    }
}

class Street
{
    public Street(string name, int carDamage, int pokemonCount, int streetLength)
    {
        this.Name = name;
        this.CarDamage = carDamage;
        this.PokemonCount = pokemonCount;
        this.StreetLength = streetLength;
        this.Value = (this.PokemonCount * 10) - this.CarDamage;
    }

    public string Name { get; set; }

    public int CarDamage { get; set; }

    public int PokemonCount { get; set; }

    public int StreetLength { get; set; }

    public int Value { get; set; }

    public override string ToString()
    {
        return this.Name;
    }
}