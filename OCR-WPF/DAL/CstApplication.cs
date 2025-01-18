﻿namespace OCR_WPF.DAL
{
    /// <summary>
    /// Auteurs:     Hugo St-Louis & Olivier Charron
    /// Description: Classe de constantes de l'application.
    /// Date:        2023-04-21
    /// </summary>
    public static class CstApplication
    {
        //Taille maximale de l'interface de dessin.
        public const int TAILLEDESSINY = 128;
        public const int TAILLEDESSINX = 128;

        //Critère de convergence pour le perceptron.
        public const int MAXITERATION = 20;
        public const int POURCENTCONVERGENCE = 80;

        //Taille du trait lors du dessin.
        public const int LARGEURTRAIT = 8;
        public const int HAUTEURTRAIT = 8;

        //Valeur vrai ou fausse pour le perceptron
        public const int VRAI = 1;
        public const int FAUX = -1;

        //Constante d'apprentissage pour le perceptron
        public const double VITESSE_APP = 0.2;

        //Code d'erreur (pas nécessaire).
        public const int ERREUR = -1;
        public const int OK = 0;

        //Nombre maximale de permutation pour répartir les échantillons(pas nécessaire).
        public const int MAXPERMUTATION = 6000;

        //Le nombre de bits dans le dessin en X.
        public const int NOMBRE_BITS_X = TAILLEDESSINX / LARGEURTRAIT;
        //Le nombre de bits dans le dessin en Y.
        public const int NOMBRE_BITS_Y = TAILLEDESSINY / HAUTEURTRAIT;

        //Nom du fichier de sauvegarde
        public const string NOM_FICHIER_SAUVEGARDE = "DAL\\data.txt";
    }
}
