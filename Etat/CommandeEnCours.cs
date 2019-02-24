namespace CSharp
{
    public class CommandeEnCours : EtatCommande
    {
        public CommandeEnCours(Commande commande) : base(commande)
        {
        }

        public override void ajouteProduit(Produit produit)
        {
            _commande.getProduit().Add(produit);
        }
        public override void retireProduit(Produit produit)
        {
            _commande.getProduit().Remove(produit);
        }

        public override void efface()
        {
            _commande.getProduit().Clear();
        }

        public override EtatCommande etatSuivant()
        {
            return new CommandeValidee(_commande);
        }
    }
}