package site.easy.to.build.crm.controller;



import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.core.Authentication;
import org.springframework.web.bind.annotation.*;
import site.easy.to.build.crm.entity.Budget;
import site.easy.to.build.crm.entity.Role;
import site.easy.to.build.crm.entity.settings.ReponseJSON;
import site.easy.to.build.crm.repository.BudgetRepository;
import site.easy.to.build.crm.service.budget.BudgetService;
import site.easy.to.build.crm.service.customer.CustomerService;
import site.easy.to.build.crm.service.depense.DepenseService;
import site.easy.to.build.crm.service.lead.LeadService;
import site.easy.to.build.crm.service.seuil.SeuilService;
import site.easy.to.build.crm.service.ticket.TicketService;
import site.easy.to.build.crm.util.AuthenticationUtils;

import java.util.ArrayList;
import java.util.List;


@RestController
@RequestMapping("api/oauth")
public class OAuthUserController {
    private  final BudgetService budgetService;

    private final CustomerService customerService;
    private final LeadService leadService;
    private final TicketService ticketService;
    private final AuthenticationUtils authenticationUtils;
    private final DepenseService depenseService;

    private  final SeuilService seuilService;

    public OAuthUserController(BudgetService budgetService, CustomerService customerService, LeadService leadService, TicketService ticketService, AuthenticationUtils authenticationUtils, DepenseService depenseService, SeuilService seuilService) {
        this.budgetService = budgetService;
        this.customerService = customerService;
        this.leadService = leadService;
        this.ticketService = ticketService;
        this.authenticationUtils = authenticationUtils;
        this.depenseService = depenseService;
        this.seuilService = seuilService;
    }

    @GetMapping("/test")
    public String test() {
        return "Testeeeeeeeeeeee";
    }

    @GetMapping("/total")
    public  String getTotaux(Authentication authentication){
        List<ReponseJSON> reponseJSONS = new ArrayList<>();
        int userId = authenticationUtils.getLoggedInUserId(authentication);
//        reponseJSONS.add(new ReponseJSON("clients",customerService.countByUserId(userId)));
        reponseJSONS.add(new ReponseJSON("leads",leadService.countByManagerId(userId)));
        reponseJSONS.add(new ReponseJSON("leads" ,depenseService.findLeadsWithActiveDepenses().size()));
//        reponseJSONS.add(new ReponseJSON("tickets",ticketService.countByManagerId(userId)));
        reponseJSONS.add(new ReponseJSON("tickets", depenseService.findTicketsWithActiveDepenses().size()));
//        reponseJSONS.add(new ReponseJSON("clients",customerService.findAll().size()));
//        reponseJSONS.add(new ReponseJSON("leads",leadService.findAll().size()));
//        reponseJSONS.add(new ReponseJSON("tickets",ticketService.findAll().size()));
//        return reponseJSONS;
        return "Verai";

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
