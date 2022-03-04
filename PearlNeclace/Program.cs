// See https://aka.ms/new-console-template for more information
using PearlNecklace;

//Create a couple of Random pearls
Console.WriteLine("Create a couple of Random pearls");
Console.WriteLine(Pearl.Factory.CreateRandomPearl());
Console.WriteLine(Pearl.Factory.CreateRandomPearl());

//Create a random Necklaces
Console.WriteLine("\nCreate a random Necklaces");
var necklace = Necklace.Factory.CreateRandomNecklace(35);
Console.WriteLine(necklace);
Console.WriteLine($"Nr of pearls: {necklace.Count()}");
Console.WriteLine($"Nr of Freshwater pearls: {necklace.Count(PearlType.FreshWater)}");
Console.WriteLine($"Nr of Saltwater pearls: {necklace.Count(PearlType.SaltWater)}");
Console.WriteLine($"Price of the necklace: {necklace.Price}");

//Sort the Necklace
Console.WriteLine("\nSort the Necklace");
necklace.Sort();
Console.WriteLine(necklace);

//Find a pearl, test by using a kown pearl
Console.WriteLine("\nFind a pearl, test by using a kown pearl");
var findPearl = necklace[23];

Console.WriteLine($"Looking for Pearl:\n{findPearl}");
int idx = necklace.IndexOf(findPearl);

if (idx == -1)
{
    Console.WriteLine("Could not find the pearl");
}
else
{
    Console.WriteLine($"Pearl found in position {idx}");
}

	

using (FileStream fs = File.Create(fname("Necklace.txt")))
using (TextWriter writer = new StreamWriter(fs))
{
    var nl = string.Join("", writer.NewLine.Select(c => $"0x{(int)c:X2} "));
    Console.WriteLine($"Newline is {nl} ");

	writer.WriteLine(necklace);
	necklace.Sort();
    writer.WriteLine(necklace);

}

using (FileStream fs = File.OpenRead(fname("Necklace.txt")))
using (TextReader reader = new StreamReader(fs))
{
	Console.WriteLine(reader.ReadLine());       // Line1
	
}


static string fname(string name)
{
	var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
	documentPath = Path.Combine(documentPath, "Necklace");
	if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
	return Path.Combine(documentPath, name);
}
Console.WriteLine(fname("Necklace"));

