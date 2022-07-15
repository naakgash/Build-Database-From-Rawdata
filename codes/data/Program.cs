using data;
using data.BaseModels;
using data.SeedModels;
using Nancy.Json;

class Program
{
    static void Main(string[] args)
    {
        // The process of saving the unique cases of Collection, Genre, Country, Language data to the list repeated in the table.
        using (var _context = new IMDBContext())
        {
            JavaScriptSerializer jsd = new();

            List<Country> countryList = new();
            List<Country> tempCountryList = new();

            List<Language> languageList = new();
            List<Language> tempLanguageList = new();

            List<Genre> genreList = new();
            List<Genre> tempGenreList = new();

            List<Collection> collectionList = new();
            List<Collection> tempCollectionList = new();

            int counter = 45463*2; // the counter value for user

            // The movie information in the database is progressed line by line.
            foreach (var x in _context.Rawdata)
            {
                Console.WriteLine(counter--);

                // Country information in json format in the 'Country' column of the 'Movies_metada' table is deserialized
                // and converted into a 'Country class' in the 'Model' folder.
                var countryLogs = jsd.Deserialize<List<SeedCountry>>(x.ProductionCountries.Replace("D'I", "DI")
                    .Replace("'s ", "s ").Replace("\\\"", "'").Replace("'", "\""));
                foreach (var t in countryLogs) 
                {
                    tempCountryList.Add(new() {  Abbreviation=t.iso_3166_1, Name=t.name });
                }

                // Language information in json format in the 'Language' column of the 'Movies_metada' table is deserialized
                // and converted into a 'Language class' in the 'Model' folder.
                var languageLogs = jsd.Deserialize<List<SeedLanguage>>(x.SpokenLanguages.Replace("'", "\""));
                foreach (var c in languageLogs)
                {
                    tempLanguageList.Add(new() { Abbreviation = c.iso_639_1, Name = c.name });
                }

                // Genre information in json format in the 'Genre' column of the 'Movies_metada' table is deserialized
                // and converted into a 'Genre class' in the 'Model' folder.
                var genreLogs = jsd.Deserialize<List<SeedGenre>>(x.Genres.Replace("'", "\""));
                foreach (var g in genreLogs)
                {
                    tempGenreList.Add(new() { DataId=g.id, Name=g.name });
                }

                // Collection information in json format in the 'Collection' column of the 'Movies_metada' table is deserialized
                // and converted into a 'Collection class' in the 'Model' folder.
                if (x.BelongsToCollection != null)
                {
                    var o = jsd.Deserialize<SeedCollection>(x.BelongsToCollection.Replace("'re","re").Replace("n't","nt").Replace("l'o", "Io").Replace("N'E","NE").Replace("L'a","La").Replace("'Em ", "Em").Replace("d'a","da").Replace("O'B","OB").Replace("' "," ").Replace("\\\"", "'").Replace(" 'n ","n").Replace("'s ", "s ").Replace("None", "'None'").Replace("'", "\""));
                    tempCollectionList.Add(new() { DataId = o.id, Name = o.name, PosterPath = o.poster_path, BackdropPath = o.backdrop_path });
                }
                
                
            }

            //The repetitions in all the obtained lists are deleted and each list is made unique.
            var uniqueCountries = tempCountryList
                .GroupBy(p => p.Abbreviation)
                .Select(grp => grp.First())
                .ToArray();
            var uniqueLanguages = tempLanguageList
                .GroupBy(p => p.Abbreviation)
                .Select(grp => grp.First())
                .ToArray();
            var uniqueGenres = tempGenreList
                .GroupBy(p => p.Name)
                .Select(grp => grp.First())
                .ToArray();
            var uniqueCollections = tempCollectionList
                .GroupBy(p => p.Name)
                .Select(grp => grp.First())
                .ToArray();

            // A 'primary key' value is assigned to the data in the lists.
            int countryCounter = 1; 
            foreach(var c in uniqueCountries)
            {
                countryList.Add(new() { Id = countryCounter++, Abbreviation=c.Abbreviation, Name=c.Name});
            }

            int languageCounter = 1;
            foreach (var l in uniqueLanguages)
            {
                languageList.Add(new() { Id = languageCounter++, Abbreviation=l.Abbreviation, Name=l.Name});
            }

            int genreCounter = 1;
            foreach (var g in uniqueGenres)
            {
                genreList.Add(new() { Id = genreCounter++, DataId=g.DataId, Name=g.Name });
            }

            int collectionCounter = 1;
            foreach (var o in uniqueCollections)
            {
                collectionList.Add(new() { Id = collectionCounter++, DataId = o.DataId, Name = o.Name, PosterPath=o.PosterPath, BackdropPath=o.BackdropPath });
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            // In Movies_metada, it is progressed line by line
            // and related relations are established for each line and data is added to
            // the newly created Movies, Genres, Collections, Countries, Languages tables.

            foreach (var x in _context.Rawdata)
            {
                Console.WriteLine(counter--);

                // The unrelated data in each row is saved in the corresponding columns in the Movies table.
                var movie = new Movie() {Adult=x.Adult, Budget=x.Budget, VoteCount=x.VoteCount,
                    Homepage=x.Homepage, DataId=x.Id, ImdbId=x.ImdbId, OriginalLanguage=x.OriginalLanguage, 
                    OriginalTitle=x.OriginalTitle, Overview=x.Overview, Popularity=x.Popularity, PosterPath=x.PosterPath, 
                    ReleaseDate=x.ReleaseDate, Revenue=x.Revenue, Runtime=x.Runtime, Status=x.Status, Tagline=x.Tagline, 
                    Title=x.Title, Video=x.Video, VoteAverage=x.VoteAverage };

                // 'Genre' information in json form is converted into a 'genre class instance' and saved in the 'Genres table'.
                var genrelogs = jsd.Deserialize<List<SeedGenre>>(x.Genres.Replace("'", "\""));
                foreach (var gl in genreList)
                {
                    foreach (var log in genrelogs)
                    {
                        if (gl.Name.Equals(log.name))
                        {
                            movie.Genres.Add(gl);
                        }
                    }
                }

                // 'Collection' information in json form is converted into a 'collection class instance' and saved in the 'Collections table'.
                if (x.BelongsToCollection != null)
                {
                    var log = jsd.Deserialize<SeedCollection>(x.BelongsToCollection.Replace("'re", "re").Replace("n't", "nt").Replace("l'o", "Io").Replace("N'E", "NE").Replace("L'a", "La").Replace("'Em ", "Em").Replace("d'a", "da").Replace("O'B", "OB").Replace("' ", " ").Replace("\\\"", "'").Replace(" 'n ", "n").Replace("'s ", "s ").Replace("None", "'None'").Replace("'", "\""));
                    foreach (var ol in collectionList)
                    {
                            if (ol.Name.Equals(log.name))
                            {
                                movie.Collections.Add(ol);
                                Console.WriteLine(ol.Name);
                            }
                    }
                }

                // 'Country' information in json form is converted into a 'country class instance' and saved in the 'Countries table'.
                var countryLogs = jsd.Deserialize<List<SeedCountry>>(x.ProductionCountries.Replace("D'I", "DI").Replace("'s ", "s ").Replace("\\\"", "'").Replace("'", "\""));
                foreach(var cl in countryList)
                {
                    foreach(var log in countryLogs)
                    {
                        if (cl.Abbreviation.Equals(log.iso_3166_1))
                        {
                            movie.Countries.Add(cl);
                        }
                    }
                }

                // 'Language' information in json form is converted into a 'language class instance' and saved in the 'Languages table'.
                var languageLogs = jsd.Deserialize<List<SeedLanguage>>(x.SpokenLanguages.Replace("'", "\""));
                foreach(var ll in languageList)
                {
                    foreach (var log in languageLogs)
                    {
                        if (ll.Abbreviation.Equals(log.iso_639_1))
                        {
                            movie.SpokenLanguages.Add(ll);
                        }
                    }
                }

                // The created data is saved to be sent to the database.
                _context.Add(movie);
            }
            Console.Clear();
            Console.WriteLine("Your transaction will be finished soon, please wait...");

            // Ready data is sent to the database.
            _context.SaveChanges();
        }
    }
}