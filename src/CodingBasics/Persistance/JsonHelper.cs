// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.


using Newtonsoft.Json;

namespace CodingBasics.Persistance;

/// <summary>
/// Class to serialize account statements into JSON files
/// </summary>
public static class JsonHelper
{
    /// <summary>
    /// Serialize an object to a string
    /// </summary>
    /// <param name="obj">Object to serialize</param>
    /// <returns>String with JSON</returns>

    public static string Serialize(object obj)
    {
        var result = JsonConvert.SerializeObject(obj, Formatting.Indented);
        return result;
    }

    /// <summary>
    /// Deserialize a object from a JSON string
    /// </summary>
    /// <typeparam name="T">Type of the object to derialize in</typeparam>
    /// <param name="json">JSON with the serialized object</param>
    /// <returns>Instance of type T</returns>
    public static T Deserialize<T>(string json)
    {
        var result = JsonConvert.DeserializeObject<T>(json);
        return result;
    }


    /// <summary>
    /// Serialize an object into a JSON file
    /// </summary>
    /// <param name="obj">Object to serialize</param>
    /// <param name="fileName">Full path to file to persist the object</param>

    public static void SerializeToFile(object obj, string fileName)
    {
        // No file name
        if (string.IsNullOrEmpty(fileName))
        {
            throw new FileNotFoundException("No valid file name was provided!");
        }

        // If the file already exists delete it
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        // Create the file content now
        var result = Serialize(obj);

        // Save content to file
        File.WriteAllText(fileName, result);

    }


    /// <summary>
    /// Deserialize an object from a JSON file
    /// </summary>
    /// <typeparam name="T">Type of the object the serializer should return</typeparam>
    /// <param name="fileName">Full file path to the JSON file</param>
    /// <returns>Type of the object the serializer should return</returns>
    /// <exception cref="FileNotFoundException">File is not existing</exception>
    public static T DeserializeFromFile<T>(string fileName)
    {

        // Check if the file exists
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"File {fileName} NOT found!");
        }

        // Read file
        var content = File.ReadAllText(fileName);

        // Deserialize content
        var resultObject = Deserialize<T>(content);

        return resultObject;
    }

}