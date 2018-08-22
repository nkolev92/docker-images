using System.Runtime.InteropServices;
using System.Globalization;
using static System.Console;

public static class Program
{
    public static void Main(string[] args)
    {
        WriteLine("**Environment**");
        WriteLine($"Platform: .NET Core");
        WriteLine($"OS: {RuntimeInformation.OSDescription}");
        WriteLine($"CurrentCulture: `{CultureInfo.CurrentCulture}`");
        WriteLine($"CurrentCulture.Name: `{CultureInfo.CurrentCulture.Name}`");
        WriteLine($"CurrentCulture.DisplayName: `{CultureInfo.CurrentCulture.DisplayName}`");
        WriteLine($"CurrentCulture.IsNeutralCulture: `{CultureInfo.CurrentCulture.IsNeutralCulture}`");
        WriteLine($"CurrentCulture.NativeName: `{CultureInfo.CurrentCulture.NativeName}`");
        WriteLine($"CurrentCulture.ThreeLetterISOLanguageName: `{CultureInfo.CurrentCulture.ThreeLetterISOLanguageName}`");
        WriteLine($"Is the culture invariant?: `{CultureInfo.CurrentCulture.Equals(CultureInfo.InvariantCulture)}");
        WriteLine();
    }
}
