using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

Create_CSV();

static void Create_CSV()
{
    var path = Path.Combine(Environment.CurrentDirectory, "Saida", "usuarioFake-exportacao.csv");

    var pessoas = new List<Pessoa>(){
        new Pessoa()
        {
            Name =  "Boris Noel",
            Region =  "Cartago",
            Country =  "Netherlands",
            Email =  "in.consectetuer@aol.net",
            Phone =  15814675132
        },
        new Pessoa()
        {

            Name =  "Quintessa Bradford",
            Region =  "Vorarlberg",
            Country =  "Turkey",
            Email =  "auctor.quis@yahoo.org",
            Phone =  6348127630
        },
        new Pessoa()
        {

            Name =  "Yolanda Camacho",
            Region =  " South Australia",
            Country =  "Russian Federation",
            Email =  "sit.amet@icloud.net",
            Phone =  16883461876
        },    
        new Pessoa()  

        {
            Name =  "Charissa Franks",
            Region =  "Coquimbo",
            Country =  "New Zealand",
            Email =  "eu@aol.couk",
            Phone =  9183337222
        },      
        new Pessoa()
        {
            Name =  "Jemima Cunningham", 
            Region =  "Lower Austria,",
            Country =  "Spain",
            Email =  "tellus.lorem@yahoo.com",
            Phone =  3821378390
        }
    };

    var dir = new DirectoryInfo(path);
    if(!dir.Exists){
        dir.Create();
        path = Path.Combine(path, "usuariosFake.csv");
    }

    // Using the word using for not gave flush function on this writter
    //Colocar o using por que assim que acabar o escopo já vai ser dado o flush automaticamente
    using var sw = new StreamWriter(path);
    sw.WriteLine("name,region,country,email,phone");
    foreach (var pessoa in pessoas)
    {
        var linha =$"{pessoa.Name},{pessoa.Region},{pessoa.Country},{pessoa.Email},{pessoa.Phone}";
        sw.WriteLine(linha);
    }
}



// using var sr = new StreamReader(path);
// var header = sr.ReadLine()?.Split(',');

// while (true)
// {
//     var registro = sr.ReadLine()?.Split(',');

//     if (header.Length != registro.Length)
//     {
//         Console.WriteLine("Error on file");
//         break;
//     }
//     if (registro == null) break;

//     for (int i = 0; i < registro.Length; i++)
//     {
//         Console.WriteLine($"{header?[i]}:{registro[i]}");
//     }

//     Console.WriteLine("-------------------");
// }
Console.WriteLine("\n\nTo end tap some key ...");
Console.ReadKey();
