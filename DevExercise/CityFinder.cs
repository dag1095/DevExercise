using System.Collections.ObjectModel;

namespace DevExercise
{
    public class CityFinder : ICityFinder
    {
        //psuedo database of cities
        //this is only here so unit tests have somewhere to input dummy data
        public Collection<string> Cities { get; set; }
        public CityFinder()
        {
            Cities = new Collection<string>();
        }

        /**
         * foreach city:
         *      if input is longer, skip to next city
         *      else, compare strings
         *          if input length < city length, add char from city string at input.Length to NextLetters
         *          else, add " "
         *          then add city string to NextCities
         */
        public ICityResult Search(string searchString)
        {
            CityResult cr = new CityResult();

            foreach (string city in Cities)
            {
                if (searchString.Length > city.Length) continue;  //skip if the length of the input string is longer than the city string
                else if(string.CompareOrdinal(searchString, city.Substring(0, searchString.Length)) == 0) //else ordinal comparison
                {
                    if(searchString.Length < city.Length) 
                        cr.NextLetters.Add(city[searchString.Length].ToString());
                    else
                        cr.NextLetters.Add(" ");
                    cr.NextCities.Add(city);
                }
            }
            
            return cr;
        }
    }
}
