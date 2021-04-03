using System.Collections.Generic;
using System.Diagnostics;

namespace DevTool.Services.CommandLine {
    public class CommandLineController {
        public static void RunCommandLine(object obj) {
            List<string> cmd = new List<string>();
            cmd = (List<string>) obj;
            Process process = new Process();
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            foreach (var item in cmd) {
                process.StandardInput.WriteLine(item);
            }
            process.StandardInput.Flush();
            process.StandardInput.Close();
        }

        public static List<string> ReadCommandLine(object obj) {
            List<string> cmd = new List<string>();
            cmd = (List<string>) obj;
            Process process = new Process();
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            foreach (var item in cmd) {
                process.StandardInput.WriteLine(item);
            }
            process.StandardInput.Flush();
            process.StandardInput.Close();
            List<string> result = new List<string>();
            string line = "";
            while ((line = process.StandardOutput.ReadLine()) != null) {
                result.Add(line);
            }
            return result;
        }
    }
}
