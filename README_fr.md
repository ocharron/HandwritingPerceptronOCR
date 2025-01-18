# Handwriting Perceptron OCR - Reconnaissance d'écriture manuscrite WPF

[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/ocharron/HandwritingPerceptronOCR/blob/master/README.md)
[![fr](https://img.shields.io/badge/lang-fr-blue.svg)](https://github.com/ocharron/HandwritingPerceptronOCR/blob/master/README_fr.md)

Handwriting Perceptron OCR est une application WPF qui utilise un système OCR basé sur un perceptron. Les utilisateurs peuvent entraîner le modèle avec leur propre écriture manuscrite, puis tester sa capacité à reconnaître ce qu'ils ont écrit dans une boîte de dessin.

---

## Technologies Utilisées

- **Framework** : WPF (.NET 8.0)
- **Langage de programmation** : C#
- **Algorithme** : Perceptron (modèle d'apprentissage automatique de base)

---

## Installation

Pour installer et exécuter **Handwriting Perceptron OCR** sur votre machine, suivez ces étapes :

### Prérequis

- [SDK .NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) ou un éditeur de texte de votre choix (Visual Studio Code, etc.)

### Instructions

1. **Clonez le dépôt**
   ```bash
   git clone https://github.com/ocharron/HandwritingPerceptronOCR.git
   ```

2. **Compilation et exécution**
    - Ouvrez le projet dans Visual Studio ou utilisez la ligne de commande.
	- Exécutez la commande suivante pour restaurer les dépendances :
	  ```bash
	  dotnet restore
	  ```
	- Ensuite, exécutez l'application :
	  ```bash
	  dotnet run
	  ```

---

## Fonctionnalités Clés

1. **Entraînement de l'écriture manuscrite** : Les utilisateurs peuvent dessiner des caractères dans la zone d'entrée et les étiqueter pour entraîner le modèle perceptron.
2. **Reconnaissance en temps réel** : Après l'entraînement, le modèle prédit les caractères manuscrits dessinés dans l'application.

---

## Auteur

Ce projet a été développé par [Olivier Charron](https://github.com/ocharron).