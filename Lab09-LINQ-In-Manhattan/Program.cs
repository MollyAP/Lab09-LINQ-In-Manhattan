using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class FeatureCollection
{
    public string Type { get; set; }
    public List<Feature> Features { get; set; }
}

class Program
{
    static void Main()
    {
        // Read the JSON data from the file
        string jsonFilePath = "data.json";
        string jsonData = File.ReadAllText(jsonFilePath);

        // Deserialize the JSON data into the FeatureCollection
        FeatureCollection featureCollection = JsonConvert.DeserializeObject<FeatureCollection>(jsonData);

        // Now you can access the Features property to get the list of Feature objects
        List<Feature> features = featureCollection.Features;

        bool finished = false;

        while (!finished)
        {
            // Question 1: Output all of the neighborhoods in this data list (Final Total: 147 neighborhoods)
            var allNeighborhoods = features.Select(feature => feature.Properties.Neighborhood);
            Console.WriteLine($"All Neighborhoods ({allNeighborhoods.Count()}):");
            foreach (var neighborhood in allNeighborhoods)
            {
                Console.WriteLine(neighborhood);
            }

            Console.WriteLine("Press 2 to move to Question 2 or any other key to exit:");

            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (input == '2')
            {
                // Question 2: Filter out all the neighborhoods that do not have any names (Final Total: 143)
                var nonEmptyNeighborhoods = features
                    .Where(feature => !string.IsNullOrEmpty(feature.Properties.Neighborhood))
                    .Select(feature => feature.Properties.Neighborhood);
                Console.WriteLine($"Non-empty Neighborhoods ({nonEmptyNeighborhoods.Count()}):");
                foreach (var neighborhood in nonEmptyNeighborhoods)
                {
                    Console.WriteLine(neighborhood);
                }

                Console.WriteLine("Press 3 to move to Question 3 or any other key to exit:");

                input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (input == '3')
                {
                    // Question 3: Remove the duplicates (Final Total: 4 neighborhoods)
                    var distinctNeighborhoods = features
                        .Where(feature => !string.IsNullOrEmpty(feature.Properties.Neighborhood))
                        .Select(feature => feature.Properties.Neighborhood)
                        .Distinct();
                    Console.WriteLine($"Distinct Neighborhoods ({distinctNeighborhoods.Count()}):");
                    foreach (var neighborhood in distinctNeighborhoods)
                    {
                        Console.WriteLine(neighborhood);
                    }

                    Console.WriteLine("Press 4 to move to Question 4 or any other key to exit:");

                    input = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    if (input == '4')
                    {
                        // Question 4: Rewrite the queries from above and consolidate all into one single query.
                        var result = features
                            .Where(feature => !string.IsNullOrEmpty(feature.Properties.Neighborhood))
                            .Select(feature => feature.Properties.Neighborhood)
                            .Distinct();
                        Console.WriteLine($"Consolidated Query Result ({result.Count()}):");
                        foreach (var neighborhood in result)
                        {
                            Console.WriteLine(neighborhood);
                        }

                        Console.WriteLine("Press 5 to move to Question 5 or any other key to exit:");

                        input = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                        if (input == '5')
                        {
                            // Question 5: Rewrite at least one of these questions only using the opposing method.
                            // Using LINQ Query statements instead of LINQ method calls
                            var queryResult = (from feature in features
                                               where !string.IsNullOrEmpty(feature.Properties.Neighborhood)
                                               select feature.Properties.Neighborhood).Distinct();
                            Console.WriteLine($"Using LINQ Query ({queryResult.Count()}):");
                            foreach (var neighborhood in queryResult)
                            {
                                Console.WriteLine(neighborhood);
                            }

                            finished = true; // Exits the loop and terminates the program after Question 5
                        }
                        else
                        {
                            finished = true;
                        }
                    }
                    else
                    {
                        finished = true;
                    }
                }
                else
                {
                    finished = true;
                }
            }
            else
            {
                finished = true;
            }
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}