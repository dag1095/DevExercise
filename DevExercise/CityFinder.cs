using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DevExercise
{
    public class CityFinder : ICityFinder
    {
        //psuedo database of cities
        //this is only here so unit tests have somewhere to input dummy data
        public HashSet<string> Cities { get; set; }
        public CityFinder()
        {
            Cities = new HashSet<string>();
        }

        /**
         * foreach city:
         *      if input is longer, skip to next city
         *      else, compare strings
         *          if input length < city length, add char from city string at input.Length to NextLetters
         *          then add city string to NextCities
         */
        public ICityResult Search(string searchString)
        {
            CityResult cr = new CityResult();

            foreach (string city in Cities)
            {
                if (searchString.Length > city.Length) continue;
                else if(string.CompareOrdinal(searchString, city.Substring(0, searchString.Length)) == 0)
                {
                    
                    if (searchString.Length < city.Length)
                    {
                        cr.NextLetters.Add(city[searchString.Length].ToString());
                    }
                    cr.NextCities.Add(city);
                }
            }

            return cr;
        }
    }
}
