using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace stardust.Game
{
    public class ProjectGenerator
    {
        // this is just to generate projects. you can leave this alone
        public async Task CreateProjectAsync(string projectName, string targetDirectory)
        {
            
            if (!Directory.Exists(targetDirectory))
                Directory.CreateDirectory(targetDirectory);

            
            // -n: Name
            // -o: Output-Path
            string arguments = $"new osu-framework-game -n \"{projectName}\" -o \"{targetDirectory}\"";

            var startInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = targetDirectory
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                process.Start();

                
                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();

                await process.WaitForExitAsync();

                if (process.ExitCode != 0)
                {
                    throw new Exception($"Fehler beim Ausführen von 'dotnet new': {error}");
                }
            }

            
            CreateOfProjFile(projectName, targetDirectory);
        }

        private void CreateOfProjFile(string name, string path)
        {
            
            var data = new ProjectData
            {
                Name = name,
                ProjectPath = path,
                LastOpened = DateTime.Now,
                OsuFrameworkVersion = "latest"
            };

            
            
            string json = System.Text.Json.JsonSerializer.Serialize(data, new System.Text.Json.JsonSerializerOptions 
            { 
                WriteIndented = true 
            });

            string filePath = Path.Combine(path, $"{name}.ofproj");
            File.WriteAllText(filePath, json);
        }
    }
}