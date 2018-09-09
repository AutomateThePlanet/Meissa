using System;

namespace LoadAssemblySpike
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var printer = new NativeTestsRunnerTestCasesPluginService();
            printer.ExtractAllTestCasesFromTestLibrary(args[0]);
        }
    }
}
