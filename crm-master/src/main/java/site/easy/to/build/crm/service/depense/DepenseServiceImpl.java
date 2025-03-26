package site.easy.to.build.crm.service.depense;

import java.time.LocalDateTime;
import java.util.List;
import java.util.Optional;

import jakarta.persistence.EntityManager;
import jakarta.persistence.PersistenceContext;
import jakarta.persistence.TypedQuery;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.data.repository.query.Param;
import org.springframework.jdbc.core.BeanPropertyRowMapper;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.stereotype.Service;

import site.easy.to.build.crm.entity.Depense;
import site.easy.to.build.crm.entity.Lead;
import site.easy.to.build.crm.entity.Notification;
import site.easy.to.build.crm.entity.filtreMultiCritaire.FiltreDepense;
import site.easy.to.build.crm.repository.DepenseRepository;
import site.easy.to.build.crm.service.budget.BudgetService;
import site.easy.to.build.crm.service.notification.NotificationService;
import site.easy.to.build.crm.service.notification.NotificationServiceImpl;

@Service
public class DepenseServiceImpl implements DepenseService {
    
    private final DepenseRepository depenseRepository;
    private final JdbcTemplate jdbcTemplate;
    @PersistenceContext
    private EntityManager entityManager;
   
    @Autowired
    public DepenseServiceImpl(DepenseRepository depenseRepository, JdbcTemplate jdbcTemplate){
        this.depenseRepository = depenseRepository;

        this.jdbcTemplate = jdbcTemplate;
    }

    @Override
    public List<Depense> getAllDepenses() {
        return depenseRepository.findAll();
    }

    @Override
    public Optional<Depense> getDepenseById(Integer id) {
        return depenseRepository.findById(id);
    }

    @Override
    public Depense saveDepense(Depense depense) {
        return depenseRepository.save(depense);
    }

    @Override
    public void deleteDepense(Integer id) {
        depenseRepository.deleteById(id);
    }

    @Override
    public double getTotalDepenseByCustomerId(int customerId) {
        return depenseRepository.getTotalDepenseByCustomerId(customerId);
    }
    // public void createDepense(Lead lead, double newDepense){
    //     Depense depense = new Depense();
    //     depense.setLead(lead);
    //     Notification notif = budgetService.checkBudget(lead.getCustomer().getCustomerId(), newDepense);
    //     if (notif.getMessage()!=null) {
    //         notificationService.save(notif);    
    //     }
    //     depenseRepository.save(depense);
        
    // }
    @Override
    public Depense  getDepenseByLeadId(int idLead){
        return depenseRepository.getDepenseByLeadId(idLead);
    }
    @Override
    public Depense  getDepenseByTicketId( int idTicket){
        return depenseRepository.getDepenseByTicketId(idTicket);
    }
    @Override
    public List<Depense> findTicketsWithActiveDepenses(){
        return depenseRepository.findTicketsWithActiveDepenses();
    }
    @Override
    public List<Depense> findLeadsWithActiveDepenses(){
        return depenseRepository.findLeadsWithActiveDepenses();
    }
    @Override
    public void delete(Depense depense){
        depenseRepository.delete(depense);
    }

    @Override
    public double getTotalLeadsActif(){
        return depenseRepository.getTotalLeadsActif();
    }

    @Override
    public double getTotalTicketsActif(){
        return depenseRepository.getTotalTicketsActif();
    }

    @Override
    public double getTotalDepenseTicket(){
        return depenseRepository.getTotalDepenseTicket();
    }
    @Override
    public double getTotalDepenseLead(){
        return depenseRepository.getTotalDepenseLead();
    }
    @Override
    public List<Depense> findTicketsDepenses(){
        return depenseRepository.findTicketsDepenses();
    }
    @Override
    public List<Depense> findLeadsDepenses(){
        return depenseRepository.findLeadsDepenses();
    }
    @Override
    public List<Depense> rechercheMultiCritere(LocalDateTime dateDebut, LocalDateTime dateFin,Boolean leadNull,Boolean ticketNull){
//        Specification<Depense> spec = FiltreDepense.filter(dateDebut,dateFin,leadNull,ticketNull);
//        return depenseRepository.findAll(spec);
//        String sql = "SELECT * FROM depense WHERE lead_id IS NULL AND ticket_id IS NOT NULL";
//        return jdbcTemplate.query(sql, new BeanPropertyRowMapper<>(Depense.class));
        String queryString = "SELECT d FROM Depense d WHERE 1=1";
        if (dateDebut != null) {
            queryString += " AND d.dateDepense >= :valeurMin";
        }
        if (dateFin != null) {
            queryString += " AND d.dateDepense <= :valeurMax";
        }
        queryString+= " AND d.ticket IS NOT NULL";
        TypedQuery<Depense> query = entityManager.createQuery(queryString, Depense.class);

        if (dateDebut != null) {
            query.setParameter("valeurMin", dateDebut);
        }
        if (dateFin != null) {
            query.setParameter("valeurMax", dateFin);
        }

        return query.getResultList();
    }
}