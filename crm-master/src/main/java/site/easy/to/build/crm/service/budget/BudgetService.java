package site.easy.to.build.crm.service.budget;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import site.easy.to.build.crm.entity.Budget;
import site.easy.to.build.crm.repository.BudgetRepository;

import java.util.List;
import java.util.Optional;

@Service
public class BudgetService {
    @Autowired
    private BudgetRepository budgetRepository;
    public List<Budget> findAll(){
        return budgetRepository.findAll();
    }
    public Optional<Budget> findById(int id){
        return budgetRepository.findById(id);
    }
    public Budget save(Budget budget){
        return budgetRepository.save(budget);
    }
    public void delete(int id){
        budgetRepository.deleteById(id);
    }
    public List<Budget> findByCustomerId(int customerId){
        return budgetRepository.findByCustomerCustomerId(customerId);
    }
    public double getTotalBudgetByCustomerId(int customerId) {
        return budgetRepository.getTotalBudgetByCustomerId(customerId);
    }

}
