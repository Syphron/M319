// Julian Odermatt, Ramon Wyss, S-INF-22dL

using projekt;  // verwendet den namespace projekt, woring die produkt- und Automatenklassen definiert sind


namespace TestProject1
{
    public class Tests { 
    
        public Automat _automat;  // deklariert eine variable vom Typ 'Automat'.

        // Vorbereitung für den Test
        [SetUp]
        public void Setup()
        {
            _automat = new Automat();

            // fügt produkte hinzu
            _automat.AddProdukt(new Snack(1, "Chips", 2.50m, "Zweifel"));
            _automat.AddProdukt(new Snack(2, "Waffel", 3.30m, "Werner"));
            _automat.AddProdukt(new Getraenk(3, "Cola", 1.50m, "Coca Cola"));
            _automat.AddProdukt(new Getraenk(4, "Redbull", 2.20m, "Redbull"));
            _automat.AddProdukt(new Getraenk(5, "Fanta", 1.50m, "Coca Cola"));
        }

        [Test]
        // testet ob ein produkt gültig ist und vorhanden ist
        public void GueltigesProdukt()
        {
            var produkt = _automat.WaehleProdukt(1);

            Assert.That(produkt, Is.Not.Null);
            Assert.That(produkt.Name, Is.EqualTo("Chips"));
        }

        [Test]
        // Testet ob die Abfrage von einem nicht vorhandenen Produkt null zurückgibt
        public void GueltigeNummern()
        {
            var produkt = _automat.WaehleProdukt(99);

            Assert.That(produkt, Is.Null);
        }
    }
}


