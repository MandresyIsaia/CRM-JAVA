package site.easy.to.build.crm.controller;

import org.springframework.http.ResponseEntity;
import org.springframework.security.core.Authentication;
import org.springframework.web.bind.annotation.*;
import site.easy.to.build.crm.entity.*;
import site.easy.to.build.crm.entity.settings.ReponseJSON;
import site.easy.to.build.crm.repository.DepenseRepository;
import site.easy.to.build.crm.service.budget.BudgetService;
import site.easy.to.build.crm.service.customer.CustomerService;
import site.easy.to.build.crm.service.depense.DepenseService;
import site.easy.to.build.crm.service.lead.LeadService;
import site.easy.to.build.crm.service.seuil.SeuilService;
import site.easy.to.build.crm.service.ticket.TicketService;
import site.easy.to.build.crm.util.AuthenticationUtils;

import javax.swing.plaf.SeparatorUI;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/api/dashboard")
public class ApiDashboard {
    private final CustomerService customerService;
    private final LeadService leadService;
    private final TicketService ticketService;
    private final AuthenticationUtils authenticationUtils;
    private final DepenseService depenseService;

    private  final SeuilService seuilService;

    private final BudgetService budgetService;

    public ApiDashboard(CustomerService customerService, LeadService leadService, TicketService ticketService, AuthenticationUtils authenticationUtils, DepenseService depenseService, SeuilService seuilService, BudgetService budgetService) {
        this.customerService = customerService;
        this.leadService = leadService;
        this.ticketService = ticketService;
        this.authenticationUtils = authenticationUtils;
        this.depenseService = depenseService;
        this.seuilService = seuilService;
        this.budgetService = budgetService;
    }

    @GetMapping("/total")

    public @ResponseBody List<ReponseJSON> getTotaux(Authentication authentication){
        List<ReponseJSON> reponseJSONS = new ArrayList<>();
//        int userId = authenticationUtils.getLoggedInUserId(authentication);
//        reponseJSONS.add(new ReponseJSON("clients",customerService.countByUserId(userId)));
//        reponseJSONS.add(new ReponseJSON("leads",leadService.countByManagerId(userId)));
//        reponseJSONS.add(new ReponseJSON("leads" ,depenseService.findLeadsWithActiveDepenses().size()));
//        reponseJSONS.add(new ReponseJSON("leads confirmer" ,depenseService.getTotalLeadsActif()));
//        reponseJSONS.add(new ReponseJSON("tickets",ticketService.countByManagerId(userId)));
//        reponseJSONS.add(new ReponseJSON("tickets", depenseService.findTicketsWithActiveDepenses().size()));
//        reponseJSONS.add(new ReponseJSON("tickets confirmer", depenseService.getTotalTicketsActif()));
//        reponseJSONS.add(new ReponseJSON("clients",customerService.findAll().size()));
//        reponseJSONS.add(new ReponseJSON("leads",leadService.findAll().size()));
//        reponseJSONS.add(new ReponseJSON("tickets",ticketService.findAll().size()));
        reponseJSONS.add(new ReponseJSON("leads totals",depenseService.getTotalDepenseLead()));
        reponseJSONS.add(new ReponseJSON("Tickets Totals",depenseService.getTotalDepenseTicket()));
        reponseJSONS.add(new ReponseJSON("budgets",budgetService.getTotal()));
        return reponseJSONS;
    }
    @GetMapping("/customers")
    public List<Budget> getCustomers(Authentication authentication){
        List<Budget> customers = budgetService.findAll();
        System.out.println(customers.size());
//        int userId = authenticationUtils.getLoggedInUserId(authentication);
//        List<Customer> customers = customerService.findByUserId(userId);
        return customers;
    }

