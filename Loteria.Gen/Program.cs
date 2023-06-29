using LoteryGenerator;

Console.WriteLine("### GERADOR DE JOGOS DE LOTERIA ###");

Console.Write("Quantos jogos? ");
_ = int.TryParse(Console.ReadLine(), out int amount);

Console.Write("De quantos números, cada? ");
_ = int.TryParse(Console.ReadLine(), out int of);

Console.Write("De um total de quantos números? ");
_ = int.TryParse(Console.ReadLine(), out int from);

var combinations = new RandomCombinationSet(of, from).Generate(amount);

// Resultados
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("\nResultados");
Console.WriteLine(string.Format("{0} combinações geradas, contendo {1} número{2} em cada:", combinations.Count(), of, of > 1 ? "s" : ""));
var count = 0;
foreach (var combination in combinations)
{
    Console.ForegroundColor = count % 2 == 0 ? ConsoleColor.Green : ConsoleColor.Yellow;
    var format = combination.Select(n => n.ToString().PadLeft(2, '0'));
    Console.WriteLine(string.Join(", ", format));
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

