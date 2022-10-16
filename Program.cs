using System;

namespace Tema1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Arena arena = new Arena("Arena1");  
            Luptator luptator1 = new Barbarian("Barbarian");
            Luptator luptator2 = new Arcas("Arcas");
            Luptator luptator3 = new Magician("Magician");

            try
            {
                arena.AddLuptatori(luptator1);
                arena.AddLuptatori(luptator2);
                arena.AddLuptatori(luptator3);
            }
            catch (ArenaPlinaException ex)
            {
                Console.WriteLine(ex.Message + "\n\n");  
            }



            Console.WriteLine($"Incepe lupta dintre {luptator1.Nume} si {luptator2.Nume}");

            Random rand = new Random();
            while (luptator1.Viata > 0 && luptator2.Viata > 0)
            {
                if (rand.Next(2) == 0)
                {
                    SimuleazaAtac(luptator1, luptator2);
                }
                else
                {
                    SimuleazaAtac(luptator2 , luptator1);
                }
            }

            if (luptator1.Viata == 0)
            {
                Console.WriteLine($"{luptator2.Nume} a castigat batalia!");
            }
            else
            {
                Console.WriteLine($"{luptator1.Nume} a castigat batalia!");
            }
        }

        public static void SimuleazaAtac(Luptator luptatorAtac, Luptator luptatorApara)
        {
            Console.WriteLine($"Luptatorul care ataca este {luptatorAtac.Nume}");
            Console.WriteLine("Alegeti lovitura pe care doriti sa o executati:");
            PrintareLovituri(luptatorAtac);

            int lovitura = Int32.Parse(Console.ReadLine());
            switch (lovitura)
            {
                case 1:
                    Console.WriteLine($"Luptatorul {luptatorAtac.Nume} ataca cu pumnul");
                    Loveste(TipAtac.Pumn, luptatorAtac, luptatorApara);
                    break;
                case 2:
                    Console.WriteLine($"Luptatorul {luptatorAtac.Nume} ataca cu piciorul");
                    Loveste(TipAtac.Picior, luptatorAtac, luptatorApara);
                    break;
                case 3:
                    if (luptatorAtac.NivelSpeciala != 2)
                    {
                        throw new SpecialaNepregatitaException("Comanda invalida!");
                    }
                    Console.WriteLine($"Luptatorul {luptatorAtac.Nume} ataca cu lovitura speciala");
                    Loveste(TipAtac.AtacSpecial, luptatorAtac, luptatorApara);
                    luptatorAtac.NivelSpeciala = 0;
                    break;

            }
        }

        static void Loveste(TipAtac tipAtac, Luptator luptatorAtaca, Luptator luptatorApara)
        {
            Random random = new Random();
            if (random.Next(2) == 1)
            {
                Console.WriteLine($"Lovitura {tipAtac} efectuata de {luptatorAtaca.Nume} a fost efectuata cu success!");
                luptatorApara.Viata -= (int)tipAtac;
                luptatorAtaca.NivelSpeciala++;
            }
            else
            {
                Console.WriteLine($"Luptatorul {luptatorApara.Nume} a reusit sa apere lovitura!");
            }

        }

        static void PrintareLovituri(Luptator luptator)
        {
            Console.WriteLine("1. Pumn");
            Console.WriteLine("2. Picior");

            if (luptator.NivelSpeciala == 2)
            {
                Console.WriteLine("3. Lovitura Speciala");
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Am prins exceptia in global handler");
        }
    }
}
