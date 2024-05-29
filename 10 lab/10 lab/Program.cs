using Microsoft.VisualBasic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;


class Program
{
    static void Main()
    {
        // Создайте массив из 20 фильмов.
        Movie[] movies = {
            new Movie("Побег из Шоушенка", "Фрэнк Дарабонт", 1994, 9.3, 142),
            new Movie("Крёстный отец", "Фрэнсис Форд Коппола", 1972, 9.2, 175),
            new Movie("Властелин колец: Возвращение короля", "Питер Джексон", 2003, 8.9, 201),
            new Movie("Звёздные войны: Эпизод 5 – Империя наносит ответный удар", "Ирвин Кершнер", 1980, 8.7, 124),
            new Movie("Темный рыцарь", "Кристофер Нолан", 2008, 9.0, 152),
            new Movie("Форрест Гамп", "Роберт Земекис", 1994, 8.8, 142),
            new Movie("Пианист", "Роман Полански", 2002, 8.5, 150),
            new Movie("Бойцовский клуб", "Дэвид Финчер", 1999, 8.8, 139),
            new Movie("Король Лев", "Роджер Аллерс, Роб Минкофф", 1994, 8.5, 88),
            new Movie("Список Шиндлера", "Стивен Спилберг", 1993, 8.9, 195),
            new Movie("Исчезнувшая", "Дэнни Бойл", 2010, 7.7, 94),
            new Movie("Леон", "Люк Бессон", 1994, 8.5, 110),
            new Movie("Вверх", "Пит Доктер", 2009, 8.2, 96),
            new Movie("Гладиатор", "Ридли Скотт", 2000, 8.5, 155),
            new Movie("Подозрительные лица", "Брайан Сингер", 1995, 8.5, 106),
            new Movie("Загадочная история Бенджамина Баттона", "Дэвид Финчер", 2008, 7.8, 166),
            new Movie("Матрица", "Братья Вачовски", 1999, 8.7, 136),
            new Movie("Гарри Поттер и философский камень", "Крис Коламбус", 2001, 7.6, 152),
            new Movie("Терминатор 2: Судный день", "Джеймс Кэмерон", 1991, 8.5, 137),
            new Movie("Назад в будущее", "Роберт Земекис", 1985, 8.5, 116)
        };

        // Создайте массив из 20 сериалов.
        Series[] series = {
            new Series("Во все тяжкие", "Режисер", 2005, 10.0, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series( "Игра престолов", "Дэвид Бениофф, Дэниэл Бретон", 2011, 9.3, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Черное зеркало", "Чарли Брукер", 2011, 8.8, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Друзья", "Кевин С. Брайт", 1994, 8.9, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Шерлок", "Пол МакГиган", 2010, 9.1, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Карточный домик", "Дэвид Финчер", 2013, 8.8, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Стрела", "Грег Берланти", 2012, 7.5, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Вызов", "Марк Фрост, Дэвид Линч", 1990, 8.8, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Декстер", "Джеймс Манос мл.", 2006, 8.6, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Люцифер", "Том Капинос", 2015, 8.1, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Фарго", "Ноа Хоули", 2014, 8.9, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Теория большого взрыва", "Чак Лорри, Билл Прэди", 2007, 8.1, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Мистер Робот", "Сэм Эсмаил", 2015, 8.5, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Миллиарды", "Брайан Коппельман, Дэвид Левин", 2016, 8.3, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Ходячие мертвецы", "Фрэнк Дарабонт", 2010, 8.2, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Ведьмак", "Алексей Шантцев", 2019, 8.2, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Американская история ужасов", "Райан Мёрфи", 2011, 8.0, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Бэтвумен", "Кэролайн Драйс", 2019, 3.3, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Инспектор Морс", "Питер Дьюж", 1987, 8.7, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } ),
            new Series("Великолепный век", "Дэмир Алтунай, Али Бильгин, Сёнюлай Семпер", 2011, 6.7, new int[,]{ { 60, 60, 60 }, { 60, 60, 60} } )
        };

        Cartoon[] cartoons =
        {
            new Cartoon( "Король Лев", "Роджер Аллерс", 1994, 8.5, 88, "0+", "3D"),
            new Cartoon("В поисках Немо", "Эндрю Стэнтон", 2003, 8.1, 100, "0+", "3D"),
            new Cartoon("Холодное сердце", "Крис Бак", 2013, 7.5, 102, "0+", "3D"),
            new Cartoon("Как приручить дракона", "Дин Деблуа", 2010, 8.1, 98, "0+", "3D"),
            new Cartoon("ВАЛЛ-И", "Эндрю Стэнтон", 2008, 8.4, 98, "0+", "3D"),
            new Cartoon("Тайна Коко", "Ли Анкрич", 2017, 8.4, 105, "0+", "3D"),
            new Cartoon("Тачки", "Джон Лассетер", 2006, 7.1, 117, "0+", "3D"),
            new Cartoon("Монстры, Инк.", "Пит Доктер", 2001, 8, 92, "0+", "3D"),
            new Cartoon("Корпорация монстров", "Пит Доктер", 2001, 8, 92, "0+", "3D"),
            new Cartoon("Кунг-фу Панда", "Марк Осборн", 2008, 7.6, 92, "0+", "3D"),
        };

        // Создайте массив из 3 - х каталогов фильмов.

        MoviesList[] catalogs = 
        {
            new MoviesList(),
            new MoviesList(),
            new MoviesList()
        };

        // Добавьте в каждый каталог по 5 рандомных фильмов.
        Random rand = new Random();

        for (int i = 0; i < 3; ++i)
        {
            // Добавляем случайное кино
            while (catalogs[i].Count() < 5)
                catalogs[i].AddMovie(movies[rand.Next(movies.Length)]);
            // Добавьте в каждый каталог по одному сериалу.
            catalogs[i].AddMovie(series[rand.Next(series.Length)]);
        }

        // Создайте объект типа MyJsonSerializer.
        // Сохраните массив отчетов в файл raw_data.json.

        MyJsonSerializer serializer = new MyJsonSerializer();
        string fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "10 lab");
        if (!Directory.Exists(fullPath))
            Directory.CreateDirectory(fullPath);

        string jsonFile = Path.Combine(fullPath, "raw_data.json");
        serializer.Write<MoviesList[]>(catalogs, jsonFile);
        MoviesList[] catalogsLoaded = serializer.Read<MoviesList[]>(jsonFile);

        for (int i = 0; i < 3; ++i)
        {
            Console.WriteLine($"Catalog {i} Initial state (from file):");
            catalogsLoaded[i].DisplayList();
        }
        Console.WriteLine("===============");

        // Отсортируйте фильмы по дате от старых к новым. Сохраните массив каталогов в файл data.json
        for (int i = 0; i < 3; ++i)
            catalogs[i].SortByDate();

        jsonFile = Path.Combine(fullPath, "data.json");
        serializer.Write<MoviesList[]>(catalogs, jsonFile);
        MoviesList[] sortedByDateLoaded = serializer.Read<MoviesList[]>(jsonFile);

        for (int i = 0; i < 3; ++i)
        {
            Console.WriteLine($"Catalog {i} sorted by date (from file):");
            sortedByDateLoaded[i].DisplayList();
        }
        Console.WriteLine("===============");


        //Добавьте ещё по 3 сериала в каждый каталог. Отсортируйте по названию.Сохраните в файл sort_data.json.
        for (int i = 0; i < 3; ++i)
        {
            while (catalogs[i].Count() < 8)
                catalogs[i].AddMovie(series[rand.Next(series.Length)]);
            catalogs[i].SortByTitle();
        }

        jsonFile = Path.Combine(fullPath, "sort_data.json");
        serializer.Write<MoviesList[]>(catalogs, jsonFile);
        MoviesList[] sortedByTitleLoaded = serializer.Read<MoviesList[]>(jsonFile);

        for (int i = 0; i < 3; ++i)
        {
            Console.WriteLine($"Catalog {i} sorted by title from file:");
            sortedByTitleLoaded[i].DisplayList();
        }
        Console.WriteLine("===============");





        for (int i = 0; i < 3; ++i)
        {
            // Удаляем все фильмы раньше 2000 года. ПО заданию нужно раньше 2020, но у нас нет
            // фильмов и сериалов после 2020 года. Тогда вообще ничего не будет.
            Movie[] moviesToErase = Movie.Select(catalogs[i].getMovies(), 2000);
            foreach (Movie movie in moviesToErase)
                catalogs[i].RemoveMovie(movie);

            // Удаляем сериалы раньше 2010 года
            Movie[] seriesToErase = Movie.Select(catalogs[i].getSeries(), 2010);
            foreach (Movie movie in seriesToErase)
                catalogs[i].RemoveMovie(movie);
        }

        // Сохраняем в файл
        MyXmlSerializer serializerXml = new MyXmlSerializer();

        string xmlFile = Path.Combine(fullPath, "raw_data.xml");

        serializerXml.Write<MoviesList[]>(catalogs, xmlFile);
        MoviesList[] rawCatalogsXmlLoaded = serializerXml.Read<MoviesList[]>(xmlFile);

        for (int i = 0; i < 3; ++i)
        {
            Console.WriteLine($"Catalog {i} raw data (from xml):");
            rawCatalogsXmlLoaded[i].DisplayList();
        }
        Console.WriteLine("===============");



        // Добавляем по 5 случайных мультфильмов в каждый каталог
        for (int i = 0; i < 3; ++i)
        { 
            int moviesInCatalog = catalogs[i].Count();
            while (catalogs[i].Count() < moviesInCatalog + 5)
                catalogs[i].AddMovie(cartoons[rand.Next(cartoons.Length)]);
        }

        xmlFile = Path.Combine(fullPath, "data.xml");
        serializerXml.Write<MoviesList[]>(catalogs, xmlFile);
        MoviesList[] catalogsXmlLoaded = serializerXml.Read<MoviesList[]>(xmlFile);

        for (int i = 0; i < 3; ++i)
        {
            Console.WriteLine($"Catalog {i} with cartoons (from xml):");
            catalogsXmlLoaded[i].DisplayList();
        }
        Console.WriteLine("===============");

        MoviesList totalCatalog = new MoviesList();
        for (int i = 0; i < 3; ++i)
        {
            Movie[] moviesOfCatalog = catalogs[i].getAllMoviesOfCatalog();
            foreach (Movie movie in moviesOfCatalog)
                totalCatalog.AddMovie(movie);
        }
        totalCatalog.SortByDate();

        xmlFile = Path.Combine(fullPath, "sort_data.xml");
        serializerXml.Write<MoviesList>(totalCatalog, xmlFile);
        MoviesList totalCatalogLoaded = serializerXml.Read<MoviesList>(xmlFile);

        Console.WriteLine($"Total catalog (from xml):");
        totalCatalog.DisplayList();
    }
}
