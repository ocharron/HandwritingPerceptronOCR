# Handwriting Perceptron OCR - Reconnaissance d'�criture manuscrite WPF

[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/ocharron/HandwritingPerceptronOCR/blob/master/README.md)
[![fr](https://img.shields.io/badge/lang-fr-blue.svg)](https://github.com/ocharron/HandwritingPerceptronOCR/blob/master/README_fr.md)

Handwriting Perceptron OCR est une application WPF qui utilise un syst�me OCR bas� sur un perceptron. Les utilisateurs peuvent entra�ner le mod�le avec leur propre �criture manuscrite, puis tester sa capacit� � reconna�tre ce qu'ils ont �crit dans une bo�te de dessin.

---

## Technologies Utilis�es

- **Framework** : WPF (.NET 8.0)
- **Langage de programmation** : C#
- **Algorithme** : Perceptron (mod�le d'apprentissage automatique de base)

---

## Installation

Pour installer et ex�cuter **Handwriting Perceptron OCR** sur votre machine, suivez ces �tapes :

### Pr�requis

- [SDK .NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) ou un �diteur de texte de votre choix (Visual Studio Code, etc.)

### Instructions

1. **Clonez le d�p�t**
   ```bash
   git clone https://github.com/ocharron/HandwritingPerceptronOCR.git
   ```

2. **Compilation et ex�cution**
    - Ouvrez le projet dans Visual Studio ou utilisez la ligne de commande.
	- Ex�cutez la commande suivante pour restaurer les d�pendances :
	  ```bash
	  dotnet restore
	  ```
	- Ensuite, ex�cutez l'application :
	  ```bash
	  dotnet run
	  ```

---

## Fonctionnalit�s Cl�s

1. **Entra�nement de l'�criture manuscrite** : Les utilisateurs peuvent dessiner des caract�res dans la zone d'entr�e et les �tiqueter pour entra�ner le mod�le perceptron.
2. **Reconnaissance en temps r�el** : Apr�s l'entra�nement, le mod�le pr�dit les caract�res manuscrits dessin�s dans l'application.

---

## Auteur

Ce projet a �t� d�velopp� par [Olivier Charron](https://github.com/ocharron).