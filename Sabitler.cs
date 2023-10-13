using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1
{
    public class Sabitler
    {
        private String name;
        private String surName;
        private String number;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string SurName
        {
            get => surName;
            set => surName = value;
        }

        public string Number
        {
            get => number;
            set => number = value;
        }

        public Sabitler() { }
        public Sabitler(string name, string surName, string number)
        {
            this.Name = name;
            this.SurName = surName;
            this.Number = number;
        }
    }
}
