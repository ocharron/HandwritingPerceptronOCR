using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace OCR_WPF.DAL
{
    /// <summary>
    /// Auteurs:     Hugo St-Louis & Olivier Charron
    /// Description: Cette classe gère l'accès aux disques pour le fichiers d'apprentissages. 
    ///              Permet de charger ou décharger dans la matrice d'apprentissage.
    /// Date:        2023-04-21
    /// </summary>
    public class GestionFichiersSorties
    {
        private readonly List<CoordDessin> _lstCoord = new();

        /// <summary>
        /// Auteur:      Olivier Charron
        /// Description: Permet d'extraire un fichier texte dans une matrice pour l'apprentissage automatique.
        /// Date:        2023-04-21
        /// </summary>
        /// <param name="fichier">Fichier où extraire les données</param>
        public List<CoordDessin> ChargerCoordonnees(string fichier)
        {
            StreamReader sr = new StreamReader(fichier);
            string sLigneFichier;
            char cCaract;

            while ((sLigneFichier = sr.ReadLine()) is not null)
            {
                CoordDessin coordDessin = new CoordDessin(CstApplication.TAILLEDESSINX, CstApplication.TAILLEDESSINY);

                bool[] bTableau = new bool[sLigneFichier.Length - 1];

                coordDessin.Reponse = sLigneFichier.Substring(0, 1);

                for (int c = 1; c < sLigneFichier.Length; c++)
                {
                    cCaract = sLigneFichier[c];
                    if (char.ToLower(cCaract) == '1')
                        bTableau[c - 1] = true;
                    else
                        bTableau[c - 1] = false;
                }

                BitArray bitArray = new BitArray(bTableau);
                coordDessin.BitArrayDessin = bitArray;
                _lstCoord.Add(coordDessin);
            }
            sr.Close();

            return _lstCoord;
        }

        /// <summary>
        /// Auteur:      Olivier Charron
        /// Description: Permet de sauvegarder dans fichier texte dans une matrice pour l'apprentissage automatique
        /// Date:        2023-04-21
        /// </summary>
        /// <param name="fichier">Fichier où sauvegarder les données</param>
        public int SauvegarderCoordonnees(string fichier, List<CoordDessin> lstCoord)
        {
            StreamWriter sw = new(fichier);
            string sLigne;

            foreach (CoordDessin coord in lstCoord)
            {
                sLigne = coord.Reponse;

                for (int b = 0; b < coord.BitArrayDessin.Length; b++)
                {
                    if (coord.BitArrayDessin[b] == true)
                        sLigne += "1";
                    else
                        sLigne += "0";
                }

                sw.WriteLine(sLigne);
            }
            sw.Close();

            return CstApplication.OK;
        }

        /// <summary>
        /// Auteur:      Hugo St-Louis
        /// Description: Retourne la liste de coordonées extraites d'un fichier texte contenues dans une
        ///              matrice pour l'apprentissage automatique.
        /// Date:        2023-04-21
        /// </summary>
        public IList<CoordDessin> ObtenirCoordonnees()
        {
            return _lstCoord;
        }
    }
}
