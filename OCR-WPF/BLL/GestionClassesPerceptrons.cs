using System.Collections.Generic;
using System.Linq;
using OCR_WPF.DAL;

namespace OCR_WPF.BLL
{
    /// Auteurs:     Hugo St-Louis & Olivier Charron
    /// Description: Gère les fonctionnalités de l'application. Entre autre, permet de :
    ///                 - Charger les échantillons d'apprentissage,
    ///                 - Sauvegarder les échantillons d'apprentissage,
    ///                 - Tester le perceptron
    ///                 - Entrainer le perceptron
    /// Date:        2023-04-21
    public class GestionClassesPerceptrons
    {
        private Dictionary<string, Perceptron> _lstPerceptrons;
        private GestionFichiersSorties _gestionSortie;
        private List<CoordDessin> _lstCoord;

        /// <summary>
        /// Constructeur
        /// </summary>
        public GestionClassesPerceptrons()
        {
            _lstPerceptrons = new Dictionary<string, Perceptron>();
            _gestionSortie = new GestionFichiersSorties();
            _lstCoord = _gestionSortie.ChargerCoordonnees(CstApplication.NOM_FICHIER_SAUVEGARDE);

            foreach (CoordDessin coord in _lstCoord)
            {
                if (!_lstPerceptrons.ContainsKey(coord.Reponse))
                    _lstPerceptrons.Add(coord.Reponse, new Perceptron(coord.Reponse));

                foreach (var p in _lstPerceptrons)
                    p.Value.Entrainement(_lstCoord);
            }
        }

        /// <summary>
        /// Auteur:      Olivier Charron
        /// Description: Charge les échantillons d'apprentissage sauvegardé sur le disque.
        /// Date:        2023-04-21
        /// </summary>
        /// <param name="fichier">Le nom du fichier</param>
        public void ChargerCoordonnees(string fichier)
        {
            _lstCoord = _gestionSortie.ChargerCoordonnees(fichier);
        }

        /// <summary>
        /// Auteur:      Olivier Charron
        /// Description: Sauvegarde les échantillons d'apprentissage sauvegardé sur le disque.
        /// Date:        2023-04-21
        /// </summary>
        /// <param name="fichier">Le nom du fichier</param>
        /// <returns>En cas d'erreur retourne le code d'erreur</returns>
        public int SauvegarderCoordonnees(string fichier)
        {
            int erreur = _gestionSortie.SauvegarderCoordonnees(fichier, _lstCoord);
            return erreur;
        }

        /// <summary>
        /// Auteur:      Olivier Charron
        /// Description: Entraine les perceptrons avec un nouveau caractère.
        /// Date:        2023-04-21
        /// </summary>
        /// <param name="coordo">Les nouvelles coordonnées</param>
        /// <param name="reponse">La réponse associé(caractère) aux coordonnées</param>
        /// <returns>Le résultat de la console</returns>
        public string Entrainement(CoordDessin coordo, string reponse)
        {
            if (!_lstCoord.Contains(coordo))
                _lstCoord.Add(coordo);

            if (!_lstPerceptrons.ContainsKey(coordo.Reponse))
                _lstPerceptrons.Add(coordo.Reponse, new Perceptron(coordo.Reponse));

            string sConsole = "";

            foreach (var item in _lstPerceptrons)
                sConsole = item.Value.Entrainement(_lstCoord);

            return sConsole;
        }

        /// <summary>
        /// Auteur:      Olivier Charron
        /// Description: Test le perceptron avec de nouvelles coordonnées.
        /// Date:        2023-04-21
        /// </summary>
        /// <param name="coord">Les nouvelles coordonnées</param>
        /// <returns>Retourne la liste des valeurs possibles du perceptron</returns>
        public string TesterPerceptron(CoordDessin coord)
        {
            bool bResultat = false;
            string reponse = "";

            foreach (var item in _lstPerceptrons)
            {
                bResultat = item.Value.TesterNeurone(coord);

                if (bResultat is true)
                    reponse += item.Value.Reponse;
            }

            return reponse;
        }

        /// <summary>
        /// Auteur:      Olivier Charron
        /// Description: Obtient une liste des coordonées.
        /// Date:        2023-04-21
        /// </summary>
        /// <returns>Une liste des coordonées.</returns>
        public IList<CoordDessin> ObtenirCoordonnees()
        {
            return _gestionSortie.ObtenirCoordonnees();
        }
    }
}
