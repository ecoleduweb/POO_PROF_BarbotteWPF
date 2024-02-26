using System.Windows;

namespace WpfApp1;

/// <summary>
/// Un gros merci à Hélène CARON pour son UI!
/// </summary>
public partial class MainWindow : Window
{
    private Partie LaPartie;
    public MainWindow()
    {
        InitializeComponent();
        LaPartie = new Partie();
        LaPartie.AfficherInformation(this, 0, 0);
    }

    private void OnBtnBrasserClick(object sender, RoutedEventArgs e)
    {
        LaPartie.BrasserDe(this);
    }
}