using System;
using System.IO;

var path = @"D:\Repositorio\Basic_File_Project\Directory_And_DirectoryInfo\global";

//Read_Directory(path);
Read_Files(path);
Console.WriteLine("To end tap some key ...");
Console.ReadKey();

static void Read_Files(string path)
{
    var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
    foreach(var file in files){
        var fileInfo = new FileInfo(file);

        Console.WriteLine($"[Name]: {fileInfo.Name}");
        Console.WriteLine($"[Length]: {fileInfo.Length}");
        Console.WriteLine($"[Last acessed time]: {fileInfo.LastAccessTime}");
        Console.WriteLine($"[Directory]: {fileInfo.DirectoryName}");

        Console.WriteLine("-----------------------");
    }
}
static void Read_Directory(string path)
{
    if(Directory.Exists(path)){
            var directory = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);

    foreach (var dir in directory)
    {
        var dirInfo = new DirectoryInfo(path);
        Console.WriteLine($"[Name]: {dirInfo.Name}");
        Console.WriteLine($"[Root]: {dirInfo.Root}");

        if(dirInfo.Parent != null)
            Console.WriteLine($"[Parent]: {dirInfo.Parent.Name}");

        Console.WriteLine("---------------");
    }
    } else{
        Console.WriteLine($"{path} doens't exists");
    }
}