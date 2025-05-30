// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

namespace CodingBasics.Patterns;


/// <summary>
/// Simple and thread-safe implementation of the singleton pattern
/// </summary>
public class GlobalValues
{
    
    private static readonly Lazy<GlobalValues> _instance = new(()=> new GlobalValues());

    public static GlobalValues Instance => _instance.Value;

    //// Same as:
    /*
    public static GlobalValues Instance 
    {
        get
        {
            return _instance.Value;
        }
    }
    */

    /// <summary>
    /// A private ctor prohibits direct instancing of the class
    /// </summary>
    private GlobalValues()
    {
        
    }

    /// <summary>
    /// Application name
    /// </summary>
    public const string AppName = "Coding basics application";

    /// <summary>
    /// Path for app data backups
    /// </summary>
    public string BackupPath { get; set; }

    
    // Add properties and methods as required

}

