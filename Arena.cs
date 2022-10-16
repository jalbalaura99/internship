using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    internal class Arena
    {
        public Arena(string numeArena)
        {
            NumeArena = numeArena;
            Luptatori = new List<Luptator>();
        }
        public string NumeArena { get; set; }  

        public List<Luptator> Luptatori { get; }

        public void AddLuptatori(Luptator luptator)
        {
            if(this.Luptatori.Count == 2)
            {
                throw new ArenaPlinaException("Arena suporta maxim 2 luptatori");
            }

            this.Luptatori.Add(luptator);
        }

    }
}
