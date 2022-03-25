using System;
using System.IO;

var path = Path.Combine("D:\\Repositorio\\Basic_File_Project\\" ,"Directory_And_DirectoryInfo","global");
using var fsw = new FileSystemWatcher(path);

fsw.Created+= OnCreated;
fsw.Deleted+= OnDeleted;
fsw.Renamed+= OnRenamed;

fsw.EnableRaisingEvents = true;
fsw.IncludeSubdirectories = true;

Console.WriteLine($"Monitoring: {path}");
Console.WriteLine("To end tap some key ...");
Console.ReadKey();

void OnCreated(Object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"File created: {e.Name}");
}
void OnDeleted(Object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"File deleted: {e.Name}");
}
void OnRenamed(Object sender, RenamedEventArgs e)
{ 
    Console.WriteLine($"File {e.OldName} renamed to: {e.Name}");
}