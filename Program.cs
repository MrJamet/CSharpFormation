using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pattern ETAT
            Commande commande = new Commande();
            commande.ajouteProduit(new Produit("Pomme"));
            commande.ajouteProduit(new Produit("Banane"));
            commande.afficher();
            commande.etatSuivant();            
            commande.ajouteProduit(new Produit("Chocolat"));
            commande.effacer();
            commande.afficher();

            Commande commande2 = new Commande();
            commande2.ajouteProduit(new Produit("moto"));
            commande2.ajouteProduit(new Produit("casque"));
            commande2.afficher();
            commande2.etatSuivant();
            commande2.afficher();
            commande2.etatSuivant();
            commande2.effacer();
            commande2.afficher();
        }
    }
}
