namespace VendingMachine
{
    class Produs
    {
        public int Id { get; private set; }
        public string Nume { get; set; }
        public int Cantitate { get; set; }
        public double Pret { get; set; }

        public Produs(int id, string nume, int cantitate, double pret)
        {
            this.Id = id;
            this.Nume = nume;
            this.Cantitate = cantitate;
            this.Pret = pret;

        }

    }
}
