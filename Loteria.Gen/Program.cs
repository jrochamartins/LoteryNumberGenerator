using LoteryGenerator;

Console.WriteLine("### GERADOR DE JOGOS DE LOTERIA ###");

// Parameters
Console.Write("Quantos jogos deseja gerar (padão: 100)?  ");
if (!int.TryParse(Console.ReadLine(), out var amount))
    amount = 100;

Console.Write("De quantos números, em cada jogo (padão: 7)? ");
if (!int.TryParse(Console.ReadLine(), out var of))
    of = 7;

Console.Write("Quantos números são possíveis de ser escolhidos (padão: 31)? ");
if (!int.TryParse(Console.ReadLine(), out var from))
    from = 31;

// Generate
var combinations = new RandomCombinationSetFactory(of, from)
    .Generate(amount).ToArray();

// Results
Console.WriteLine($"{Environment.NewLine}Resultados");
Console.WriteLine($"{combinations.Length} combinaç{(amount > 1 ? "ões" : "ão")} gerada{(amount > 1 ? "s" : "")}, contendo {of} número{(of > 1 ? "s" : "")}{(amount > 1 ? " em cada uma:" : ":")}");

var checker = new ResultChecker([01, 03, 07, 14, 16, 23, 30], 4);
for (int i = 0; i < combinations.Length; i++)
{
    WriteAlternate(combinations[i].ToString(), ConsoleColor.Green, ConsoleColor.Yellow);

    WriteIf(checker.IsWinner(combinations[i]),
        $" -> {checker.Hits(combinations[i])} acertos");

    Console.WriteLine();
}
Console.ForegroundColor = ConsoleColor.Gray;

static void WriteAlternate(string text, ConsoleColor color1, ConsoleColor color2)
{
    Console.ForegroundColor = Console.ForegroundColor != color1 ? color1 : color2;
    Console.Write(text);
}

static void WriteIf(bool condition, string text, ConsoleColor color = ConsoleColor.Red)
{
    if (!condition)
        return;

    var old = Console.ForegroundColor;
    Console.ForegroundColor = color;
    Console.Write(text);
    Console.ForegroundColor = old;
}