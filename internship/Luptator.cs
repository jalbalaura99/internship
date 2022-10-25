using System;

namespace Tema1
{
    public class Luptator
    {
        public int Viata { get; set; }

        public string Nume { get; set; }

        public int NivelSpeciala { get; set; }

        public Luptator(string nume)
        {
            this.Nume = nume;
            this.Viata = 100;
            this.NivelSpeciala = 0;
        }

        public void Loveste(TipAtac tipAtac, Luptator luptatorApara)
        {
            Random random = new Random();
            if (random.Next(2) == 1)
            {
                Console.WriteLine($"Lovitura {tipAtac} efectuata de {this.Nume} a fost efectuata cu success!");
                luptatorApara.Viata -= (int)tipAtac;
                this.NivelSpeciala++;
            }
            else
            {
                Console.WriteLine($"Luptatorul {luptatorApara.Nume} a reusit sa apere lovitura!");
            }
        }
    }
}
