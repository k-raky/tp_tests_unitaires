using System;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Xml;

namespace CompteBanqueNS;

public class CompteBancaire
{
    private string m_nomClient;
    private double m_solde;
    private bool m_bloque = false;

    private CompteBancaire() { }

    public CompteBancaire(string nomclient, double solde)
    {
        m_nomClient = nomclient;
        m_solde = solde;
    }

    public string nomClient
    {
        get { return m_nomClient; }
    }

    public double Balance
    {
        get { return m_solde; }
    }

    public void Débiter(double montant)
    {

        if (m_bloque)
        {
            throw new Exception("Compte bloqué");
        }

        if (montant > m_solde)
        {
            throw new ArgumentOutOfRangeException("Montant débité doit être supérieur ou egal au solde disponible");
        }

        if (montant < 0)
        {
            throw new ArgumentOutOfRangeException("Montant doit être positif");
        }

        m_solde -= montant; // code intentionellement faux
    }

    public void Crediter(double montant)
    {

        if (m_bloque)
        {
            throw new Exception("Compte bloqué");
        }

        if (montant < 0)
        {
            throw new ArgumentOutOfRangeException("Montant débité doit être supérieur a 0");
        }

        m_solde += montant;
    }

    private void BloquerCompte()
    {
        m_bloque = true;
    }

    private void DébloquerCompte()
    {
        m_bloque = false;
    }

    public static void Main()
    {
        CompteBancaire cb = new CompteBancaire("Pr. Abdoulaye Diankha", 500000);

        cb.Crediter(500000);
        cb.Débiter(400000);
        Console.WriteLine("Solde disponible égal à F{0}", cb.Balance);
    }

}



