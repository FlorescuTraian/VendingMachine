using System;
using System.Collections.Generic;


namespace VendingMachine
{
    class VendingMachine
    {

        public List<Produs> produse = new List<Produs>();
        public VendingMachine()
        {
            Produs produs1 = new Produs(20, "Cola", 6, 4.00);
            Produs produs2 = new Produs(21, "Apa", 6, 3.50);
            Produs produs3 = new Produs(22, "Sandwich", 6, 6.00);
            Produs produs4 = new Produs(23, "Twix", 6, 2.50);

            produse.Add(produs1);
            produse.Add(produs2);
            produse.Add(produs3);
            produse.Add(produs4);
        }

        public void ShowProducts()
        {
            foreach (Produs produs in produse)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"ID produs:{produs.Id}");
                Console.WriteLine($"{produs.Nume}");
                Console.WriteLine($"Bucati ramase: {produs.Cantitate}");
                Console.WriteLine($"Pret: {produs.Pret} lei");

            }
        }
        public void BuyProduct()
        {
            Console.WriteLine("Ce produs doriti sa cumparati?");
            int idprodcumparat = int.Parse(Console.ReadLine());
            bool gasit = false;
            foreach (Produs produs in produse)
            {
                if (idprodcumparat == produs.Id)
                {
                    gasit = true;

                    bool poateFiCumparat = CanBuyProduct(produs);

                    if (poateFiCumparat)
                    {
                        Console.WriteLine($"Produsul cu ID-ul {idprodcumparat} costa {produs.Pret} lei, te rog sa introduci bani");
                        PayingCheck(double.Parse(Console.ReadLine()), produs);
                    }
                }
            }
            if (gasit == false)
            {
                Console.WriteLine("Produsul nu exista");
            }

        }
        private bool CanBuyProduct(Produs product)
        {
            if (product.Cantitate > 0) return true;
            return false;
        }

        public void PayingCheck(double baniinserati, Produs product)
        {
            if (product.Pret > baniinserati)
            {
                Console.WriteLine($"Nu aveti suficienti bani. La revedere!");
                return;
            }
            if (baniinserati >= product.Pret)
            {
                Console.WriteLine($"Va rog sa va ridicati produsul. Va multumim, o zi frumoasa!");
                ScadeCantitate(product.Id);

                if (baniinserati - product.Pret > 0)
                {
                    Console.WriteLine($"Restul dumneavoastra este de {baniinserati - product.Pret}");
                }
            }
        }

        public int ShowAdminInterface()
        {
            Console.WriteLine("Bine ai venit!");
            Console.WriteLine("Alege una dintre urmatoarele optiuni:");
            Console.WriteLine("1.Adauga produs nou");
            Console.WriteLine("2.Sterge produs");
            Console.WriteLine("3.Modifica pretul unui produs");
            Console.WriteLine("4.Modifica cantitatea unui produs");
            Console.WriteLine("5.Iesire");

            int selection = int.Parse(Console.ReadLine());

            return selection;

        }

        public void SchimbarePret()
        {
            Console.WriteLine("Introduce ID-ul produsul pentru care doresti sa schimbi pretul");
            int Id = int.Parse(Console.ReadLine());
            foreach (Produs produs in produse)
            {
                if (Id == produs.Id)
                {
                    Console.WriteLine("Te rog sa introduci pretul");
                    produs.Pret = double.Parse(Console.ReadLine());
                    return;
                }
                Console.WriteLine("Produsul nu exista");
            }
        }

        public void AdaugaProduse(Produs product)
        {
            produse.Add(product);
        }

        public void StergeProduse(int idProdusSters)
        {
            Produs produsDeSters = null;
            foreach (Produs produs in produse)
            {
                if (idProdusSters == produs.Id)
                {
                    produsDeSters = produs;
                }

            }
            if (produsDeSters != null)
            {
                produse.Remove(produsDeSters);
            }
        }

        public void ModificareCantitate(int idProdusCantMod)
        {
            Console.WriteLine($"Ce cantitate doriti sa adaugati produsului cu Id-ul {idProdusCantMod} ");
            int cantitateModificata = int.Parse(Console.ReadLine());

            foreach (Produs produs in produse)
            {
                if (idProdusCantMod == produs.Id)
                {
                    produs.Cantitate = cantitateModificata;

                }
            }
        }
        public void ScadeCantitate(int idProdusCantitateScazuta)
        {
            foreach (Produs produs in produse)
            {
                if (idProdusCantitateScazuta == produs.Id)
                {
                    produs.Cantitate--;

                }
            }
        }
        
    }
}