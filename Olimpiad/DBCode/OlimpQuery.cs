using System;
using System.Linq;

namespace Olympiad
{
    internal class OlimpQuery
    {
        public OlimpQuery()
        {

        }

        public void PartiCountry_List()
        {
            using (OlimpContext context = new OlimpContext())
            {
//                var c = context.PartiLists.Join(context.Participants, o => o.PartiId, u => u.Id, (o, u) => new { PartiListId = o.Id, PartiName = u.ParticipantName, KindSportId = o.KindSportId, CityCountryId = u.CountryId }).AsEnumerable()
//#pragma warning disable CS0411 // Аргументы типа для метода "Enumerable.Join<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter>, IEnumerable<TInner>, Func<TOuter, TKey>, Func<TInner, TKey>, Func<TOuter, TInner, TResult>)" не могут определяться по использованию. Попытайтесь явно определить аргументы типа.
//                    .Join(context.KindSports, i => i.KindSportId, y => y.KindSportName, (i, y) => new { PartiListId = i.PartiListId, PartiName = i.PartiName, CityCountryId = i.CityCountryId, KindSportName = y.KindSportName }).AsEnumerable()
//#pragma warning restore CS0411 // Аргументы типа для метода "Enumerable.Join<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter>, IEnumerable<TInner>, Func<TOuter, TKey>, Func<TInner, TKey>, Func<TOuter, TInner, TResult>)" не могут определяться по использованию. Попытайтесь явно определить аргументы типа.
//                    .Join(context.CityCountries, j => j.CityCountryId, g => g.CountryId, (j, g) => new { PartiListId = j.PartiListId, PartiName = j.PartiName, KindSportName = j.KindSportName, CountryId = g.CountryId }).AsEnumerable()
//                    .Join(context.Countries, o1 => o1.CountryId, u1 => u1.CountryName, (o1, u1) => new { PartiListId = o1.PartiListId, PartiName = o1.PartiName, KindSportName = o1.KindSportName, CountryName = u1.CountryName }).AsEnumerable()
//                    .Join(context.Results, i1 => i1.PartiListId, y1 => y1.Score, (i1, y1) => new { PartiListId = i1.PartiListId, PartiName = i1.PartiName, KindSportName = i1.KindSportName, CountryName = i1.CountryName, Score = y1.Score }).AsEnumerable();
            }
        }

        public void Parti_Sport_List(string someOlimp)
        {
            using (OlimpContext context = new OlimpContext())
            {
                var res =
                       from c in context.Results
                       join d in context.OlimpInfos on c.OlimpInfoId equals d.Id
                       where d.OlimpName.Equals(someOlimp)
                       select c;

                if (res != null)
                {
                    foreach (var item in res)
                    {
                        var participants = from partcol in context.PartiLists join part in context.Participants on partcol.PartiId equals part.Id select part;
                        var sports = from partcol in context.PartiLists join part in context.Participants on partcol.PartiId equals part.Id join sportcol in context.KindSports on partcol.KindSportId equals sportcol.Id select sportcol;
                        var results = from score in context.Results select score;

                        if (participants != null)
                        {
                            for (int i = 0, j = 0, c = 0; i < participants.Count() && j < sports.Count() && c < results.Count(); i++, j++)
                            {
                                Console.WriteLine($"Name {participants.ElementAt(i).ParticipantName} Sport {sports.ElementAt(j).KindSportName} Score {results.ElementAt(c).Score}");
                            }
                        }
                    }
                }
            }
        }

        public void Parti_Sport_List()
        {
            using (OlimpContext context = new OlimpContext())
            {
                var res =
                           from c in context.Results
                           join d in context.OlimpInfos on c.OlimpInfoId equals d.Id
                           select c;

                if (res != null)
                {
                    foreach (var item in res)
                    {
                        var participants = from partcol in context.PartiLists join part in context.Participants on partcol.PartiId equals part.Id select part;
                        var sports = from partcol in context.PartiLists join part in context.Participants on partcol.PartiId equals part.Id join sportcol in context.KindSports on partcol.KindSportId equals sportcol.Id select sportcol;
                        var results = from score in context.Results select score;

                        if (participants != null)
                        {
                            for (int i = 0, j = 0, c = 0; i < participants.Count() && j < sports.Count() && c < results.Count(); i++, j++, c++)
                            {
                                Console.WriteLine($"Name {participants.ElementAt(i).ParticipantName} Sport {sports.ElementAt(j).KindSportName} Score {results.ElementAt(c).Score}");
                            }
                        }
                    }
                }

            }
        }

        public void BestCountry(string someOlimp)
        {
            using (OlimpContext context = new OlimpContext())
            {
                var countries =
                                 from resul in context.Results
                                 join olimpinfs in context.OlimpInfos on resul.OlimpInfoId equals olimpinfs.Id
                                 join coun_city in context.CityCountries on olimpinfs.CityCountryId equals coun_city.Id
                                 join coun in context.Countries on coun_city.CountryId equals coun.Id
                                 where olimpinfs.OlimpName.Equals(someOlimp)
                                 orderby resul.Score
                                 select coun.CountryName;


                Console.WriteLine(countries.First());
            }
        }

