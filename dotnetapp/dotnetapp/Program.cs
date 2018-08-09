using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using static System.Console;

public static class Program
{
    public static void Main(string[] args) 
    {
          WriteLine("**Environment**");
          WriteLine($"Platform: .NET Core");
          WriteLine($"OS: {RuntimeInformation.OSDescription}");
          WriteLine();
    }
}
