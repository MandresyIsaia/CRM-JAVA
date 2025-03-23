package site.easy.to.build.crm.repository;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import site.easy.to.build.crm.entity.Customer;
import site.easy.to.build.crm.entity.Ticket;

import java.util.List;

@Repository
public interface TicketRepository extends JpaRepository<Ticket, Integer> {
    public Ticket findByTicketId(int ticketId);

    public List<Ticket> findByManagerId(int id);

    public List<Ticket> findByEmployeeId(int id);

    List<Ticket> findByCustomerCustomerId(Integer customerId);

    List<Ticket> findByManagerIdOrderByCreatedAtDesc(int managerId, Pageable pageable);

    List<Ticket> findByEmployeeIdOrderByCreatedAtDesc(int managerId, Pageable pageable);

    List<Ticket> findByCustomerCustomerIdOrderByCreatedAtDesc(int customerId, Pageable pageable);

    long countByEmployeeId(int employeeId);

    long countByManagerId(int managerId);

    long countByCustomerCustomerId(int customerId);

    void deleteAllByCustomer(Customer customer);
    @Query("SELECT COUNT(l) FROM Ticket l WHERE YEAR(l.createdAt) = :year AND month (l.createdAt) = :month")
    long countByYearAndMonth(@Param("year") int year, @Param("month") int month);

    @Query("SELECT DISTINCT d.ticket FROM Depense d WHERE d.etat = 1 AND d.ticket IS NOT NULL")
    List<Ticket> findTicketsWithActiveDepenses();

    @Query("SELECT DISTINCT d.ticket FROM Depense d where d.etat = 0 and d.ticket IS NOT null")
    List<Ticket> findTicketsWithEnAttenteDepenses();

    @Query("SELECT DISTINCT d.ticket FROM Depense d where d.etat = -1 and d.ticket IS NOT null")
    List<Ticket> findTicketsWithRefusedDepenses();
}
