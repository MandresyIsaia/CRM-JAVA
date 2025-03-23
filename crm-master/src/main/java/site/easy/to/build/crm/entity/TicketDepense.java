package site.easy.to.build.crm.entity;

public class TicketDepense {
    Ticket ticket;
    Depense depense;

    public TicketDepense() {
    }

    public TicketDepense(Ticket ticket, Depense depense) {
        this.ticket = ticket;
        this.depense = depense;
    }

    public Ticket getTicket() {
        return ticket;
    }

    public void setTicket(Ticket ticket) {
        this.ticket = ticket;
    }

    public Depense getDepense() {
        return depense;
    }

    public void setDepense(Depense depense) {
        this.depense = depense;
    }
}
