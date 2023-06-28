using Loteria.Gen;

Console.WriteLine("### BEM VINDO AO GERADOR DE JOGOS DE LOTERIA ###");

Console.Write("Quantos jogos? ");
_ = int.TryParse(Console.ReadLine(), out int combinations);

Console.Write("De quantos números, cada? ");
_ = int.TryParse(Console.ReadLine(), out int of);

Console.Write("De um total de quantos números? ");
_ = int.TryParse(Console.ReadLine(), out int from);

var gen = new Generator(from);
gen.Generate(combinations, of);

var sta = new Statistics(gen);
sta.Generate();

// Resultados
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("\nResultados");
Console.WriteLine($"{gen.Combinations.Count} jogos gerados contendo {of} numeros em cada:");

for (int i = 0; i < gen.Combinations.Count; i++)
{
   Console.ForegroundColor = i % 2 == 0 ? ConsoleColor.Green : ConsoleColor.Yellow;
   var gameFormated = gen.Combinations[i].Select(_ => _.ToString().PadLeft(2, '0'));
   Console.WriteLine(string.Join(", ", gameFormated));
}
Console.ForegroundColor = ConsoleColor.Gray;

// ## Estatísticas
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("\nEstatísticas");
Console.Write("Quantidade de números utilizada:");
int count = 0;
foreach (var counts in sta.Counts)
{
    if (count % 10 == 0)
    {
        Console.WriteLine();
        Console.ForegroundColor = Console.ForegroundColor != ConsoleColor.DarkGreen ? ConsoleColor.DarkGreen : ConsoleColor.DarkYellow;
    }
    Console.Write($"[{counts.Key.ToString().PadLeft(2, '0')}: {counts.Value}] ");    
    count++;
}
Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine();

