using ProjectSeries;
using ProjectSeries.Entities;
using ProjectSeries.Entities.Enum;


SeriesRepository repository = new SeriesRepository();

string userOption = GetUserOption();

while (userOption.ToUpper() != "X")
{
    switch (userOption)
    {
        case "1":
            ListSeries();
            break;
        case "2":
            InsertSeries();
            break;
        case "3":
            UpdateSeries();
            break;
        case "4":
            ExcludeSeries();
            break;
        case "5":
           ViewSeries();
            break;
        case "C":
            Console.Clear();
            break;

        default:
            throw new ArgumentOutOfRangeException();
    }

    userOption = GetUserOption();
}
Console.WriteLine("Obrigado por utilizar nossos serviços.");
Console.ReadLine();

void ListSeries()
{
    System.Console.WriteLine("Listar Séries");
    
    var list = repository.List();
    if (list.Count == 0)
    {
        System.Console.WriteLine("Nenhuma série cadastrada.");
        return;
    }
    foreach (var item in list)
    {
        var excluded = item.ReturnExcluded();
        
        System.Console.WriteLine("#ID {0}: - {1} - {2}", item.ReturnId(), item.ReturnTitle(), (excluded ? "*Excluído*" : ""));
    }

}

void ExcludeSeries()
{
    Console.WriteLine("Digite o Id da série: ");
    int indexSeries = int.Parse(Console.ReadLine());

    repository.Exclude(indexSeries);
}

void InsertSeries()
    {
        Console.WriteLine("Inserir nova série: ");

        foreach(int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
        }
        System.Console.Write("Digite o gênero entre as opções acima: ");
        int entryKind = int.Parse(Console.ReadLine());

        System.Console.Write("Digite o título da série: ");
        string entryTitle = Console.ReadLine();

        System.Console.Write("Digite o ano de lançamento da série: ");
        int entryRelease = int.Parse(Console.ReadLine());

        System.Console.Write("Digite a descrição da série: ");
        string entryDescription = Console.ReadLine();

        Series newSeries = new Series(id: repository.NextId(), 
                                       kind: ((Genero)entryKind),
                                       title: entryTitle, 
                                       release: entryRelease, 
                                       description: entryDescription);

       repository.Insert(newSeries);
    }

void UpdateSeries()
{
    Console.WriteLine("Digite o Id da série: ");
    int indexSeries = int.Parse(Console.ReadLine());

    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
    }
    System.Console.Write("Digite o gênero entre as opções acima: ");
    int entryKind = int.Parse(Console.ReadLine());

    System.Console.Write("Digite o título da série: ");
    string entryTitle = Console.ReadLine();

    System.Console.Write("Digite o ano de lançamento da série: ");
    int entryRelease = int.Parse(Console.ReadLine());

    System.Console.Write("Digite a descrição da série: ");
    string entryDescription = Console.ReadLine();

    Series updateSeries = new Series(id: indexSeries,
                                   kind: ((Genero)entryKind),
                                   title: entryTitle,
                                   release: entryRelease,
                                   description: entryDescription);

    repository.Update(indexSeries, updateSeries);
}

void ViewSeries()
{
    Console.WriteLine("Digite o Id da série: ");
    int indexSeries = int.Parse(Console.ReadLine());

    var series = repository.ReturnId(indexSeries);
    Console.WriteLine(series);
}


static string GetUserOption()
{
    Console.WriteLine();
    Console.WriteLine("Bem-vindo!!"); 
    Console.WriteLine("Informe a opção desejada:"); 

    Console.WriteLine("1 - Listar séries");
    Console.WriteLine("2 - Inserir nova série");
    Console.WriteLine("3 - Atualizar série");
    Console.WriteLine("4 - Excluir série");
    Console.WriteLine("5 - Visualizar série");
    Console.WriteLine("C - Limpar tela");
    Console.WriteLine("X - Sair");
    Console.WriteLine();

    string userOption = Console.ReadLine().ToUpper();
    Console.WriteLine();
    return userOption;
}


