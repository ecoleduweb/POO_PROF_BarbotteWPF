namespace WpfApp1;

public class Joueur
{
    private De[] Des;
    private bool AGagne;
    private bool APerdu;
    private int NbEssaie;
    private int NbARefaire;
    private int Score;

    public Joueur()
    {
        Des = [new De(), new De()];
        AGagne = false;
        APerdu = false;
    }

    public void CommencerNouvelleManche()
    {
        AGagne = false;
        APerdu = false;
        NbEssaie = 0;
        NbARefaire = 0;
    }

    public int[] Jouer()
    {
        int[] valeurs = [Des[0].BrasserDe(), Des[1].BrasserDe()];
        return valeurs;
    }

    public bool GetAGagne()
    {
        return AGagne;
    }

    public bool GetAPerdu()
    {
        return APerdu;
    }

    public int GetScore()
    {
        return Score;
    }

    public int GetNbARefaire()
    {
        return NbARefaire;
    }

    public int GetNbEssaie()
    {
        return NbEssaie;
    }

    public void SetNbARefaire(int nbARefaire)
    {
        NbARefaire = nbARefaire;
    }

    public void SetNbEssaie(int nbEssaie)
    {
        NbEssaie = nbEssaie;
    }

    public void SetScore(int score)
    {
        Score = score;
    }

    public void SetAGagne(bool aGagne)
    {
        AGagne = aGagne;
    }

    public void SetAPerdu(bool aPerdu)
    {
        APerdu = aPerdu;
    }
}
