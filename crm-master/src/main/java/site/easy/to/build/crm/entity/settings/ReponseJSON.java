package site.easy.to.build.crm.entity.settings;



public class ReponseJSON {
    String nom;
    double valeur;

    public ReponseJSON() {
    }

    public ReponseJSON(String nom, double valeur) {
        this.nom = nom;
        this.valeur = valeur;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }

    public double getValeur() {
        return valeur;
    }

    public void setValeur(double valeur) {
        this.valeur = valeur;
    }
}
