using PersonReader.Interface;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace PeopleViewer;

public static class ReaderFactory
{
    private static IPersonReader? reader;

    public static IPersonReader GetReader()
    {
        if (reader != null)
            return reader;

        //string? readerAssemblyName = ConfigurationManager.AppSettings["ReaderAssembly"];
        //string readerLocation = AppDomain.CurrentDomain.BaseDirectory
        //                        + "ReaderAssemblies"
        //                        + Path.DirectorySeparatorChar
        //                        + readerAssemblyName;

        List<Type> readers = [];

        var assemblies = GetAssemblies();
        foreach (var assembly in assemblies)
        {
            ReaderLoadContext loadContext = new ReaderLoadContext(assembly);
            AssemblyName assemblyName = new AssemblyName(Path.GetFileNameWithoutExtension(assembly));
            try
            {
                Assembly readerAssembly = loadContext.LoadFromAssemblyName(assemblyName);
                Type? readerType = readerAssembly.ExportedTypes
                                    .FirstOrDefault(t => (typeof(IPersonReader)).IsAssignableFrom(t));
                if (readerType is not null)
                {
                    readers.Add(readerType);
                }
            }
            catch (Exception)
            {
                // if assembly fails to load, go to next file.
                continue;
            }
        }

        if (readers.Count > 0)
            reader = Activator.CreateInstance(readers.First()) as IPersonReader;

        return reader ?? throw new InvalidOperationException($"Unable to create instance of {reader?.GetType()} as IPersonReader");
    }

    private static List<string> GetAssemblies()
    {
        string readerLocation = AppDomain.CurrentDomain.BaseDirectory
                                + "ReaderAssemblies";
        var files = Directory.GetFiles(readerLocation, "*.dll", SearchOption.TopDirectoryOnly);
        return files.ToList();
    }
}
