using System.Windows;

namespace WpfApp1;

internal class Partie
{
    private int IndexJoueurActif;
    private Joueur[] Joueurs;
    public Partie()
    {
        // Je crée les deux joueurs directement dans un tableau
        Joueurs = [new Joueur(), new Joueur()];
    }

    /// <summary>
    /// Permet de mettre à jour toute l'interface du jeu.
    /// Cette méthode est appelée à chaque fois qu'on brasse les dés.
    /// Ce n'est pas grave si on raffraîchit des éléments qui n'ont pas été modifiés.
    /// </summary>
    public void AfficherInformation(MainWindow window, int de1, int de2)
    {
        window.TbJoueurActif.Text = $"Joueur {IndexJoueurActif + 1}";
        window.TbDe1.Text = de1.ToString();
        window.TbDe2.Text = de2.ToString();
        window.TbTotal.Text = (de2+de1).ToString();
        window.TbNbARefaire.Text = Joueurs[IndexJoueurActif].GetNbARefaire().ToString();
        window.TbNbLances.Text = Joueurs[IndexJoueurActif].GetNbEssaie().ToString();
        window.TbScore.Text = $"Joueur 1 : {Joueurs[0].GetScore()} |  Joueur 2 : {Joueurs[1].GetScore()}";
    }

    /// <summary>
    /// Permet de recommencer une nouvelle partie.
    /// On va remettre IndexJoueurActif à 0.
    /// On va créer un nouvel objet parti et l'attribuer à l'attribu Partie.
    /// </summary>
    public void NouvellePartie()
    {
        Joueurs = [new Joueur(), new Joueur()];
    }

    /// <summary>
    /// Cette méthode permet de changer la valeur de IndexJoueurActif.
    /// Si l'index est 0, alors IndexJoueurActif devient 1.
    /// Si l'index est 1, alors IndexJoueurActif devient 0.
    /// </summary>
    public void ProchainJoueur()
    {
        if (IndexJoueurActif == 0)
        {
            IndexJoueurActif++;
        }
        else
        {
            IndexJoueurActif--;
        }
    }

    /// <summary>
    /// Cette méthode est toujours appelée à la fin de BrasserDe.
    /// Tu dois donc t'assurer que les deux joueurs ont terminé de joué pour accorder des points à l'un de ceux-ci.
    /// Si les joueur ont joué, la méthode valide si ajoute un point au joueur qui a gagné quand l'autre joueur a perdu.
    /// Si deux joueurs gagnent, aucun point n'est accordé, c'est partie nulle.
    /// On va aussi valider ici si un des deux joueurs a un score de 2. Cela implique que le joueur est le grand gagnant de la partie!!
    /// </summary>
    public void DéclarerGagnant()
    {
        if (Joueurs[0].GetAGagne() && Joueurs[1].GetAPerdu())
        {
            Joueurs[0].SetScore(Joueurs[0].GetScore() + 1);
            Joueurs[0].CommencerNouvelleManche();
            Joueurs[1].CommencerNouvelleManche();
            MessageBox.Show("Joueur 1 a gagngé la manche!");
        }
        else if (Joueurs[1].GetAGagne() && Joueurs[0].GetAPerdu())
        {
            Joueurs[1].SetScore(Joueurs[1].GetScore() + 1);
            Joueurs[0].CommencerNouvelleManche();
            Joueurs[1].CommencerNouvelleManche();
            MessageBox.Show("Joueur 2 a gagngé la manche!");
        }
        else if (Joueurs[1].GetAGagne() && Joueurs[0].GetAGagne() || Joueurs[1].GetAPerdu() && Joueurs[0].GetAPerdu())
        {
            Joueurs[0].CommencerNouvelleManche();
            Joueurs[1].CommencerNouvelleManche();
            MessageBox.Show("Manche nulle!");
        }

        if (Joueurs[0].GetScore() == 2)
        {
            MessageBox.Show("Joueur 1 a gagngé!");
        }
        else if (Joueurs[1].GetScore() == 2)
        {
            MessageBox.Show("Joueur 2 a gagngé!");
        }
    }

    /// <summary>
    /// Cette méthode gère toute la logique du jeu. Tu vas donc y retrouver ton code de la Barbotte que tu avais en WinForm et l'adapter.
    /// Tu vas avoir besoin de créer des méthodes Set sur tes classes (comme SetNombreARefaire) pour assigner des valeurs à tes joueurs.
    /// C'est donc ici que tu appelles joueur.Jouer()!
    /// Tu dois aussi valider si c'est au prochain joueur de jouer (quand le joueur qui joue a terminé sa ronde).
    /// Un joueur a terminé de jouer lorsqu'il a perdu ou gagner une ronde.
    /// Tu devrais déduire ici que tu vas avoir besoin des méthodes SetAPerdu, GetAPerdu, SetAGagne, GetAGagne dans ta classe joueur.
    /// </summary>
    /// <param name="window">La fenêtre qui contient les éléments à afficher</param>
    public void BrasserDe(MainWindow window)
    {
        Joueur joueurActif = Joueurs[IndexJoueurActif];
        int[] valeursBrassees = joueurActif.Jouer();
        int de1 = valeursBrassees[0];
        int de2 = valeursBrassees[1];
        int total = de1 + de2;

        if (joueurActif.GetNbEssaie() == 0)
        {
            joueurActif.SetNbARefaire(total);
            if (total == 2 || total == 3 || total == 12)
            {
                joueurActif.SetAPerdu(true);
                ProchainJoueur();
            }
            else if (total == 7 || total == 11)
            {
                joueurActif.SetAGagne(true);
                ProchainJoueur();
            }
        }
        else
        {
            if (joueurActif.GetNbARefaire() == total)
            {
                joueurActif.SetAGagne(true);
                ProchainJoueur();
            }
            else if (total == 7)
            {
                joueurActif.SetAPerdu(true);
                ProchainJoueur();
            }
        }

        joueurActif.SetNbEssaie(joueurActif.GetNbEssaie() + 1);
        DéclarerGagnant();
        AfficherInformation(window, de1, de2);
    }
}
