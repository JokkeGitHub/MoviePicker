using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker
{
    class Movie
    {
        private string _name;
        private int _year;
        private string _description;
        private List<EnumGenre.Genre> _genres = new List<EnumGenre.Genre>();
        private List<Person> _actors = new List<Person>();
        private List<Person> _directors = new List<Person>();
        private List<Person> _writers = new List<Person>();

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public int Year
        {
            get
            {
                return this._year;
            }
            set
            {
                this._year = value;
            }
        }

        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }

        public List<EnumGenre.Genre> Genres
        {
            get
            {
                return this._genres;
            }
            set
            {
                this._genres = value;
            }
        }

        public List<Person> Actors
        {
            get
            {
                return this._actors;
            }
            set
            {
                this._actors = value;
            }
        }

        public List<Person> Directors
        {
            get
            {
                return this._directors;
            }
            set
            {
                this._directors = value;
            }
        }

        public List<Person> Writers
        {
            get
            {
                return this._writers;
            }
            set
            {
                this._writers = value;
            }
        }

        public Movie(string name)
        {
            Name = name;
        }
    }
}
