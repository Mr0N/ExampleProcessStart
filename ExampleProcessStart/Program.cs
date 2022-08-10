using System.IO;
using System;
using System.Diagnostics;

var info = new ProcessStartInfo()
{
    FileName = "cmd.exe",
    RedirectStandardError = true,
    RedirectStandardOutput = true,
    RedirectStandardInput = true
};
var process = Process.Start(info);
process.CheckException();

string text = process.StandardOutput.ReadToEnd();
Console.WriteLine(text);
Console.ReadKey();


static class Info
{ 
    public static void CheckException(this Process process)
    {
        string exception = process.StandardError.ReadToEnd();
        if (string.IsNullOrEmpty(exception))
            throw new Exception(exception);
    }
}