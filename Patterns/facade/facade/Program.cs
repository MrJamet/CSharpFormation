// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var service = new PersonneFacade(new PersonneService(), new AdresseService(), new CommandeService());
var personne = service.GetInfo(1);

if(personne != null)
{
    Console.WriteLine($"{personne.Nom} {personne.Prenom} : {personne.CodePostal} avec {personne.Commandes.Count()} commande(s)");
}
