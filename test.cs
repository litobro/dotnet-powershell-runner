using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
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
                Console.WriteLine(result);
            }
            runspace.Close();
        }
    }

}
