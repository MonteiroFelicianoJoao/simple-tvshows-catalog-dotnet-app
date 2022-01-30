using TvShowCatalog.Classes;
using static System.Console;

namespace TvShowCatalog
{
    class Program
    {
        static TvShowRepository repository = new TvShowRepository();
        static void Main(string[] args)
        {   
            string userOption = GetUserOption();

            while(userOption.ToUpper() != "X")
            {
                switch(userOption)
                {
                    case "1":
                        TvShowList();
                    break;

                    case "2":
                        TvShowInsert();
                    break;

                    case "3":
                        TvShowUpdate();
                    break;

                    case "4":
                        TvShowRemove();
                    break;

                    case "5":
                        TvShowView();
                    break;

                    case "C":
                        Clear();
                    break;

                    default: throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
            WriteLine("Aplication ended!");
            ReadLine();
        }

       
        private static void TvShowView()
        {
            Write("Type the TV show ID: ");
            int tvShowIndexId = int.Parse(ReadLine());

            var tvShow = repository.ReturnById(tvShowIndexId);

            WriteLine(tvShow);
        }

        private static void TvShowRemove()
        {
            Write("Type the TV show ID: ");
            int tvShowIndexId = int.Parse(ReadLine());

            repository.Delete(tvShowIndexId);
        }

        private static void TvShowUpdate()
        {
            Write("Type the TV show ID: ");
            int tvShowIndexId = int.Parse(ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                WriteLine("{0} {1}", i, Enum.GetName(typeof(Genre), i));
            }
            
            Write("Type genre as above options: ");
            int genreOption = int.Parse(ReadLine());
            
            Write("Type serie's tittle: ");
            string addingTittle = ReadLine();
            
            Write("Type serie's year: ");
            int addingYear = int.Parse(ReadLine());
            
            Write("Type serie's description: ");
            string addingDescription = ReadLine();

            TvShow updateTvShow = new TvShow(id: tvShowIndexId,
                                             genre: (Genre)genreOption,
                                             tittle: addingTittle,
                                             year: addingYear,
                                             description: addingDescription);
            repository.Update(tvShowIndexId, updateTvShow);
        }

        private static void TvShowInsert()
        {
            foreach(int i in Enum.GetValues(typeof(Genre)))
            {
                WriteLine("{0} {1}", i, Enum.GetName(typeof(Genre), i));
            }
            
            WriteLine();
            Write("Type genre as above options: ");
            int genreOption = int.Parse(ReadLine());
            
            Write("Type serie's tittle: ");
            string addingTittle = ReadLine();
            
            Write("Type serie's year: ");
            int addingYear = int.Parse(ReadLine());
            
            Write("Type serie's description: ");
            string addingDescription = ReadLine();

            TvShow newTvShow = new TvShow(id: repository.NextId(),
                                             genre: (Genre)genreOption,
                                             tittle: addingTittle,
                                             year: addingYear,
                                             description: addingDescription);
            repository.Insert(newTvShow);
        }

        private static void TvShowList()
        {   
            WriteLine("     List TV shows");
            WriteLine();
            
            var list = repository.List();

            if(list.Count == 0)
            {
                WriteLine("There is no TV show in catalog.");
                return;
            }

            foreach (var tvShow in list)
            {
                WriteLine("#ID {0}: {1}", tvShow.IdReturnner(), tvShow.TittleReturnner());
            }
        }
    
        private static string GetUserOption()
                {
                    WriteLine();
                    WriteLine("TV SHOW CATALLOG APP");
                    WriteLine();
                    WriteLine("Choose a option:");

                    WriteLine(@"
                    1- List TV shows.
                    2- Insert a new TV show.
                    3- Update a TV show.
                    4- Remove a TV show.
                    5- Pick a TV show.
                    C- Clear screen.
                    X- Exit.

                    ");
                    
                    string userOption = ReadLine().ToUpper();
                    WriteLine();
                    return userOption;
                }          
    }
}