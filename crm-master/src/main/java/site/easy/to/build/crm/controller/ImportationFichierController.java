package site.easy.to.build.crm.controller;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.multipart.MultipartFile;
import site.easy.to.build.crm.entity.Customer;
import site.easy.to.build.crm.service.csv.ImportationFichierService;

import java.util.ArrayList;
import java.util.List;

@Controller
@RequestMapping("/importation2")
public class ImportationFichierController {
    private final ImportationFichierService importationFichierService;

    public ImportationFichierController(ImportationFichierService importationFichierService) {
        this.importationFichierService = importationFichierService;
    }
    @GetMapping("/pageImportation")
    public String importForm(){
        return "csv/import2";
    }
    @PostMapping( "/importation")
    public String importCsv(MultipartFile file, Model model){
        try{
            List<Customer> customerList = new ArrayList<>();
            Customer customer1 = new Customer();
            Customer customer2 = new Customer();
            customer1.setEmail("customer1@yopmail.com");
            customer2.setEmail("mail2@test.com");
            customerList.add(customer1);
            customerList.add(customer2);
//            importationFichierService.importationFeuille1(file,';',customerList);
        }catch (Exception e){
            e.printStackTrace();
            model.addAttribute("messageError",e.getMessage());
        }
        return "csv/import2";
    }
}
