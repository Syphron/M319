using NUnit;
using NUnit.Framework;
using projekt;

namespace TestProjekt
{
    [TestFixture]
    public class AutomatTests
    {
        public Automat _automat;

        [SetUp]
        public void Setup()
        {
            _automat = new Automat();
            _automat.AddProdukt(new Snack(1, "Chips", 2.50m));
            _automat.AddProdukt(new Getränk(2, "Cola", 1.50m));
        }

        [Test]
        public void WähleProdukt_MitGültigerNummer_SollteProduktZurückgeben()
        {
            var produkt = _automat.WähleProdukt(1);

            Assert.That(produkt, Is.Null);
            Assert.That(produkt.Name, Is.EqualTo("Chips"));
        }

        [Test]
        public void WähleProdukt_MitUngültigerNummer_SollteNullZurückgeben()
        {
            var produkt = _automat.WähleProdukt(99);

            Assert.That(produkt, Is.Null);
        }
    }
}
