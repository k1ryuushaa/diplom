using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtRoyalDetailing.Domain.Dictionaries
{
    public class DictionaryCarClass
    {
        public readonly Dictionary<int, string> carClasses = new Dictionary<int, string>()
        {
            {1,"Класс А"},
            {2,"Класс B, C, D"},
            {3,"Кроссовер/Универсал/Класс E,F"},
            {4,"Внедорожник"},
            {5,"Минивэн"},
        };
        public string[] GetClasses()
        {
            return carClasses.Values.ToList().ToArray();
        }
    }
}
