﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatvanyossagokApplication
{
    class latvanyossagok
    {
        int id;
        string nev;
        string leiras;
        int ar;
        int varos_id;

        public latvanyossagok(int id, string nev, string leiras, int ar, int varos_id)
        {
            this.id = id;
            this.nev = nev;
            this.leiras = leiras;
            this.ar = ar;
            this.varos_id = varos_id;
        }

        public int Id { get => id; }
        public string Nev { get => nev; set => nev = value; }
        public string Leiras { get => leiras; set => leiras = value; }
        public int Ar { get => ar; set => ar = value; }
        public int Varos_id { get => varos_id; set => varos_id = value; }

        public override string ToString()
        {
            string s = this.nev + " - ";
            if (this.ar == 0)
            {
                s += "Ingyenes";
            }
            else
            {
                s += this.ar + " Ft";
            }
            return s;
        }
    }
}
