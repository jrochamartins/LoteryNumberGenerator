using LoteryGenerator;

Console.WriteLine("### GERADOR DE COMBINAÇÕES DE LOTERIA ###");

// Parameters
Console.Write("Quantas combinações (padão: 10)?  ");
_ = int.TryParse(Console.ReadLine(), out var amount);
if (amount <= 0) amount = 10;
Console.Write("De quantos números, em cada combinação (padão: 15)? ");
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
Console.WriteLine($"{Environment.NewLine}Resultados");
Console.WriteLine($"{combinations.Length} combinaç{(amount > 1 ? "ões" : "ão")} gerada{(amount > 1 ? "s" : "")}, contendo {of} número{(of > 1 ? "s" : "")}{(amount > 1 ? " em cada uma:" : ":")}");

Combination reference = [04, 06, 08, 09, 10, 12, 13, 14, 15, 16, 18, 19, 20, 21, 24];
for (int i = 0; i < combinations.Length; i++)
{
    Console.ForegroundColor = i % 2 == 0 ? ConsoleColor.Green : ConsoleColor.Yellow;
    Console.Write(combinations[i]);
    var result = new ResultChecker(combinations[i], reference);    
    if (result.PercentageOfSucess <= 70)
    {
        Console.WriteLine();
        continue;
    }
    var oldCollor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($" -> {result.Hits} acertos");
    Console.ForegroundColor = oldCollor;
}
Console.ForegroundColor = ConsoleColor.Gray;