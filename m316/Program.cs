


namespace projekt
{

    using System;
    using System.Collections.Generic;

    public interface IProdukt
    {
        int Nummer { get; }
        string Name { get; }
        decimal Preis { get; }
    }

    public abstract class Produkt : IProdukt
    {
        public int Nummer { get; protected set; }
        public string Name { get; protected set; }
        public decimal Preis { get; protected set; }

        protected Produkt(int nummer, string name, decimal preis)
        {
            Nummer = nummer;
            Name = name;
            Preis = preis;
        }
    }

    public class Snack : Produkt
    {
        public Snack(int nummer, string name, decimal preis) : base(nummer, name, preis) { }
    }

    public class Getränk : Produkt
    {
        public Getränk(int nummer, string name, decimal preis) : base(nummer, name, preis) { }
    }

    public class Automat
    {
        List<IProdukt> produktListe = new List<IProdukt>();
        IProdukt[] produkteArray;

        public void AddProdukt(IProdukt produkt)
        {
            produktListe.Add(produkt);
            produkteArray = produktListe.ToArray();
        }

        public IProdukt WähleProdukt(int nummer)
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
            automat.AddProdukt(new Snack(1, "Chips", 2.50m));
            automat.AddProdukt(new Getränk(2, "Cola", 1.50m));

            Console.WriteLine("Wählen Sie ein Produkt durch Eingabe der Nummer:");
            int nummer = Convert.ToInt32(Console.ReadLine());
            IProdukt produkt = automat.WähleProdukt(nummer);

            if (produkt == null)
            {
                Console.WriteLine("Dieses Produkt gibt es nicht.");
            }
            else
            {
                decimal bezahlt = 0m;
                while (bezahlt < produkt.Preis)
                {
                    Console.WriteLine($"Bitte zahlen Sie {produkt.Preis - bezahlt:C}.");
                    bezahlt += Convert.ToDecimal(Console.ReadLine());
                }

                decimal rückgeld = automat.Zahle(bezahlt, produkt.Preis);
                Console.WriteLine($"Produkt ausgeworfen. Rückgeld: {rückgeld:C}");
            }
        }
    }

}
