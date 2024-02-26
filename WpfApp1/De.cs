namespace WpfApp1;

public class De
{
    Random Aleatoire;

    public De()
    {
        Aleatoire = new Random();
    }

    public int BrasserDe()
    {
        int valeurBrassee = Aleatoire.Next(1, 7);
        return valeurBrassee;
        // ou return Aleatoire.Next(1, 7);
    }
}
