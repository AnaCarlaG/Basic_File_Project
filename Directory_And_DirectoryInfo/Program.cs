using System;
using System.IO;

Create_Global_Directory();
Create_File();

var source = Path.Combine(Environment.CurrentDirectory, "brazil.txt");
var destination_move = Path.Combine(Environment.CurrentDirectory, 
                                            "global",
                                            "South America", 
                                            "Brazil",
                                            "brazil.txt");
var destination_copy = Path.Combine(Environment.CurrentDirectory, 
                                            "global",
                                            "South America", 
                                            "Argentina",
                                            "argentina.txt");
//Move_File(source, destination_move);

Copy_File(source, destination_copy);

static void Copy_File(string source, string destination)
{
    if(!File.Exists(source)){
        Console.WriteLine("File on this source directory doesn't exist");
        return;
    }
        if(File.Exists(destination)){
        Console.WriteLine("File on this destination directory have exists already");
        return;
    }

    File.Copy(source, destination);
}

static void Move_File(string source, string destination)
{
    if(!File.Exists(source)){
        Console.WriteLine("File on this source directory doesn't exist");
        return;
    }
        if(File.Exists(destination)){
        Console.WriteLine("File on this destination directory have exists already");
        return;
    }
    File.Move(source, destination);
}
static void Create_File()
{

    var path = Path.Combine(Environment.CurrentDirectory, "brazil.txt");

    if(!File.Exists(path)){
    using var write = File.CreateText(path);

    write.WriteLine("Population: 213M");
    write.WriteLine("IDH: 0.901");
    write.WriteLine("Update on 04/20/2018");
    }
}

static void Create_Global_Directory()
{
    var path = Path.Combine(Environment.CurrentDirectory, "global");

    //test if has some directory in this path
    if (!Directory.Exists(path))
    {
        //create directory
        var dirGlobal = Directory.CreateDirectory(path);
        var dirNAm = dirGlobal.CreateSubdirectory("North America");
        var dirSAm = dirGlobal.CreateSubdirectory("South America");
        var dirCAm = dirGlobal.CreateSubdirectory("Central America");

        //create subdirectory
        dirNAm.CreateSubdirectory("USA");
        dirNAm.CreateSubdirectory("Mexico");
        dirNAm.CreateSubdirectory("Canada");

        dirCAm.CreateSubdirectory("Costa Rica");
        dirCAm.CreateSubdirectory("Panama");

        dirSAm.CreateSubdirectory("Brazil");
        dirSAm.CreateSubdirectory("Argentina");
        dirSAm.CreateSubdirectory("Paraguay");
    }
}