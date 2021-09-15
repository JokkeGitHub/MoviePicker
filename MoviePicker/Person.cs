using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker
{
    class Person
    {
        private string _name;
        private EnumTitle.Title _title;

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

        public EnumTitle.Title Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }

        public Person(string name, EnumTitle.Title title)
        {
            Name = name;
            Title = title;
        }
    }
}
