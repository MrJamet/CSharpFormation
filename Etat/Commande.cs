using System;
using System.Collections.Generic;

namespace CSharp
{
    public class Commande
    {
        protected IList<Produit> _produits{get;set;}
        protected EtatCommande _etatCommande{get;set;}

        public Commande()
        {
            _etatCommande = new CommandeEnCours(this);
            _produits = new List<Produit>();
        }

        public void ajouteProduit(Produit produit)
        {
            _etatCommande.ajouteProduit(produit);
        }

        public void retirerProduit(Produit produit)
        {
            _etatCommande.retireProduit(produit);
        }

        public void effacer()
        {
            _etatCommande.efface();
        }

        public void etatSuivant()
        {
            _etatCommande = _etatCommande.etatSuivant();
        }

        public IList<Produit> getProduit()
        {
            return _produits;
        }

        public void afficher()
        {
            Console.WriteLine("Contenu de la commande.");
            foreach (Produit produit in _produits)
            {
                produit.affiche();
            }
            Console.WriteLine();
        }
    }
}