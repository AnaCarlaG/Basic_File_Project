using System;
using System.IO;
using static System.Console;


WriteLine("Digite o nome do arquivo");
var name = ReadLine();

var path = Path.Combine(Environment.CurrentDirectory, $"{name}.txt");
Name_Clean(name);
Create_File(path);

WriteLine("To end tap some key ...");
ReadKey();

static void Name_Clean(string name){
foreach (var @char in Path.GetInvalidFileNameChars()) 
{
    name.Replace(@char, '_');
}
}
//escrevendo no arquivo

static void Create_File(string path)
{
    try
    {
        // Criar um arquivo
      using var write = File.CreateText(path);

        write.WriteLine("I'm writing some text");
        write.Flush();
    }
    catch
    {
        WriteLine("Name of file is invalid");
    }

}


