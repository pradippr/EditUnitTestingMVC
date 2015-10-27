using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleToneDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
               
            GlobalSingleton st = GlobalSingleton.Instance;
            IEnumerable<string> contries = st.Countries.getCounties();
            
            Console.ReadLine();
        }
    }
    public sealed class GlobalSingleton
    {
        // object which needs to be shared globally
        public Currency Currencies = new Currency();
        public Country Countries = new Country();

        // use static variable to create a single instance of the object
        static readonly GlobalSingleton INSTANCE = new GlobalSingleton();

        /// This is a private constructor, meaning no outsides have access.
        private GlobalSingleton()
        { }

        public static GlobalSingleton Instance
        {
            get
            {

                return INSTANCE;
            }
        }
    }


    public class Currency
    {
        List<string> oCurrencies = new List<string>();
        public Currency()
        {
            oCurrencies.Add("INR");
            oCurrencies.Add("USD");
            oCurrencies.Add("NEP");
            oCurrencies.Add("GBP");

        }
        public IEnumerable<string> getCurrencies()
        {
            return (IEnumerable<string>)oCurrencies;
        }
    }

    public class Country
    {
        List<string> oCountries = new List<string>();
        public Country()
        {
            oCountries.Add("India");
            oCountries.Add("Nepal");
            oCountries.Add("USA");
            oCountries.Add("UK");

        }
        public IEnumerable<string> getCounties()
        {
            return (IEnumerable<string>)oCountries;
        }
    }
}
