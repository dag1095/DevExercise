using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DevExercise.Test
{
    [TestClass]
    public class CitiesAndLetters
    {
        [TestMethod]
        public void BANG()
        {
            HashSet<string> cities = new HashSet<string>();
            cities.Add("BANDUNG");
            cities.Add("BANGUI");
            cities.Add("BANGKOK");
            cities.Add("BANGALORE");

            CityFinder cf = new CityFinder();
            cf.Cities = cities;
            
            CityResult cr = (CityResult) cf.Search("BANG");

            Assert.IsTrue(cr.NextLetters.Count == 3);
            Assert.IsTrue(cr.NextLetters.Contains("U"));
            Assert.IsTrue(cr.NextLetters.Contains("K"));
            Assert.IsTrue(cr.NextLetters.Contains("A"));

            Assert.IsTrue(cr.NextCities.Count == 3);
            Assert.IsTrue(cr.NextCities.Contains("BANGUI"));
            Assert.IsTrue(cr.NextCities.Contains("BANGKOK"));
            Assert.IsTrue(cr.NextCities.Contains("BANGALORE"));
        }

        [TestMethod]
        public void LA()
        {
            HashSet<string> cities = new HashSet<string>();
            cities.Add("LA PAZ");
            cities.Add("LA PLATA");
            cities.Add("LAGOS");
            cities.Add("LEEDS");

            CityFinder cf = new CityFinder();
            cf.Cities = cities;

            CityResult cr = (CityResult)cf.Search("LA");

            Assert.IsTrue(cr.NextLetters.Count == 2); 
            Assert.IsTrue(cr.NextLetters.Contains(" "));
            Assert.IsTrue(cr.NextLetters.Contains("G"));

            Assert.IsTrue(cr.NextCities.Count == 3);
            Assert.IsTrue(cr.NextCities.Contains("LA PAZ"));
            Assert.IsTrue(cr.NextCities.Contains("LA PLATA"));
            Assert.IsTrue(cr.NextCities.Contains("LAGOS"));
        }

        [TestMethod]
        public void ZE()
        {
            HashSet<string> cities = new HashSet<string>();
            cities.Add("ZARIA");
            cities.Add("ZHUGHAI");
            cities.Add("ZIBO");

            CityFinder cf = new CityFinder();
            cf.Cities = cities;

            CityResult cr = (CityResult)cf.Search("ZE");

            Assert.IsTrue(cr.NextLetters.Count == 0);

            Assert.IsTrue(cr.NextCities.Count == 0);
        }

        [TestMethod]
        public void LEEDS()
        {
            HashSet<string> cities = new HashSet<string>();
            cities.Add("ZARIA");
            cities.Add("ZHUGHAI");
            cities.Add("ZIBO");
            cities.Add("LA PAZ");
            cities.Add("LA PLATA");
            cities.Add("LAGOS");
            cities.Add("LEEDS");
            cities.Add("BANDUNG");
            cities.Add("BANGUI");
            cities.Add("BANGKOK");
            cities.Add("BANGALORE");

            CityFinder cf = new CityFinder();
            cf.Cities = cities;

            CityResult cr = (CityResult)cf.Search("LEEDS");

            Assert.IsTrue(cr.NextLetters.Count == 0);

            Assert.IsTrue(cr.NextCities.Count == 1);
            Assert.IsTrue(cr.NextCities.Contains("LEEDS"));
        }

        [TestMethod]
        public void VaryingStringSizes()
        {
            HashSet<string> cities = new HashSet<string>();
            string longestName = "Taumatawhakatangihangakoauauotamateaturipukakapikimaungahoronukupokaiwhenuakitanatahu"; //85 characters
            longestName = longestName.ToUpper();
            for (int i = 0; i < longestName.Length; i++)
            {
                cities.Add(longestName.Substring(0, i)); //chop the string up and add it
            }

            CityFinder cf = new CityFinder();
            cf.Cities = cities;

            string search = longestName.Substring(0, 42);  //search with a substring half the size of the longest, so half
            CityResult cr = (CityResult)cf.Search(search); //of the collection gets thrown away and the other half into NextCities

            Assert.IsTrue(cr.NextLetters.Count == 1);
            Assert.IsTrue(cr.NextLetters.Contains(longestName[search.Length].ToString()));
            
            Assert.IsTrue(cr.NextCities.Count == longestName.Length - search.Length);
            for (int i = search.Length; i < longestName.Length; i++)
            {
                Assert.IsTrue(cr.NextCities.Contains(longestName.Substring(0, i)));
            } //should contain substrings of longestName from string lengths of search.Length, search.Length + 1, . . ., longestName.Length size
        }
    }
}
