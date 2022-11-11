using CompteBanqueNS;
namespace BanqueTests;

[TestClass]
public class CompteBancaireTests
{
    [TestMethod]
    public void VérifierDébitCompteCorrect()
    {
        // Ouvrir un compte
        double soldeInitial = 500000;
        double montantDébit = 400000;
        double soldeAttendu = 100000;
        var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);
        // Débiter
        compte.Débiter(montantDébit);
        // Tester
        double solde0btenu = compte.Balance;
        Assert.AreEqual(soldeAttendu, solde0btenu, 0.001, "Compte débité incorrectement");
    }

    [TestMethod]
    [ExpectedExceptionAttribute(typeof(ArgumentOutOfRangeException))]
    public void DébiterMontantNégatifLèveArgumentOutOfRange()
    {
        // Ouvrir un compte
        double soldeInitial = 500000;
        double montantDébit = -400000;
        double soldeAttendu = 100000;
        var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);
        // Débiter
        compte.Débiter(montantDébit);
        // Tester
        double solde0btenu = compte.Balance;
        Assert.AreEqual(soldeAttendu, solde0btenu, 0.001, "Compte débité incorrectement");
    }

    [TestMethod]
    [ExpectedExceptionAttribute(typeof(ArgumentOutOfRangeException))]
    public void DébiterMontantSupérieurSoldeLèveArgumentOutOfRange()
    {
        // Ouvrir un compte
        double soldeInitial = 500000;
        double montantDébit = 700000;
        double soldeAttendu = 100000;
        var compte = new CompteBancaire("Pr. Abdoulaye Diankha", soldeInitial);
        // Débiter
        compte.Débiter(montantDébit);
        // Tester
        double solde0btenu = compte.Balance;
        Assert.AreEqual(soldeAttendu, solde0btenu, 0.001, "Compte débité incorrectement");
    }


}