        public void BestCountry()
        {
            using (OlimpContext context = new OlimpContext())
            {
                var countries =
                                 from resul in context.Results
                                 join olimpinfs in context.OlimpInfos on resul.OlimpInfoId equals olimpinfs.Id
                                 join coun_city in context.CityCountries on olimpinfs.CityCountryId equals coun_city.Id
                                 join coun in context.Countries on coun_city.CountryId equals coun.Id
                                 orderby resul.Score
                                 select coun.CountryName;

                Console.WriteLine(countries.First());
            }
        }

        public void BestSportsMan(string someSport)
        {
            using (OlimpContext context = new OlimpContext())
            {
                var sportsman =
                                 from resul in context.Results
                                 join partilist in context.PartiLists on resul.PartiListId equals partilist.Id
                                 join parti in context.Participants on partilist.PartiId equals parti.Id
                                 join sportlist in context.KindSports on partilist.KindSportId equals sportlist.Id
                                 where sportlist.KindSportName.Equals(someSport)
                                 orderby resul.Score
                                 select parti.ParticipantName;

                if (sportsman != null)
                {
                    foreach (var result in sportsman)
                    {
                        Console.WriteLine(result);
                    }
                }
            }
        }

        public void BestSportsMan()
        {
            using (OlimpContext context = new OlimpContext())
            {
                var sportsman =
                                 from resul in context.Results
                                 join partilist in context.PartiLists on resul.PartiListId equals partilist.Id
                                 join parti in context.Participants on partilist.PartiId equals parti.Id
                                 join sportlist in context.KindSports on partilist.KindSportId equals sportlist.Id
                                 orderby resul.Score
                                 select parti.ParticipantName;

                Console.WriteLine(sportsman.First());
            }
        }

        public void PopCountry()
        {
            using (OlimpContext ctx = new OlimpContext())
            {
                var coun = from resul in ctx.Results join olimp in ctx.OlimpInfos on resul.OlimpInfoId equals olimp.Id select olimp.OlimpName;

                if (coun != null)
                {
                    int max_country = 0, country_index = 0;

                    foreach (var result in coun)
                    {
                        country_index++;

                        if (country_index >= max_country)
                        {
                            max_country = country_index; //max_country += country_index ???
                            country_index = 0;
                        }

                        else
                        {
                            Console.WriteLine(result);
                        }
                    }
                }
            }


        }

        public void PartiList_ConcCountry(string someCountry)
        {
            using (OlimpContext context = new OlimpContext())
            {
                //var parti_lists = from olimp in context.OlimpInfos join partilist in context.PartiLists on olimp.partiLists.
            }
        }

        public void CountryStats(string someOlimp)
        {
            using (OlimpContext context = new OlimpContext())
            {
                var countries = from olimp_infos in context.OlimpInfos
                                join city_country in context.CityCountries on olimp_infos.CityCountryId equals city_country.Id
                                join country in context.Countries on city_country.CountryId equals country.Id
                                where country.CountryName.Equals(someOlimp)
                                select country.CountryName;

                var scores = from olimp_infos in context.OlimpInfos
                             join city_country in context.CityCountries on olimp_infos.CityCountryId equals city_country.Id
                             join country in context.Countries on city_country.CountryId equals country.Id
                             join coun_scores in context.Results on olimp_infos.Id equals coun_scores.OlimpInfoId
                             where country.CountryName.Equals(someOlimp)
                             select coun_scores.Score;


                if (countries != null && scores != null)
                {
                    for (int i = 0, j = 0; i < countries.Count() && j < scores.Count(); i++, j++)
                    {
                        Console.WriteLine($"Country {countries} Score {scores}");
                    }
                }
            }
        }

        public void CountryStats()
        {
            using (OlimpContext context = new OlimpContext())
            {
                var countries = from olimp_infos in context.OlimpInfos
                                join city_country in context.CityCountries on olimp_infos.CityCountryId equals city_country.Id
                                join country in context.Countries on city_country.CountryId equals country.Id
                                select country.CountryName;

                var scores = from olimp_infos in context.OlimpInfos
                             join city_country in context.CityCountries on olimp_infos.CityCountryId equals city_country.Id
                             join country in context.Countries on city_country.CountryId equals country.Id
                             join coun_scores in context.Results on olimp_infos.Id equals coun_scores.OlimpInfoId
                             select coun_scores.Score;


                if (countries != null && scores != null)
                {
                    for (int i = 0, j = 0; i < countries.Count() && j < scores.Count(); i++, j++)
                    {
                        Console.WriteLine($"Country {countries} Score {scores}");
                    }
                }
            }
        }
    }
}
