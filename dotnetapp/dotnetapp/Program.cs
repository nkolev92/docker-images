using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using static System.Console;

public static class Program
{
    public static void Main(string[] args)
    {

        var text = "Random text.";
        Directory.CreateDirectory("/var/logs");
        File.WriteAllText(@"/var/logs/WriteText.txt", text);

        WriteLine("**Environment**");
        WriteLine($"Platform: .NET Core");
        WriteLine($"OS: {RuntimeInformation.OSDescription}");
        WriteLine();
    }
}
