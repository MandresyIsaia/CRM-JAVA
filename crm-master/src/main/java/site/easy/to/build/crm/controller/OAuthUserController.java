package site.easy.to.build.crm.controller;



import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import site.easy.to.build.crm.entity.Budget;
import site.easy.to.build.crm.entity.Role;
import site.easy.to.build.crm.repository.BudgetRepository;
import site.easy.to.build.crm.service.budget.BudgetService;

import java.util.List;


@RestController
@RequestMapping("/api/oauth")
public class OAuthUserController {
    private  final BudgetService budgetService;

    public OAuthUserController(BudgetService budgetService) {
        this.budgetService = budgetService;
    }

    @GetMapping("/test")
    public String test() {
        return "Testeeeeeeeeeeee";
    }

    @GetMapping("/budgets")
    public List<Budget> Budget() {

        return budgetService.findAll();
    }
    @PostMapping("/Prendrebudgets")
    public ResponseEntity<String> saveBudget(
            @RequestBody Role budget) {

        System.out.println("Budget reçu : " + budget.getId() + "€ pour le client " + budget.getName());

        return ResponseEntity.ok("Budget enregistré !");
    }
//    @PostMapping("/budgets")
//    public ResponseEntity<String> saveBudget(
//            @RequestBody Budget budget,
//            @CookieValue(value = "JSESSIONID", required = false) String sessionId) {
//
//        if (sessionId == null) {
//            return ResponseEntity.status(HttpStatus.UNAUTHORIZED).body("Session invalide !");
//        }
//
//        System.out.println("Session ID reçu : " + sessionId);
//        System.out.println("Budget reçu : " + budget.getValeur() + "€ pour le client " + budget.getCustomer().getName());
//
//        return ResponseEntity.ok("Budget enregistré !");
//    }

   
}
