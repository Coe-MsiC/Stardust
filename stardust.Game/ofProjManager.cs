// if you fork this PLEASE CHANGE THE ENGINE NAME IN HERE IM BEGGING YOU OR ELSE THE STUFF WILL BREAK
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

// the save and load manager for .ofproj

public static class ProjectManager
{
    // THE APPS DATA FOLDER (yes thats it... its just a variable fot the Application Data)
    private static readonly /* you can remove this if you want to make a fork where you cna chanfe the app data folder*/ string ConfigFolder = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Stardust"/*change this when you fork*/); 
    
    // checks which project was the latest in use and also is used to load the projects in the load system
    private static readonly string RecentProjectsFile = Path.Combine(ConfigFolder, "recent_projects.json");

    // save system
    public static void SaveProject(ProjectData data)
    {
        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(data.FullOfProjPath, json);

    }

    // load system (it looks like this because it has to list all the projects in the recentprojects file)
    public static List<ProjectData> GetRecentProjects()
    {
        if (!File.Exists(RecentProjectsFile)) return new List<ProjectData>();

        var projects = new List<ProjectData>();
        var paths = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(RecentProjectsFile));

        foreach (var path in paths)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                projects.Add(JsonSerializer.Deserialize<ProjectData>(json));
            }
        }

        // sorting load subsystem (simple! jsut shows the most recent on top!)
        return projects.OrderByDescending(p => p.LastOpened).ToList();
    }

    // creates the apps data folder and rcentprojects fiel if it doesont exist
    // aslo manages recentprojects whit phaths for the projects
    private static void AddToRecentProjects(string ofprojPath)
    {
        if (!Directory.Exists(ConfigFolder)) Directory.CreateDirectory(ConfigFolder);

        List<string> paths = File.Exists(RecentProjectsFile) 
            ? JsonSerializer.Deserialize<List<string>>(File.ReadAllText(RecentProjectsFile)) 
            : new List<string>();

        if (!paths.Contains(ofprojPath))
        {
            paths.Add(ofprojPath);
            File.WriteAllText(RecentProjectsFile, JsonSerializer.Serialize(paths));
        }
    }
}

// If you read all the comments im so sorry for all the brain cancer i have caused whit this bad englich