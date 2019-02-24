using System;

public class Produit
{
    protected string _nom;

    public Produit(string nom)
    {
        _nom = nom;
    }

    public void affiche()
    {
        Console.WriteLine("Produit : " + _nom);
    }
}