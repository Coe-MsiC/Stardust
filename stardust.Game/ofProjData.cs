using System;
using System.Text.Json.Serialization;

// this is all the stuff to manage the .ofproj files
public class ProjectData
{
    public string Name { get; set; }

    public string ProjectPath { get; set; }
    
    public DateTime LastOpened { get; set; }
    
    public string OsuFrameworkVersion { get; set; }

    // Icons are stored in the Apps Data Folder but maybe ill add somewhen :)
    //public string IconPath { get; set; }

    [JsonIgnore]
    public string FullOfProjPath => System.IO.Path.Combine(ProjectPath, $"{Name}.ofproj");
}