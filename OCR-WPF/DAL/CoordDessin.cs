using System.Collections;

namespace OCR_WPF.DAL
{
    /// <summary>
    /// Auteurs:     Hugo St-Louis & Olivier Charron
    /// Description: Gère la structure de données qui contient le caractères et les
    ///              coordonnées des points du dessin de ce caractère.
    /// Date:        2023-04-21
    /// </summary>
    public class CoordDessin
    {
        private BitArray _baDessin = null;
        private string _reponse = "?";

        public BitArray BitArrayDessin
        {
            get { return _baDessin; }
            set { _baDessin = value; }
        }
        public string Reponse
        {
            get { return _reponse; }
            set { _reponse = value; }
        }

        /// <summary>
        /// Constructeur, crée un vecteur de bit pour représenter le dessin. Le blanc = 1 et le noir = -1.
        /// </summary>
        /// <param name="largeur">Largeur du dessin</param>
        /// <param name="hauteur">Hauteur du dessin</param>
        public CoordDessin(int largeur, int hauteur)
        {
            _baDessin = new BitArray(largeur / CstApplication.LARGEURTRAIT * (hauteur / CstApplication.HAUTEURTRAIT));
        }

        /// <summary>
        /// Auteur:      Hugo St-Louis
        /// Description: Lors de l'ajout d'un point, modifier le vecteur de bits où il y a de nouveaux points noirs.
        /// Date:        2023-04-21
        /// </summary>
        /// <param name="x">La position x du nouveau point.</param>
        /// <param name="y">La position y du nouveau point.</param>
        /// <param name="tailleX">La taille en x du point</param>
        /// <param name="tailleY">La taille en y du point</param>
        public void AjouterCoordonnees(int x, int y, int tailleX, int tailleY)
        {
            if (x < 0)
                x = 0;

            if (y < 0)
                y = 0;

            if (x + tailleX >= CstApplication.TAILLEDESSINX)
                x = CstApplication.TAILLEDESSINX - tailleX;

            if (y + tailleY >= CstApplication.TAILLEDESSINY)
                y = CstApplication.TAILLEDESSINY - tailleY;

            _baDessin[x / tailleX * (CstApplication.TAILLEDESSINX / tailleX) + y / tailleY] = true;
        }
    }
}