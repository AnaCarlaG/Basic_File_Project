using CsvHelper.Configuration;
using System.Globalization;

public class LivroIndexMap : ClassMap<Livro>
{
    public LivroIndexMap()
    {
        string format = "dd/MM/yyyy";
        Map(x => x.Titulo).NameIndex(0);
        Map(x => x.Preco).NameIndex(1)
                            .TypeConverterOption
                            .CultureInfo(CultureInfo.GetCultureInfo("pt-BR"));
        Map(x => x.Autor).NameIndex(2);
        Map(x => x.Lancamento).NameIndex(3)
                                .TypeConverterOption
                                .Format(new []{"dd/MM/yyyy"});
    }   
}