using System;

namespace VendingMachine
{

    class Program
    {
        enum OptiuniUtilizator
        {
            VizualizaeazaProduse = 1

        }
        public static void ExecutaOptiuneAleasaAdmin(int optiuneAleasa, VendingMachine vendingMachine)
        {
            
            do

            {
                if (optiuneAleasa == (int)AdminActions.AdaugaProdus)
                {
                    Console.WriteLine("Introdu Id-ul produsul pe care doresti sa il adaugi");
                    int IdNou = int.Parse(Console.ReadLine());
                    Console.WriteLine("Introdu numele produsul pe care doresti sa il adaugi");
                    string NumeNou = Console.ReadLine();
                    Console.WriteLine("Introdu cantitatea produsul pe care doresti sa il adaugi");
                    int CantitateNou = int.Parse(Console.ReadLine());
                    Console.WriteLine("Introdu pretul produsul pe care doresti sa il adaugi");
                    double PretNou = int.Parse(Console.ReadLine());

                    Produs produsnou = new Produs(IdNou, NumeNou, CantitateNou, PretNou);
                    vendingMachine.AdaugaProduse(produsnou);

                    return;
                }
                if (optiuneAleasa == (int)AdminActions.StergeProdus)
                {
                    Console.WriteLine("Alege Id-ul produsului pe care doriti sa il stergeti ");
                    vendingMachine.StergeProduse(int.Parse(Console.ReadLine()));
                    return;
                }
                if (optiuneAleasa == (int)AdminActions.ModificaPretulProdus)
                {
                    vendingMachine.SchimbarePret();
                    return;
                }
                if (optiuneAleasa == (int)AdminActions.ModificaCantitateaProdus)
                {
                    Console.WriteLine("Alege Id-ul produsului caruia doriti sa ii modificati cantitatea ");
                    vendingMachine.ModificareCantitate(int.Parse(Console.ReadLine()));
                    return;
                }
            }
            while (optiuneAleasa != 5);
        }
        static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();

            Console.WriteLine("Alege una dintre urmatoarele optiuni:");
            Console.WriteLine("1.Vizualizeaza produse");
            Console.WriteLine("2.Cumpara produs");
            Console.WriteLine("3.Interfata admin");
            Console.WriteLine("4.Iesire");

            int selection = 0;

            do
            {
                try
                {
                    selection = int.Parse(Console.ReadLine());
                }
                catch { }
                if (selection == (int)UserActions.VizualizeazaProduse)
                {

                    vendingMachine.ShowProducts();
                }
                if (selection == (int)UserActions.CumparaProdus)
                {
                    vendingMachine.BuyProduct();
                }
                if (selection == (int)UserActions.InterfataAdmin)
                {
                    int pin = 1234;
                    Console.WriteLine("Te rog sa introduci pinul");
                    if (int.Parse(Console.ReadLine()) == pin)
                    {
                        int optiuneAleasa = vendingMachine.ShowAdminInterface();
                        ExecutaOptiuneAleasaAdmin(optiuneAleasa, vendingMachine );
                    }
                    else
                    {
                        Console.WriteLine("Pinul nu este corect!");
                    }
                }

            }
            while (selection != 4);
        }
    }

}

