
public record Personne(int Id, string Nom, string Prenom, int AdresseLatitude, int AdresseLongitude);
public class PersonneService
{
    public Personne GetPersonne(int id)
    {
        return new Personne(id, "Aline", "Puducul", 998877, 112233);
    }
}

public record Address(string Rue, string CodePostal, string Pays);

public class AdresseService
{
    public Address GetAddress(int longitude, int latitude)
    {
        return new Address("1 rue de blablabla", "67000", "France");
    }
}

public record Commande(int Id, decimal Montant, DateTime Date);

public class CommandeService
{
    public IEnumerable<Commande> GetCommandes(int personneId)
    {
        return new []{ 
            new Commande(1, 1000, DateTime.UtcNow),
            new Commande(2, 2000, DateTime.UtcNow),
            new Commande(3, 3000, DateTime.UtcNow),
            new Commande(4, 4000, DateTime.UtcNow),
            new Commande(5, 5000, DateTime.UtcNow)
        };
    }
}

public class PersonneAvecAdresseCommande
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string CodePostal {get;set;}
    public string Pays{get;set;}
    public string Rue { get; set; }
    public IEnumerable<Commande> Commandes {get; set;}
}

public class PersonneFacade
{
    public PersonneService personneService1 { get; set; }
    public AdresseService adresseService1 { get; set; }
    public CommandeService commandeService1 {get;set;}
    public PersonneFacade(
        PersonneService personneService,
        AdresseService adresseService,
        CommandeService commandeService)
    {
        this.personneService1 = personneService;
        this.adresseService1 = adresseService;
        this.commandeService1 = commandeService;
    }
    public PersonneAvecAdresseCommande? GetInfo(int id)
    {
        var personne = personneService1.GetPersonne(id);
        if(personne is not null)
        {
            var address = adresseService1.GetAddress(personne.AdresseLongitude, personne.AdresseLatitude);
            var commande = commandeService1.GetCommandes(id);
            return new PersonneAvecAdresseCommande
            {
                Id = id,
                CodePostal = address?.CodePostal ?? "99999",
                Nom = personne.Nom,
                Prenom = personne.Prenom,
                Pays = address?.Pays ?? "France",
                Rue = address?.Rue ?? "non reconue",
                Commandes = commande
            };
        }
        return null;
    }
}