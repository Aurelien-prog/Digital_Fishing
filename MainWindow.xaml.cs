using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Digital_Fishing
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Création de 3 collections pour stocker les objets
        List<Contrat> cContrat = new List<Contrat>();
        List<Magazine> cMagazine = new List<Magazine>();
        List<Pigiste> cPigiste = new List<Pigiste>();
        public MainWindow()
        {
            InitializeComponent();
            // Ajout d'objets temporaires pour tester l'application
            Pigiste P1 = new Pigiste(1, "Duff", "John", "Rue des alouettes", "75000", "Alfortville", "johnd@mail.com", "010969000000", "1m2p-cc-01");
            Pigiste P2 = new Pigiste(2, "Ligili", "Guy", "Avenue des Colibirs", "95000", "Cergy", "guyl@mail.com", "011069000000", "1m2p-cc-02");
            Pigiste P3 = new Pigiste(3, "Terieur", "Alex", "Boulevard des goelands", "Saint Denis", "Alfortville", "alext@mail.com", "011169000000", "1m2p-cc-03");

            Magazine M1 = new Magazine(1, "01/05/2019", "01/06/2019", "01/07/2019", 3100);
            Magazine M2 = new Magazine(2, "01/07/2019", "01/08/2019", "01/09/2019", 3200);
            Magazine M3 = new Magazine(3, "01/09/2019", "01/10/2019", "01/11/2019", 3300);

            // Exemple d'appel du deuxième constructeur pour génération automatique de la lettre accord pour C0, autre constructeur pour les autres
            Contrat C0 = new Contrat(0, "1m2p-la-0-0", 160, 144, false, false, 0, P1, M1);
            Contrat C1 = new Contrat(1, 320, 288, false, false, 0, P1, M2);
            Contrat C2 = new Contrat(2, 480, 448, false, false, 0, P1, M3);
            Contrat C3 = new Contrat(3, 320, 288, false, false, 0, P2, M1);
            Contrat C4 = new Contrat(4, 160, 144, false, false, 0, P2, M2);
            Contrat C5 = new Contrat(5, 320, 288, false, false, 0, P3, M2);
            Contrat C6 = new Contrat(6, 480, 448, false, false, 0, P3, M3);

            // Remplissage des collections avec les objets
            cContrat.Add(C0);
            cContrat.Add(C1);
            cContrat.Add(C2);
            cContrat.Add(C3);
            cContrat.Add(C4);
            cContrat.Add(C5);
            cContrat.Add(C6);

            cMagazine.Add(M1);
            cMagazine.Add(M2);
            cMagazine.Add(M3);

            cPigiste.Add(P1);
            cPigiste.Add(P2);
            cPigiste.Add(P3);

            // Binding des datagrids avec les collections
            dtgContrat.ItemsSource = cContrat;
            dtgMagazine.ItemsSource = cMagazine;
            dtgPigiste.ItemsSource = cPigiste;

            // Lie les 2 comboboxs de l'onglet contrat avec les collections cPigiste et cMagazine
            cboPigiste.ItemsSource = cPigiste;
            cboMagazine.ItemsSource = cMagazine;
        }

        private void dtgContrat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // On récupère l'objet selectionné dans le datagrid et on le "cast" pour lui donner un type précis (Contrat, Magazine, Pigiste)
            Contrat contratSelected = (Contrat)dtgContrat.SelectedItem;

            // On met des valeurs dans les composants de l'interface via les valeurs de l'objet contratSelected
            txtNumContrat.Text = Convert.ToString(contratSelected.NumContrat);
            txtLettreAccordContrat.Text = Convert.ToString(contratSelected.LettreAccordContrat);
            txtMontantBrutContrat.Text = Convert.ToString(contratSelected.MontantBrutContrat);
            txtMontantNetContrat.Text = Convert.ToString(contratSelected.MontantNetContrat);

            // Selectionne l'index du Combobox cboEtatContrat
            cboEtatContrat.SelectedIndex = contratSelected.EtatContrat;


            // Coche et décoche des 2 cases à cocher chkFacture et chkAgessa
            if (contratSelected.FactureContrat == true)
            { chkFacture.IsChecked = true; }
            else
            { chkFacture.IsChecked = false; }

            if (contratSelected.DeclarationAgessaContrat == true)
            { chkAgessa.IsChecked = true; }
            else
            { chkAgessa.IsChecked = false; }

            // Selectionne le pigiste et le magazine correspondant dans les Comboboxs
            cboPigiste.SelectedItem = contratSelected.PigisteContrat;
            cboMagazine.SelectedItem = contratSelected.MagazineContrat;
        }

        private void dtgMagazine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // On récupère l'objet selectionné dans le datagrid et on le "cast" pour lui donner un type précis (Contrat, Magazine, Pigiste)
            Magazine magazineSelected = (Magazine)dtgMagazine.SelectedItem;

            // On met des valeurs dans les composants de l'interface via les valeurs de l'objet contratSelected
            txtNumMagazine.Text = Convert.ToString(magazineSelected.NumMagazine);
            dtpBouclageMagazine.Text = Convert.ToString(magazineSelected.DateBouclageMagazine);
            dtpParutionMagazine.Text = Convert.ToString(magazineSelected.DateParutionMagazine);
            dtpPaiementMagazine.Text = Convert.ToString(magazineSelected.DatePaiementMagazine);
            txtBudgetMagazine.Text = Convert.ToString(magazineSelected.BudgetMagazine);
        }

        private void dtgPigiste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // On récupère l'objet selectionné dans le datagrid et on le "cast" pour lui donner un type précis (Contrat, Magazine, Pigiste)
            Pigiste pigisteSelected = (Pigiste)dtgPigiste.SelectedItem;

            // On met des valeurs dans les composants de l'interface via les valeurs de l'objet contratSelected
            txtNumPigiste.Text = Convert.ToString(pigisteSelected.NumPigiste);
            txtNumSecuPigiste .Text = Convert.ToString(pigisteSelected.NumSecuPigiste);
            txtNomPigiste.Text = Convert.ToString(pigisteSelected.NomPigiste);
            txtPrenomPigiste.Text = Convert.ToString(pigisteSelected.PrenomPigiste);
            txtAdressePigiste.Text = Convert.ToString(pigisteSelected.AdressePigiste);
            txtCPPigiste.Text = Convert.ToString(pigisteSelected.CPPigiste);
            txtVillePigiste.Text = Convert.ToString(pigisteSelected.VillePigiste);
            txtMailPigiste.Text = Convert.ToString(pigisteSelected.MailPigiste);
            txtContratCadrePigiste.Text = Convert.ToString(pigisteSelected.ContratCadrePigiste);
        }

        private void btnAjouterMagazine_Click(object sender, RoutedEventArgs e)
        {
            Magazine tmpMag = new Magazine(Convert.ToInt16(txtNumMagazine.Text), dtpBouclageMagazine.Text, dtpPaiementMagazine.Text, dtpParutionMagazine.Text, Convert.ToInt16(txtBudgetMagazine.Text));
            cMagazine.Add(tmpMag);
            dtgMagazine.Items.Refresh();
        }

        private void btnSupprimerMagazine_Click(object sender, RoutedEventArgs e)
        {
            cMagazine.Remove((Magazine)dtgMagazine.SelectedItem);
            //On préselectionne par défaut le premier élément du Datagrid après la suppression
            dtgMagazine.SelectedIndex = 0;
            dtgMagazine.Items.Refresh();
        }

        private void btnModifierMagazine_Click(object sender, RoutedEventArgs e)
        {
            //On recherche à quel indice de la collection se trouve l'object selectionné dans le datagrid
            int indice = cMagazine.IndexOf((Magazine)dtgMagazine.SelectedItem);

            // On change les propritétés de l'objet à l'indice trouvé. On ne change pas le numéro de magazine via l'interface, trop de risques d'erreurs en base de données
            cMagazine.ElementAt(indice).DateParutionMagazine = dtpParutionMagazine.Text;
            cMagazine.ElementAt(indice).DatePaiementMagazine = dtpPaiementMagazine.Text;
            cMagazine.ElementAt(indice).DateBouclageMagazine = dtpBouclageMagazine.Text;
            cMagazine.ElementAt(indice).BudgetMagazine = Convert.ToInt32(txtBudgetMagazine.Text);

            dtgMagazine.Items.Refresh();
        }

        private void BtnAjouterContrat_Click(object sender, RoutedEventArgs e)
        {
            // Récupération du Pigiste sélectionné dans le Combobox cboPigiste
            Pigiste ModifPigiste = cboPigiste.SelectedItem as Pigiste;

            // Récupération du Magazine sélectionné dans le Combobox cboMagazine
            Magazine ModifMagazine = cboMagazine.SelectedItem as Magazine;


            Contrat tmpContrat = new Contrat(Convert.ToInt32(txtNumContrat.Text), Convert.ToInt32(txtMontantBrutContrat.Text), Convert.ToInt32(txtMontantNetContrat.Text), (bool)chkAgessa.IsChecked, (bool)chkFacture.IsChecked, cboEtatContrat.SelectedIndex,(Pigiste)cboPigiste.SelectedItem, (Magazine)cboMagazine.SelectedItem );
            cContrat.Add(tmpContrat);
            dtgContrat.Items.Refresh();
        }

        private void BtnSupprimerContrat_Click(object sender, RoutedEventArgs e)
        {
            cContrat.Remove((Contrat)dtgContrat.SelectedItem);
            //On préselectionne par défaut le premier élément du Datagrid après la suppression
            dtgContrat.SelectedIndex = 0;
            dtgContrat.Items.Refresh();
        }

        private void BtnModifierContrat_Click(object sender, RoutedEventArgs e)
        {
            //On recherche à quel indice de la collection se trouve l'object selectionné dans le datagrid
            int indice = cContrat.IndexOf((Contrat)dtgContrat.SelectedItem);

            // On change les propritétés de l'objet à l'indice trouvé. On ne change pas le numéro de magazine via l'interface, trop de risques d'erreurs en base de données
            cContrat.ElementAt(indice).LettreAccordContrat = txtLettreAccordContrat.Text;
            cContrat.ElementAt(indice).MontantBrutContrat = Convert.ToInt32(txtMontantBrutContrat.Text);
            cContrat.ElementAt(indice).MontantNetContrat = Convert.ToInt32(txtMontantNetContrat.Text);
            cContrat.ElementAt(indice).EtatContrat = cboEtatContrat.SelectedIndex;
            cContrat.ElementAt(indice).PigisteContrat = (Pigiste)cboPigiste.SelectedItem;
            cContrat.ElementAt(indice).MagazineContrat = (Magazine)cboMagazine.SelectedItem;
            cContrat.ElementAt(indice).FactureContrat = (bool)chkFacture.IsChecked;
            cContrat.ElementAt(indice).DeclarationAgessaContrat = (bool)chkAgessa.IsChecked;

            dtgContrat.Items.Refresh();
        }

        private void BtnAjouterPigiste_Click(object sender, RoutedEventArgs e)
        {
            Pigiste tmpPigiste = new Pigiste(Convert.ToInt32(txtNumPigiste.Text),txtNomPigiste.Text, txtPrenomPigiste.Text, txtAdressePigiste.Text, txtCPPigiste.Text, txtVillePigiste.Text, txtMailPigiste.Text, txtNumSecuPigiste.Text, txtContratCadrePigiste.Text);
            cPigiste.Add(tmpPigiste);
            dtgPigiste.Items.Refresh();
        }

        private void BtnSupprimerPigiste_Click(object sender, RoutedEventArgs e)
        {
            cPigiste.Remove((Pigiste)dtgPigiste.SelectedItem);
            //On préselectionne par défaut le premier élément du Datagrid après la suppression
            dtgPigiste.SelectedIndex = 0;
            dtgPigiste.Items.Refresh();
        }

        private void BtnModifierPigiste_Click(object sender, RoutedEventArgs e)
        {
            //On recherche à quel indice de la collection se trouve l'object selectionné dans le datagrid
            int indice = cPigiste.IndexOf((Pigiste)dtgPigiste.SelectedItem);
                      
            // On change les propritétés de l'objet à l'indice trouvé. On ne change pas le numéro de magazine via l'interface, trop de risques d'erreurs en base de données
            cPigiste.ElementAt(indice).NomPigiste = txtNomPigiste.Text;
            cPigiste.ElementAt(indice).PrenomPigiste = txtPrenomPigiste.Text;
            cPigiste.ElementAt(indice).NumSecuPigiste = txtNumSecuPigiste.Text;
            cPigiste.ElementAt(indice).ContratCadrePigiste = txtContratCadrePigiste.Text;
            cPigiste.ElementAt(indice).AdressePigiste = txtAdressePigiste.Text;
            cPigiste.ElementAt(indice).CPPigiste = txtCPPigiste.Text;
            cPigiste.ElementAt(indice).VillePigiste = txtVillePigiste.Text;
            cPigiste.ElementAt(indice).MailPigiste = txtMailPigiste.Text;

            dtgPigiste.Items.Refresh();
        }

        private void TxtMontantBrutContrat_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                double brut = Convert.ToDouble(txtMontantBrutContrat.Text);
                double ss = brut * 0.011;
                double csg = brut * 0.985 * 0.075;
                double crds = brut * 0.985 * 0.005;
                double fp = brut * 0.0035;
                double net = brut - Math.Floor(ss + csg + crds + fp);
                txtMontantNetContrat.Text = Convert.ToString(net);
            }
            catch (Exception)
            {
                txtMontantNetContrat.Text = "";
            }
        }

        private void TxtMontantNetContrat_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
