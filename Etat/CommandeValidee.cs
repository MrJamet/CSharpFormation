namespace CSharp
{
    public class CommandeValidee : EtatCommande
    {
        public CommandeValidee(Commande commande) : base(commande)
        {
        }

        public override void ajouteProduit(Produit produit)
        {            
        }

        public override void efface()
        {
            _commande.getProduit().Clear();
        }

        public override EtatCommande etatSuivant()
        {
            return new CommandeLivree(_commande);
        }

        public override void retireProduit(Produit produit)
        {            
        }
    }
}