package site.easy.to.build.crm.entity;

public class LeadDepense {
    Lead lead;
    Depense depense;

    public LeadDepense() {
    }

    public LeadDepense(Lead lead, Depense depense) {
        this.lead = lead;
        this.depense = depense;
    }

    public Lead getLead() {
        return lead;
    }

    public void setLead(Lead lead) {
        this.lead = lead;
    }

    public Depense getDepense() {
        return depense;
    }

    public void setDepense(Depense depense) {
        this.depense = depense;
    }
}
