// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using System.Xml.Serialization;

namespace CodingBasics.Persistance;

/// <summary>
/// Helper class for simple XML serialization
/// </summary>
public static class XmlHelper
{

    /// <summary>
    /// Serialize an object to a XML string
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string Serialize(object obj)
    {
        var xmlSerializer = new XmlSerializer(obj.GetType());

        using (var textWriter = new StringWriter())
        {
            xmlSerializer.Serialize(textWriter, obj);
            return textWriter.ToString();
        }
    }

    /// <summary>
    /// Deserialize a object from a XML string
    /// </summary>
    /// <typeparam name="T">Type of the object to derialize in</typeparam>
    /// <param name="xml">XML with the serialized object</param>
    /// <returns>Instance of type T</returns>
    public static T Deserialize<T>(string xml)
    {
        var xmlSerializer = new XmlSerializer(typeof(T));

        T result;

        using (var textReader = new StringReader(xml))
        {
            result = (T)xmlSerializer.Deserialize(textReader);
        }

        return result;
    }

    /// <summary>
    /// Serialize an object into a XML file
    /// </summary>
    /// <param name="obj">Object to serialize</param>
    /// <param name="fileName">Full path to file to persist the object in</param>

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
    /// Deserialize an object from a XML file
    /// </summary>
    /// <typeparam name="T">Type of of the object the serializer should return</typeparam>
    /// <param name="fileName">Full file path to the XML file</param>
    /// <returns>Type of of the object the serializer should return</returns>
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