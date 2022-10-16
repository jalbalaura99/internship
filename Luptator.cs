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
    }
}
