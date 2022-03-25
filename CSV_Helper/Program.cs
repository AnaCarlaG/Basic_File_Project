using System;
using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq;
using System.Collections.Generic;


//Read_CSV_With_Dynamic();
//Read_CSV_With_Class();
//Read_CSV_With_Another_Delimiter();
//Read_CSV_With_Another_Delimiter_No_Header();
Write_CSV();


static void Write_CSV()
{
    var path = Path.Combine(Environment.CurrentDirectory, "Saida");
    var dir = new DirectoryInfo(path);  

    if(!dir.Exists) dir.Create();

    path = Path.Combine(path,"usuario.csv") ;
    
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

    using var sr = new StreamWriter(path);
    var csvConfig = new CsvConfiguration(CultureInfo.InstalledUICulture){
        Delimiter="|"
    };
    using var csvWriter = new CsvWriter(sr, csvConfig);
    csvWriter.WriteRecords(pessoas);
}
static void Read_CSV_With_Another_Delimiter_No_Header()
{
    var path = Path.Combine(Environment.CurrentDirectory, "Entrada", "livro-preco-NoHeader.csv");
    var file = new FileInfo(path);

    if (!file.Exists)
    {
        throw new FileNotFoundException($"File {path} doens't exist");
    }
    using var sr = new StreamReader(file.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        Delimiter = ";",
        HasHeaderRecord = false
    };
    using var csvReader = new CsvReader(sr, csvConfig);
    csvReader.Context.RegisterClassMap<LivroIndexMap>();

    var registros = csvReader.GetRecords<LivroIndex>().ToList();

    foreach (var item in registros)
    {
        Console.WriteLine($"Titulo: {item.Titulo}");
        Console.WriteLine($"Preco: {item.Preco}");
        Console.WriteLine($"Autor: {item.Autor}");
        Console.WriteLine($"Lancamento: {item.Lancamento}");

        Console.WriteLine("----------------");
    }

}

static void Read_CSV_With_Another_Delimiter()
{
    var path = Path.Combine(Environment.CurrentDirectory, "Entrada", "livro-preco.csv");
    var file = new FileInfo(path);

    if (!file.Exists)
    {
        throw new FileNotFoundException($"File {path} doens't exist");
    }
    using var sr = new StreamReader(file.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        Delimiter = ";"
    };
    using var csvReader = new CsvReader(sr, csvConfig);
    csvReader.Context.RegisterClassMap<LivroMap>();

    var registros = csvReader.GetRecords<Livro>().ToList();

    foreach (var item in registros)
    {
        Console.WriteLine($"Titulo: {item.Titulo}");
        Console.WriteLine($"Preco: {item.Preco}");
        Console.WriteLine($"Autor: {item.Autor}");
        Console.WriteLine($"Lancamento: {item.Lancamento}");

        Console.WriteLine("----------------");
    }

}


static void Read_CSV_With_Class()
{
    var path = Path.Combine(Environment.CurrentDirectory, "Entrada", "usuariosFake.csv");
    var file = new FileInfo(path);
    if (!file.Exists)
    {
        throw new FileNotFoundException($"File {path} doens't exist");
    }
    using var sr = new StreamReader(file.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
    using var csvReader = new CsvReader(sr, csvConfig);

    var registros = csvReader.GetRecords<User>();

    foreach (var item in registros)
    {
        Console.WriteLine($"Name: {item.Name}");
        Console.WriteLine($"Email: {item.Email}");
        Console.WriteLine($"Region: {item.Region}");
        Console.WriteLine($"Country: {item.Country}");
        Console.WriteLine($"Phone: {item.Phone}");

        Console.WriteLine("----------------");
    }
}
static void Read_CSV_With_Dynamic()
{
    var path = Path.Combine(Environment.CurrentDirectory, "Entrada", "Produtos.csv");

    var file = new FileInfo(path);
    if (!file.Exists)
    {
        throw new FileNotFoundException($"File {path} doens't exist");
    }
    using var sr = new StreamReader(file.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
    using var csvReader = new CsvReader(sr, csvConfig);

    var registros = csvReader.GetRecords<dynamic>();

    foreach (var item in registros)
    {
        Console.WriteLine($"Name: {item.Produto}");
        Console.WriteLine($"Brand: {item.Marca}");
        Console.WriteLine($"Price: {item.Preco}");

        Console.WriteLine("----------------");
    }
}
Console.WriteLine("\n\nTo end tap some key ...");
Console.ReadKey();
