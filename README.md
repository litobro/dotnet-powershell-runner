# dotnet-powershell-runner
A super simple C# application that can run a single PowerShell command in a new runspace and prints the output.

## Compilation
Using mono this can be compiled easily from the cli. 

```
mcs -pkg:dotnet -reference:System.Management.Automation.dll dotnet-powershell-runner.cs
```

## CLM Bypass
Using a new runspace, it is arbitrarily easy to [by creating a new Runspace](https://www.secjuice.com/powershell-constrainted-language-mode-bypass-using-runspaces/). We create one, add the command and invoke the script. 

## AMSI Bypass
Not currently implemented, but it should be very easy to implement the Rastamouse [bypass](https://github.com/rasta-mouse/AmsiScanBufferBypass).

## C2/Reflective Use
This can be called reflectively and easily from the [Sliver C2 framework](https://github.com/BishopFox/sliver/wiki/Using-3rd-party-tools) with the built-in `execute-assembly` command. Once your implant is installed, this provides an easy way to run powershell without needing to drop into the shell or use other tools when simply trying to do a command. 
