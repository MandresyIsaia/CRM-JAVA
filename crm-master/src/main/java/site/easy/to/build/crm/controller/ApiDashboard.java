package site.easy.to.build.crm.controller;

import org.springframework.http.ResponseEntity;
import org.springframework.security.core.Authentication;
import org.springframework.web.bind.annotation.*;
import site.easy.to.build.crm.entity.Customer;
import site.easy.to.build.crm.entity.Lead;
import site.easy.to.build.crm.entity.Ticket;
import site.easy.to.build.crm.entity.settings.ReponseJSON;
import site.easy.to.build.crm.service.customer.CustomerService;
import site.easy.to.build.crm.service.lead.LeadService;
import site.easy.to.build.crm.service.ticket.TicketService;
import site.easy.to.build.crm.util.AuthenticationUtils;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/api/dashboard")
public class ApiDashboard {
    private final CustomerService customerService;
    private final LeadService leadService;
    private final TicketService ticketService;
    private final AuthenticationUtils authenticationUtils;

    public ApiDashboard(CustomerService customerService, LeadService leadService, TicketService ticketService, AuthenticationUtils authenticationUtils) {
        this.customerService = customerService;
        this.leadService = leadService;
        this.ticketService = ticketService;
        this.authenticationUtils = authenticationUtils;
    }

    @GetMapping("/total")
    public List<ReponseJSON> getTotaux(Authentication authentication){
        List<ReponseJSON> reponseJSONS = new ArrayList<>();
        int userId = authenticationUtils.getLoggedInUserId(authentication);
        reponseJSONS.add(new ReponseJSON("clients",customerService.countByUserId(userId)));
        reponseJSONS.add(new ReponseJSON("leads",leadService.countByManagerId(userId)));
        reponseJSONS.add(new ReponseJSON("tickets",ticketService.countByManagerId(userId)));

//        reponseJSONS.add(new ReponseJSON("clients",customerService.findAll().size()));
//        reponseJSONS.add(new ReponseJSON("leads",leadService.findAll().size()));
//        reponseJSONS.add(new ReponseJSON("tickets",ticketService.findAll().size()));
        return reponseJSONS;
    }
    @GetMapping("/customers")
    public List<Customer> getCustomers(Authentication authentication){
//        List<Customer> customers = customerService.findAll();
        int userId = authenticationUtils.getLoggedInUserId(authentication);
        List<Customer> customers = customerService.findByUserId(userId);
        return customers;
    }

    @GetMapping("/tickets")
    public List<Ticket> getTickets(Authentication authentication){
//        List<Ticket> leads = ticketService.findAll();
        int userId = authenticationUtils.getLoggedInUserId(authentication);
        List<Ticket> leads = ticketService.findManagerTickets(userId);
        return leads;
    }
    @GetMapping("/leads")
    public List<Lead> getLead(Authentication authentication){
//        List<Ticket> leads = ticketService.findAll();
        int userId = authenticationUtils.getLoggedInUserId(authentication);
        System.out.println(userId);
        List<Lead> leads = leadService.findCreatedLeads(userId);
        for (int i = 0; i < leads.size(); i++) {
            leads.get(i).setFiles(null);
            leads.get(i).setGoogleDriveFiles(null);
            leads.get(i).setGoogleDriveFiles(null);
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
    public ResponseEntity<Lead> getmodificationLead(@RequestBody ReponseJSON reponseJSON){
        Lead lead = leadService.findByLeadId((int) reponseJSON.getValeur());
        lead.setFiles(null);
        lead.setGoogleDriveFiles(null);
        lead.setGoogleDriveFiles(null);
        return ResponseEntity.ok(lead);
    }
    @PostMapping("/modificationLead")
    public ResponseEntity<String> modificationLead(@RequestBody ReponseJSON reponseJSON){
        Lead lead = leadService.findByLeadId((int) reponseJSON.getValeur());
        lead.setName(reponseJSON.getNom());
        leadService.save(lead);
        return ResponseEntity.ok("Modification effectuer avec succes");
    }
    @PostMapping("/deleteLead")
    public ResponseEntity<String> deleteLead(@RequestBody ReponseJSON reponseJSON){
        Lead lead = leadService.findByLeadId((int) reponseJSON.getValeur());
        leadService.delete(lead);
        return ResponseEntity.ok("Suppression effectuer avec succes");
    }
}