    @GetMapping("/tickets")
    public List<Depense> getTickets(Authentication authentication){
//        List<Ticket> leads = ticketService.findAll();
//        int userId = authenticationUtils.getLoggedInUserId(authentication);
        List<Depense> leads = depenseService.findTicketsWithActiveDepenses();
        return leads;
    }
    @GetMapping("/ticketsTous")
    public List<Depense> getTicketsTous(Authentication authentication){
//        List<Ticket> leads = ticketService.findAll();
//        int userId = authenticationUtils.getLoggedInUserId(authentication);
        List<Depense> leads = depenseService.findTicketsDepenses();
        return leads;
    }
    @GetMapping("/leads")
    public List<Depense> getLead(Authentication authentication){
//        List<Ticket> leads = ticketService.findAll();
//        int userId = authenticationUtils.getLoggedInUserId(authentication);
//        System.out.println(userId);
        List<Depense> leads = depenseService.findLeadsWithActiveDepenses();
        for (int i = 0; i < leads.size(); i++) {
            leads.get(i).getLead().setFiles(null);
            leads.get(i).getLead().setGoogleDriveFiles(null);
            leads.get(i).getLead().setGoogleDriveFiles(null);
        }
        return leads;
    }
    @GetMapping("/leadsTous")
    public List<Depense> getLeadTous(Authentication authentication){
//        List<Ticket> leads = ticketService.findAll();
//        int userId = authenticationUtils.getLoggedInUserId(authentication);
//        System.out.println(userId);
        List<Depense> leads = depenseService.findLeadsDepenses();
        for (int i = 0; i < leads.size(); i++) {
            leads.get(i).getLead().setFiles(null);
            leads.get(i).getLead().setGoogleDriveFiles(null);
            leads.get(i).getLead().setGoogleDriveFiles(null);
        }
        return leads;
    }

