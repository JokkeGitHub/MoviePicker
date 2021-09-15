using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker
{
    class EnumGenre
    {
        public enum Genre
        {
            Action,
            Adventure,
            Alien,
            AlternateReality,
            Animation,
            Apocalypse,
            ChickFlick,
            Comedy,
            Crime,
            Disaster,
            Documentary,
            Drama,
            Dystopian,
            Fantasy,
            Gangster,
            Historical,
            Horror,
            MartialArts,
            MindBending,
            Musical,
            Mystery,
            Mythologi,
            Occult,
            Paranormal,
            Philosophical,
            Psychological,
            Religious,
            Robot,
            Romance,
            ScienceFiction,
            Superhero,
            Surreal,
            Tearjerker,
            Technology,
            Thriller,
            TimeTravel,
            Vampire,
            War,
            Werewolf,
            Western,
            Zombie
        }

        public void Test()
        {
            foreach (var suit in Enum.GetValues(typeof(Genre)))
            {
                System.Console.WriteLine(suit.ToString());
            }
        }
    }
}
