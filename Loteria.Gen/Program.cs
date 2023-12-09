using LoteryGenerator;
using static System.Net.WebRequestMethods;

Console.WriteLine("### GERADOR DE COMBINAÇÕES DE LOTERIA ###");

// Parameters
Console.Write("Quantas combinações (padão: 10)?  ");
_ = int.TryParse(Console.ReadLine(), out var amount);
if (amount <= 0) amount = 10;

Console.Write("De quantos números, cada combinação (padão: 15)? ");
_ = int.TryParse(Console.ReadLine(), out var of);
if (of <= 0) of = 15;

Console.Write("De um total de quantos números (padão: 25)? ");
_ = int.TryParse(Console.ReadLine(), out var from);
if (from <= 0) from = 25;

// Generate
var combinations = new RandomCombinationSetFactory(of, from)
    .Generate(amount)
    .ToArray();

// Results
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"{Environment.NewLine}Resultados");
Console.WriteLine($"{combinations.Length} combinações geradas, contendo {of} número{(of > 1 ? "s" : "")} em cada:");

var reference = new Combination { 04, 06, 08, 09, 10, 12, 13, 14, 15, 16, 18, 19, 20, 21, 24 };

var count = 0;
foreach (var combination in combinations)
{
    Console.ForegroundColor = count % 2 == 0 ? ConsoleColor.Green : ConsoleColor.Yellow;
    Console.Write(combination);

    var result = new ResultChecker(combination, reference);
    if (result.PercentageOfSucess <= 70)
        Console.WriteLine();
    else
    {
        var oldCollor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" -> {result.Hits} acertos");
        Console.ForegroundColor = oldCollor;
    }
    count++;
}
Console.ForegroundColor = ConsoleColor.Gray;