    @GetMapping("/leadsDashboard")
    public List<ReponseJSON> getDashboardLead(){
        LocalDate localDate = LocalDate.now();
        int year = localDate.getYear();
        List<ReponseJSON> reponseJSONS = new ArrayList<>();
        for (int i = 1; i <= 12; i++) {
            reponseJSONS.add(new ReponseJSON(String.valueOf(i), leadService.countByYearAndMonth(year,i)));
        }
        return reponseJSONS;
    }
    @PostMapping("/getModificationLead")
    public ResponseEntity<Depense> getmodificationLead(@RequestBody ReponseJSON reponseJSON){
//        Lead lead = leadService.findByLeadId((int) reponseJSON.getValeur());
//        lead.setFiles(null);
//        lead.setGoogleDriveFiles(null);
//        lead.setGoogleDriveFiles(null);
        Depense depense = depenseService.getDepenseById((int) reponseJSON.getValeur()).get();
        depense.getLead().setFiles(null);
        depense.getLead().setGoogleDriveFiles(null);
        depense.getLead().setGoogleDriveFiles(null);
        return ResponseEntity.ok(depense);
    }
    @PostMapping("/modificationLead")
    public ResponseEntity<String> modificationLead(@RequestBody ReponseJSON reponseJSON){
//        Lead lead = leadService.findByLeadId((int) reponseJSON.getValeur());
//        lead.setName(reponseJSON.getNom());
//        leadService.save(lead);
        Depense depense  = depenseService.getDepenseById(Integer.parseInt(reponseJSON.getNom())).get();
        depense.setValeurDepense(reponseJSON.getValeur());
        depenseService.saveDepense(depense);
        return ResponseEntity.ok("Modification effectuer avec succes");
    }
    @PostMapping("/deleteLead")
    public ResponseEntity<String> deleteLead(@RequestBody ReponseJSON reponseJSON){
//        Lead lead = leadService.findByLeadId((int) reponseJSON.getValeur());
//        leadService.delete(lead);
        Depense depense  = depenseService.getDepenseById((int) reponseJSON.getValeur()).get();
        depenseService.delete(depense);
        return ResponseEntity.ok("Suppression effectuer avec succes");
    }
    @PostMapping("/getModificationTicket")
    public ResponseEntity<Depense> getModificationTicket(@RequestBody ReponseJSON reponseJSON){
//        Lead lead = leadService.findByLeadId((int) reponseJSON.getValeur());
//        lead.setFiles(null);
//        lead.setGoogleDriveFiles(null);
//        lead.setGoogleDriveFiles(null);
        Depense depense = depenseService.getDepenseById((int) reponseJSON.getValeur()).get();
        return ResponseEntity.ok(depense);
    }
    @PostMapping("/modificationTicket")
    public ResponseEntity<String> modificationTicket(@RequestBody ReponseJSON reponseJSON){
//        Lead lead = leadService.findByLeadId((int) reponseJSON.getValeur());
//        lead.setName(reponseJSON.getNom());
//        leadService.save(lead);
        Depense depense  = depenseService.getDepenseById(Integer.parseInt(reponseJSON.getNom())).get();
        depense.setValeurDepense(reponseJSON.getValeur());
        depenseService.saveDepense(depense);
        return ResponseEntity.ok("Modification effectuer avec succes");
    }
    @PostMapping("/deleteTicket")
    public ResponseEntity<String> deleteTicket(@RequestBody ReponseJSON reponseJSON){
//        Lead lead = leadService.findByLeadId((int) reponseJSON.getValeur());
//        leadService.delete(lead);
        Depense depense  = depenseService.getDepenseById((int) reponseJSON.getValeur()).get();
        depenseService.delete(depense);
        return ResponseEntity.ok("Suppression effectuer avec succes");
    }
    @GetMapping("/ticketsDashboard")
    public List<ReponseJSON> getDashboardTicket(){
        LocalDate localDate = LocalDate.now();
        int year = localDate.getYear();
        List<ReponseJSON> reponseJSONS = new ArrayList<>();
        for (int i = 1; i <= 12; i++) {
            reponseJSONS.add(new ReponseJSON(String.valueOf(i), ticketService.countByYearAndMonth(year,i)));
//            System.out.println( budgetService.countByYearAndMonth(year,i));
//            reponseJSONS.add(new ReponseJSON(String.valueOf(i), budgetService.countByYearAndMonth(year,i)));
        }
        return reponseJSONS;
    }
    @GetMapping("/ticketsTypeDashboard")
    public List<ReponseJSON> getTicketType(){
        List<ReponseJSON> reponseJSONS = new ArrayList<>();

//        reponseJSONS.add(new ReponseJSON("ticket confirmer", ticketService.findTicketsWithActiveDepenses().size()));
//        reponseJSONS.add(new ReponseJSON("ticket en attente", ticketService.findTicketsWithEnAttenteDepenses().size()));
//        reponseJSONS.add(new ReponseJSON("ticket refused", ticketService.findTicketsWithRefusedDepenses().size()));
        List<Customer> customerList = customerService.findAll();
        for (int i = 0; i < customerList.size(); i++) {
            double nombre =budgetService.getTotalBudgetByCustomerId(customerList.get(i).getCustomerId());
            reponseJSONS.add(new ReponseJSON(customerList.get(i).getName(), nombre));
        }

        return reponseJSONS;
    }
    @GetMapping("/seuils")
    public List<Seuil> getSeuil(Authentication authentication){
        List<Seuil> leads = seuilService.getAllSeuils();
        return leads;
    }
    @PostMapping("/getModificationSeuil")
    public ResponseEntity<Seuil> getModificationSeuil(@RequestBody ReponseJSON reponseJSON){
//        Lead lead = leadService.findByLeadId((int) reponseJSON.getValeur());
//        lead.setFiles(null);
//        lead.setGoogleDriveFiles(null);
//        lead.setGoogleDriveFiles(null);
        Seuil seuil = seuilService.getSeuilById((int) reponseJSON.getValeur()).get();
        return ResponseEntity.ok(seuil);
    }
    @PostMapping("/modificationSeuil")
    public ResponseEntity<String> modificationSeuil(@RequestBody ReponseJSON reponseJSON){
//        Lead lead = leadService.findByLeadId((int) reponseJSON.getValeur());
//        lead.setName(reponseJSON.getNom());
//        leadService.save(lead);
        Seuil seuil =  seuilService.getSeuilById(Integer.parseInt(reponseJSON.getNom())).get();
        seuil.setTaux(BigDecimal.valueOf(reponseJSON.getValeur()));
        seuilService.addSeuil(seuil);
        return ResponseEntity.ok("Modification effectuer avec succes");
    }
    @PostMapping("/multicritereDepenseTicket")
    public List<Depense> getCriteriaDepense(@RequestBody List<ReponseJSON> reponseJSONS){
        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd/MM/yyyy HH:mm:ss");

        LocalDateTime dateDebut = LocalDateTime.parse(reponseJSONS.get(0).getNom(), formatter);
        LocalDateTime dateFin = LocalDateTime.parse(reponseJSONS.get(1).getNom(), formatter);
        Boolean lead = Boolean.FALSE;
        Boolean ticket = Boolean.TRUE;
        return depenseService.rechercheMultiCritere(dateDebut,dateFin,lead,ticket);
    }


}
