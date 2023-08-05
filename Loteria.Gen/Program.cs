using LoteryGenerator;

Console.WriteLine("### GERADOR DE COMBINAÇÕES DE LOTERIA ###");
Console.Write("Quantas combinações (padão: 10)?  ");
_ = int.TryParse(Console.ReadLine(), out var amount);
Console.Write("De quantos números, cada combinação (padão: 15)? ");
_ = int.TryParse(Console.ReadLine(), out var of);
Console.Write("De um total de quantos números (padão: 25)? ");
_ = int.TryParse(Console.ReadLine(), out var from);

if (amount <= 0) amount = 10;
if (from <= 0) from = 25;
if (of <= 0) of = 15;

var concurso2850 = new Result(new Combination { 01, 02, 03, 04, 07, 08, 09, 10, 16, 17, 19, 21, 22, 23, 24 });

var combinations = new RandomCombinationSetFactory(of, from).Generate(amount).ToArray();

// Resultados
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"{Environment.NewLine}Resultados");
Console.WriteLine($"{combinations.Length} combinações geradas, contendo {of} número{(of > 1 ? "s" : "")} em cada:");

var count = 0;
foreach (var combination in combinations)
{
    Console.ForegroundColor = count % 2 == 0 ? ConsoleColor.Green : ConsoleColor.Yellow;
    Console.Write(combination);
    var hits = concurso2850.Hits(combination);
    if (hits > 10)
    {
        var oldCollor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" -> {hits} acertos");
        Console.ForegroundColor = oldCollor;
    }
    else
        Console.WriteLine();
    count++;
}
Console.ForegroundColor = ConsoleColor.Gray;

//// ## Estatísticas
//Console.ForegroundColor = ConsoleColor.White;
//Console.WriteLine("\nEstatísticas");
//Console.Write("Quantidade de números utilizada:");
//int count = 0;
//foreach (var counts in sta.Counts)
//{
//    if (count % 10 == 0)
//    {
//        Console.WriteLine();
//        Console.ForegroundColor = Console.ForegroundColor != ConsoleColor.DarkGreen ? ConsoleColor.DarkGreen : ConsoleColor.DarkYellow;
//    }
//    Console.Write($"[{counts.Key.ToString().PadLeft(2, '0')}: {counts.Value}] ");    
//    count++;
//}
//Console.ForegroundColor = ConsoleColor.Gray;
//Console.WriteLine();

