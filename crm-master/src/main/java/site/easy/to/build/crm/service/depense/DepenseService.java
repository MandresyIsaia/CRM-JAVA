package site.easy.to.build.crm.service.depense;

import java.time.LocalDateTime;
import java.util.List;
import java.util.Optional;

import org.springframework.cglib.core.Local;
import org.springframework.data.repository.query.Param;
import site.easy.to.build.crm.entity.Depense;
import site.easy.to.build.crm.entity.Lead;

public interface DepenseService {
    List<Depense> getAllDepenses();
    Optional<Depense> getDepenseById(Integer id);
    Depense saveDepense(Depense depense);
    void deleteDepense(Integer id);
    double getTotalDepenseByCustomerId(int customerId);
    public Depense  getDepenseByLeadId(int idLead);
    public Depense  getDepenseByTicketId(@Param("idTicket") int idTicket);
    List<Depense> findTicketsWithActiveDepenses();
    List<Depense> findLeadsWithActiveDepenses();
    void delete(Depense depense);
    double getTotalLeadsActif();
    double getTotalTicketsActif();
    double getTotalDepenseTicket();
    double getTotalDepenseLead();
    List<Depense> findTicketsDepenses();
    List<Depense> findLeadsDepenses();

    List<Depense> rechercheMultiCritere(LocalDateTime dateDebut, LocalDateTime dateFin,Boolean lead,Boolean ticket);
  
}
