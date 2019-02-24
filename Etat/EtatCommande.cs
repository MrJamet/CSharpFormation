namespace CSharp
{
    public abstract class EtatCommande
    {
        protected Commande _commande{get;set;}

        public EtatCommande(Commande commande)
        {
            _commande = commande;
        }

        public abstract void ajouteProduit(Produit produit);
        public abstract void retireProduit(Produit produit);
        public abstract void efface();
        public abstract EtatCommande etatSuivant();
    }
}