using Tema1;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void adaugamInArena()
        {
            //arrange
            Arena arena = new Arena("nume");
            List<Luptator> luptatori = new List<Luptator>();

            Luptator luptator1 = new Barbarian("barbar");
            Luptator luptator2 = new Arcas("arcas");

            //act
            arena.AddLuptatori(luptator1);
            arena.AddLuptatori(luptator2);

            //assert
            Assert.Equal(2, arena.Luptatori.Count());
        }

        [Fact]
        public void adaugamInArenaExceptie()
        {
            //arrange
            Arena arena = new Arena("nume");
            List<Luptator> luptatori = new List<Luptator>();

            Luptator luptator1 = new Barbarian("barbar");
            Luptator luptator2 = new Arcas("arcas");
            Luptator luptator3 = new Magician("magician");

            //act
            //assert
            Assert.Throws<ArenaPlinaException>(() => {
                arena.AddLuptatori(luptator1);
                arena.AddLuptatori(luptator2);
                arena.AddLuptatori(luptator3);
            });
        }
    }
}