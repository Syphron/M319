// Julian Odermatt, Ramon Wyss, S_INF_22dL

namespace projekt
{

    using System;
    using System.Collections.Generic;

    // interface definieren
    public interface IProdukt
    {
        int Nummer { get; }
        string Name { get; }
        decimal Preis { get; }
        string Hersteller { get; }
    }

    // abstrake Klasse für die Produkte
    public abstract class Produkt : IProdukt
    {
        public int Nummer { get; protected set; }
        public string Name { get; protected set; }
        public decimal Preis { get; protected set; }
        public string Hersteller { get; protected set; }

        protected Produkt(int nummer, string name, decimal preis, string hersteller)
        {
            Nummer = nummer;
            Name = name;
            Preis = preis;
            Hersteller = hersteller;
        }
    }

     // implementierung von dem Produkt für die Snacks
    public class Snack : Produkt
    {
        public Snack(int nummer, string name, decimal preis, string hersteller) : base(nummer, name, preis, hersteller) { }
    }

    // implementierung von dem Produkt für die Snacks
    public class Getraenk : Produkt
    {
        public Getraenk(int nummer, string name, decimal preis, string hersteller) : base(nummer, name, preis, hersteller) { }
    }

    // klasse für den Autoaten, der die Produkte speichert und verwaltet
    public class Automat
    {
        List<IProdukt> produktListe = new List<IProdukt>();
        IProdukt[] produkteArray;

        // fügt ein produkt zum automaten hinzu
        public void AddProdukt(IProdukt produkt)
        {
            produktListe.Add(produkt);
            produkteArray = produktListe.ToArray();
        }

        // wählt ein Produkt anhand seiner Nummer aus
        public IProdukt WaehleProdukt(int nummer)
        {

            foreach (var produkt in produkteArray)
            {
                if (produkt.Nummer == nummer)
                {
                    return produkt;
                }
            }
            return null;
        }

        // Berechnung des Rückgeldes
        public decimal Zahle(decimal betrag, decimal preis)
        {
            return betrag - preis;
        }
    }


    class Program
    {
        static void Main()
        {
            Automat automat = new Automat();

            // initialisiert den Automaten mit verschiedenen Produkten
            automat.AddProdukt(new Snack(1, "Chips", 2.50m, "Zweifel"));
            automat.AddProdukt(new Snack(2, "Waffel", 3.30m, "Werner"));
            automat.AddProdukt(new Getraenk(3, "Cola", 1.50m, "Coca Cola"));
            automat.AddProdukt(new Getraenk(4, "Redbull", 2.20m, "Redbull"));
            automat.AddProdukt(new Getraenk(5, "Fanta", 1.50m, "Coca Cola"));

            
            // Eingabebeaufforderung um ein Produkt auszuwählen
            Console.WriteLine("Waehlen Sie ein Produkt durch Eingabe der Nummer:");
            int nummer = Convert.ToInt32(Console.ReadLine());
            IProdukt produkt = automat.WaehleProdukt(nummer);

            // überprüfung ob ein Produkt vorhanden ist oder nicht
            if (produkt == null)
            {
                Console.WriteLine("Dieses Produkt gibt es nicht.");
            }
            else
            {
                decimal bezahlt = 0m;
                // schleife welche solange ausgeführt wird bis der Betrag bezahlt wurde
                while (bezahlt < produkt.Preis)
                {
                    Console.WriteLine($"Bitte zahlen Sie {produkt.Preis - bezahlt:C}.");
                    bezahlt += Convert.ToDecimal(Console.ReadLine());
                }
                // berechnet das Rückgeld und gibt es aus
                decimal rückgeld = automat.Zahle(bezahlt, produkt.Preis);
                Console.WriteLine($"Produkt ausgeworfen. Rueckgeld: {rückgeld:C}");
            }
        }
    }

}
