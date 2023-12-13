using LoteryGenerator;

Console.WriteLine("### GERADOR DE JOGOS DE LOTERIA ###");

// Parameters
Console.Write("Quantos jogos deseja gerar (padão: 10)?  ");
if (!int.TryParse(Console.ReadLine(), out var amount)) amount = 10;

Console.Write("De quantos números, em cada jogo (padão: 15)? ");
if (!int.TryParse(Console.ReadLine(), out var of)) of = 15;

Console.Write("Quantos números são possíveis de ser escolhidos (padão: 25)? ");
if (!int.TryParse(Console.ReadLine(), out var from)) from = 25;

// Generate
var combinations = new RandomCombinationSetFactory(of, from)
    .Generate(amount).ToArray();

// Results
Console.WriteLine($"{Environment.NewLine}Resultados");
Console.WriteLine($"{combinations.Length} combinaç{(amount > 1 ? "ões" : "ão")} gerada{(amount > 1 ? "s" : "")}, contendo {of} número{(of > 1 ? "s" : "")}{(amount > 1 ? " em cada uma:" : ":")}");

var checker = new ResultChecker([09, 20, 18, 07, 13, 22, 05, 11, 06, 03, 24, 14, 10, 08, 25]);
for (int i = 0; i < combinations.Length; i++)
{
    Console.ForegroundColor = i % 2 == 0
        ? ConsoleColor.Green
        : ConsoleColor.Yellow;
    Console.Write(combinations[i]);

    // Hits
    if (checker.PercentageOfSucess(combinations[i]) > 66)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($" -> {checker.Hits(combinations[i])} acertos");
    }

    Console.WriteLine();
}
Console.ForegroundColor = ConsoleColor.Gray;