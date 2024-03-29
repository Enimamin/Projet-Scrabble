﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Scrabble
{
    class Plateau
    {
        //Déclaration
        char[,] plateau;

        //Constructeurs
        public Plateau() //Constructeur de base
        {
            plateau = new char[15, 15];
        }
        public Plateau(string fichier) //Constructeur particulier
        {
            plateau = new char[15, 15];
            for(int i = 0; i < plateau.GetLength(0); i++)
            {
                for(int j = 0; j < plateau.GetLength(1); j++)
                {
                    plateau[i, j] = fichier[2 * i + j * 30];
                }
            }
        }

        //Opérations
        public string toString()
        {
            string ret = "\n\n\n";
            for (int i = 0; i < plateau.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < plateau.GetLength(1) - 1; j++)
                {
                    ret += plateau[i, j] + " ";
                }
                ret += plateau[i, plateau.GetLength(1) - 1] + "\n";
            }
            return ret;
        }


        public bool Test_Plateau(string mot, int ligne, int colonne, char direction)
        {
            bool ret = true;
            if(direction == 'h') //Si mot va vers le haut
            {
                if (mot.Length > ligne + 1) //Vérification espace nécessaire
                {
                    Console.WriteLine("Erreur, il n'y a pas assez d'espace pour placer ce mot ici");
                    return false;
                }
                else
                {
                    for(int i = 0; i < mot.Length; i++) //Vérification que les cases sont vides, ou que les croisements ont les mêmes lettres
                    {
                        if (plateau[ligne, colonne - i] != mot[i] && plateau[ligne, colonne - i] != '_')
                        {
                            ret = false;
                        }
                    }
                    if (ret == false) Console.WriteLine("Il n'est pas possible de placer ce mot ici");
                    return ret;
                }
            }
            else if (direction == 'b')//Si mot va vers le bas
            {
                if (mot.Length >= 15 - ligne)//Vérification espace nécessaire
                {
                    Console.WriteLine("Erreur, il n'y a pas assez d'espace pour placer ce mot ici");
                            return false;
                        }
                else
                {
                    for (int i = 0; i < mot.Length; i++)//Vérification que les cases sont vides, ou que les croisements ont les mêmes lettres
                    {
                        if (plateau[ligne, colonne + i] != mot[i] && plateau[ligne, colonne  + i] != '_')
                        {
                            ret = false;
                        }
                    }
                    if (ret == false) Console.WriteLine("Il n'est pas possible de placer ce mot ici");
                    return ret;
                    }
                }
            else if (direction == 'g')//Si mot va vers la gauche
            {
                if (mot.Length > colonne + 1)//Vérification espace nécessaire
                {
                    Console.WriteLine("Erreur, il n'y a pas assez d'espace pour placer ce mot ici");
                    return false;
            }
                else
            {
                    for (int i = 0; i < mot.Length; i++)//Vérification que les cases sont vides, ou que les croisements ont les mêmes lettres
                    {
                        if (plateau[ligne - i, colonne] != mot[i] && plateau[ligne - i, colonne] != '_')
                        {
                            Console.WriteLine("Erreur, il n'est pas possible de placer ce mot ici.");
                            ret = false;
            }
                    }
                    if (ret == false) Console.WriteLine("Il n'est pas possible de placer ce mot ici");
                    return ret;
                }
            }
            else if (direction == 'd')//Si mot va vers la droite
            {
                if (mot.Length >= 15 - colonne)//Vérification espace nécessaire
            {
                    Console.WriteLine("Erreur, il n'y a pas assez d'espace pour placer ce mot ici");
                    return false;
            }
                else
                {
                    for (int i = 0; i < mot.Length; i++)//Vérification que les cases sont vides, ou que les croisements ont les mêmes lettres
                    {
                        if (plateau[ligne + i, colonne] != mot[i] && plateau[ligne + i, colonne] != '_')
            {
                            ret = false;
                        }
                    }
                    if (ret == false) Console.WriteLine("Il n'est pas possible de placer ce mot ici");
                    return ret;
                }
            }
            else
            {
                Console.WriteLine("Erreur, la direction doit être h, b, d, ou g");
                return false;
            }
        }
    }
}
