using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Linq;
using System.IO;

namespace Test {
    class Test {
        public static void Main(string[] args) {
            string cmd = args[0];
            Console.WriteLine("Executing: " + cmd);

            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            PowerShell ps = PowerShell.Create();
            ps.AddScript(cmd);
            var results = ps.Invoke();
            foreach (var result in results) {
                // If the result is a PSObject, we can dig deeper into it
                if (result.Properties != null && result.Properties.Any()) {
                    Console.WriteLine("Properties of " + result);
                    foreach (var property in result.Properties) {
                        Console.WriteLine(property.Name + ": " + property.Value);
                    }
                    Console.WriteLine();
                } else {
                    // Otherwise, just write the ToString() value
                    Console.WriteLine(result);
                };
            }
            runspace.Close();
        }
    }

}
