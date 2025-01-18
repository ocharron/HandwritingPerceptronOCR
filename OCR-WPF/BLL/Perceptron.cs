using System;
using System.Collections;
using System.Collections.Generic;
using OCR_WPF.DAL;

namespace OCR_WPF.BLL
{
    /// <summary>
    /// Auteurs:     Hugo St-Louis & Olivier Charron
    /// Description: Classe du perceptron. Permet de faire l'apprentissage automatique sur un échantillon d'apprentissage. 
    /// Date:        2023-04-21
    /// </summary>
    public class Perceptron
    {
        
        private double[] _poidsSynaptique;
        private string _reponse = "?";

        public string Reponse
        {
            get { return _reponse; }
        }

        /// <summary>
        /// Constructeur de la classe. Crée un perceptron pour une réponse(caractère) qu'on veut identifier le pattern(modèle)
        /// </summary>
        /// <param name="reponse">La classe que défini le perceptron</param>
        public Perceptron(string reponse)
        {
            _reponse = reponse;
        }

        /// <summary>
        /// Auteur:      Olivier Charron
        /// Description: Faire l'apprentissage sur un ensemble de coordonnées. Ces coordonnées sont les coordonnées
        ///              de tous les caractères analysés. 
        /// Date:        2023-04-21
        /// </summary>
        /// <param name="lstCoord">La liste de coordonnées pour les caractères à analysés.</param>
        /// <returns>Les paramètres de la console</returns>
        public string Entrainement(List<CoordDessin> lstCoord)
        {
            string sResultat = "";
            int iNbIteration = 0;
            int iNbErreur = 0;
            int iResultatEstime = 0;
            int iErreurLocale = 0;
            double dSomme = 0.0;
            double dPourcentageSucces = 0.0;
            Random rnd = new Random();

            _poidsSynaptique = new double[CstApplication.NOMBRE_BITS_X * CstApplication.NOMBRE_BITS_Y];

            for (int i = 0; i < CstApplication.NOMBRE_BITS_X * CstApplication.NOMBRE_BITS_Y - 1; i++)
                _poidsSynaptique[i] = rnd.NextDouble();

            do
            {
                iNbErreur = 0;
                for (int i = 0; i < lstCoord.Count; i++)
                {
                    // Évaluer une observation et faire une prédiction.
                    dSomme = _poidsSynaptique[0];
                    for (int j = 1; j < _poidsSynaptique.Length; j++)
                        dSomme += _poidsSynaptique[j] * (double)(lstCoord[i].BitArrayDessin[j - 1] ? 1 : 0);

                    iResultatEstime = (dSomme >= 0) ? 1 : 0;
                    iErreurLocale = (lstCoord[i].Reponse == _reponse ? 1 : 0) - iResultatEstime;

                    // Vérifier s'il y a eu une erreur de prédiction avec l'observation.
                    if (iErreurLocale != 0)
                    {
                        // Si il s'est trompé dans la prédiction, alors mettre à jour
                        // les poids synaptiques avec la méthode de descente en gradiant.
                        _poidsSynaptique[0] += CstApplication.VITESSE_APP * iErreurLocale;
                        for (int j = 1; j < _poidsSynaptique.Length; j++)
                            _poidsSynaptique[j] += CstApplication.VITESSE_APP * iErreurLocale * (double)(lstCoord[i].BitArrayDessin[j - 1] ? 1 : 0);
                        iNbErreur++;
                    }
                }
                iNbIteration++;
                sResultat += $"\r\nIteration: {iNbIteration}\tErreur: {iNbErreur}";
                dPourcentageSucces = (double)(lstCoord.Count - iNbErreur) / (double)lstCoord.Count * 100.00;
                sResultat += $"\tTaux de succès: {dPourcentageSucces}%";

            } while (iNbErreur > 0 && iNbIteration < CstApplication.MAXITERATION); // Jusqu'à obtention de la convergence

            return sResultat;
        }

        /// <summary>
        /// Auteur:      Olivier Charron
        /// Description: Calcul la valeur(vrai ou faux) pour un les coordonnées d'un caractère. Permet au
        ///              perceptron d'évaluer la valeur de vérité.
        /// Date:        2023-04-21
        /// </summary>
        /// <param name="vecteurSyn">Les poids synaptiques du perceptron</param>
        /// <param name="entree">Le vecteur de bit correspondant aux couleurs du caractère</param>
        /// <returns>Vrai ou faux</returns>
        public int ValeurEstime(double[] vecteurSyn, BitArray entree)
        {
            int iResultatEstime = 0;
            double dSomme = 0.0;

            dSomme = vecteurSyn[0];
            for (int j = 1; j < vecteurSyn.Length; j++)
                dSomme += vecteurSyn[j] * (double)(entree[j - 1] ? 1 : 0);

            iResultatEstime = (dSomme >= 0) ? 1 : 0;

            if (iResultatEstime == 1)
                return CstApplication.VRAI;
            else
                return CstApplication.FAUX;
        }

        /// <summary>
        /// Auteur:      Olivier Charron
        /// Description: Interroge la neuronnes pour un ensembles des coordonnées (d'un caractère).
        /// Date:        2023-04-21
        /// </summary>
        /// <param name="coord"></param>
        /// <returns>Si le perceptron est valide ou non</returns>
        public bool TesterNeurone(CoordDessin coord)
        {
            return ValeurEstime(_poidsSynaptique, coord.BitArrayDessin) == 1 ? true : false;
        }

    }
}