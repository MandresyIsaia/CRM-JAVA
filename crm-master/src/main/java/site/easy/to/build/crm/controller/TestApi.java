package site.easy.to.build.crm.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import site.easy.to.build.crm.entity.Role;
import site.easy.to.build.crm.service.role.RoleService;

import java.util.List;

@RestController
@RequestMapping("/api/users")
public class TestApi {
    private final RoleService roleService;
    public TestApi(RoleService roleService){
        this.roleService = roleService;
    }
    @GetMapping(name = "roles")
    public List<Role> getAllUser(){
        return roleService.getAllRoles();
    }
}
