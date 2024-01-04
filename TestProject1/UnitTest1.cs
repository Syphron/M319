using projekt;

namespace TestProject1
{
    public class Tests
    {
        public Automat _automat;

        [SetUp]
        public void Setup()
        {
            _automat = new Automat();
            _automat.AddProdukt(new Snack(1, "Chips", 2.50m));
            _automat.AddProdukt(new Getr�nk(2, "Cola", 1.50m));
        }

        [Test]
        public void Test1()
        {
            var produkt = _automat.W�hleProdukt(1);

            Assert.That(produkt, Is.Not.Null);
            Assert.That(produkt.Name, Is.EqualTo("Chips"));
        }

        [Test]
        public void G�ltigeNummern()
        {
            var produkt = _automat.W�hleProdukt(99);

            Assert.That(produkt, Is.Null);
        }
    }
}


