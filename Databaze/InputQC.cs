using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Databaze
{
    public class InputQC
    {
        public static string SafeReadLine()
    {
        try
        {
            return Console.ReadLine() ?? string.Empty;
        }
        catch (IOException ioEx)
        {
            Console.WriteLine($"Input/output error: {ioEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        return string.Empty;
    }
    }
}