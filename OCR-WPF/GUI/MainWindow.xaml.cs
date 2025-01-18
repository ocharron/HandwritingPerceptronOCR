using System.Windows;
using OCR_WPF.BLL;
using OCR_WPF.DAL;

namespace OCR_WPF
{
    /// <summary>
    /// Auteurs:     Hugo St-Louis & Olivier Charron
    /// Description: Permet d'afficher l'interface pour la reconnaissance de caractères. Cet interface
    ///              fera appel au Perceptron pour identifier le caractère dessiné.
    /// Date:        2023-04-21
    /// </summary>
    public partial class MainWindow : Window
    {
        // Le gestionnaire des perceptrons.
        private GestionClassesPerceptrons _gcpAnalyseEcriture;

        /// <summary>
        /// Constructeur
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            ucDessin.Width = CstApplication.TAILLEDESSINX + 6;
            ucDessin.Height = CstApplication.TAILLEDESSINY + 6;

            _gcpAnalyseEcriture = new GestionClassesPerceptrons();
        }

        /// <summary>
        /// Auteur:     Hugo St-Louis
        /// Descrition: Action qui efface le caractère dessiné et sa matrice.
        /// Date:       2023-04-21
        /// </summary>
        /// <param name="sender">L'objet qui à envoyé cet événement.</param>
        /// <param name="e">Les arguments de cet événement.</param>
        private void btnEffacer_Click(object sender, RoutedEventArgs e)
        {
            ucDessin.EffacerDessin();
        }

        /// <summary>
        /// Auteur:      Olivier Charron
        /// Description: Entraine le bon Perceptron avec la valeur entrée dans le TextBox txtValeurEntrainee et le caractère dessiné.
        /// Date:        2023-04-21
        /// </summary>
        private void btnEntrainement_Click(object sender, RoutedEventArgs e)
        {
            ucDessin.Coordonnees.Reponse = txtValeurEntrainee.Text;
            txtConsole.Text = _gcpAnalyseEcriture.Entrainement(ucDessin.Coordonnees, ucDessin.Coordonnees.Reponse);
        }

        /// <summary>
        /// Auteur:      Olivier Charron
        /// Description: Appel le perceptron pour vérifier quel neuronne identifie le mieux le caractère dessiné.
        /// Date:        2023-04-21
        /// </summary>
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            txtValeurTestee.Text = _gcpAnalyseEcriture.TesterPerceptron(ucDessin.Coordonnees);
        }

        /// <summary>
        /// Auteur:      Olivier Charron
        /// Description: Action s'exécutant à la fermeture de la fenêtre qui enregistre les données dans un fichier texte.
        /// Date:        2023-04-21
        /// </summary>
        private void frmAnalyseEcriture_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _gcpAnalyseEcriture.SauvegarderCoordonnees(CstApplication.NOM_FICHIER_SAUVEGARDE);
        }

        /// <summary>
        /// Auteur:      Olivier Charron
        /// Description: Action s'exécutant à l'ouverture de la fenêtre qui lit les données d'un fichier texte.
        /// Date:        2023-04-21
        /// </summary>
        private void ucDessin_Loaded(object sender, RoutedEventArgs e)
        {
            _gcpAnalyseEcriture.ChargerCoordonnees(CstApplication.NOM_FICHIER_SAUVEGARDE);
        }
    }
}
