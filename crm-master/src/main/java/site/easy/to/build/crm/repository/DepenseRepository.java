package site.easy.to.build.crm.repository;

import java.util.List;

import jakarta.persistence.EntityManager;
import jakarta.persistence.PersistenceContext;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import site.easy.to.build.crm.entity.Budget;
import site.easy.to.build.crm.entity.Depense;
import site.easy.to.build.crm.entity.Ticket;

@Repository
public interface DepenseRepository extends JpaRepository<Depense, Integer>, JpaSpecificationExecutor<Depense> {

    @Query("SELECT COALESCE(SUM(d.valeurDepense), 0) " +
       "FROM Depense d " +
       "LEFT JOIN d.lead l " +
       "LEFT JOIN d.ticket t " +
       "LEFT JOIN l.customer c " +
       "LEFT JOIN t.customer c2 " +
       "WHERE (c.customerId = :customerId OR c2.customerId = :customerId) and d.etat= 1")
    public double getTotalDepenseByCustomerId(@Param("customerId") int customerId);

    @Query("SELECT d " +
            "FROM Depense d " +
            "WHERE d.lead.leadId =: idLead")
    public Depense  getDepenseByLeadId(@Param("idLead") int idLead);

    @Query("SELECT d " +
            "FROM Depense d " +
            "WHERE d.ticket.ticketId =: idTicket")
    public Depense  getDepenseByTicketId(@Param("idTicket") int idTicket);
    @Query("SELECT DISTINCT d FROM Depense d WHERE d.etat = 1 AND d.ticket IS NOT NULL")
    List<Depense> findTicketsWithActiveDepenses();
    @Query("SELECT DISTINCT d FROM Depense d WHERE d.etat = 1 AND d.lead IS NOT NULL")
    List<Depense> findLeadsWithActiveDepenses();

    @Query("SELECT COALESCE(SUM(d.valeurDepense), 0) FROM Depense d  WHERE d.etat = 1 AND d.lead IS NOT NULL")
    double getTotalLeadsActif();
    @Query("SELECT COALESCE(SUM(d.valeurDepense), 0) FROM Depense d  WHERE d.etat = 1 AND d.ticket IS NOT NULL")
    double getTotalTicketsActif();

    @Query("SELECT COALESCE(SUM(d.valeurDepense), 0) FROM Depense d  WHERE d.ticket IS NOT NULL")
    double getTotalDepenseTicket();
    @Query("SELECT COALESCE(SUM(d.valeurDepense), 0) FROM Depense d  WHERE d.etat IS NOT NULL")
    double getTotalDepenseLead();
    @Query("SELECT DISTINCT d FROM Depense d WHERE d.ticket IS NOT NULL")
    List<Depense> findTicketsDepenses();
    @Query("SELECT DISTINCT d FROM Depense d WHERE d.lead IS NOT NULL")
    List<Depense> findLeadsDepenses();

}