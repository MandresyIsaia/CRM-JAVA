package site.easy.to.build.crm.repository;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import site.easy.to.build.crm.entity.User;

import java.util.List;

@Repository
public interface UserRepository extends JpaRepository<User, Integer> {

    public User findById(int id);

    public List<User> findByUsername(String username);

    public User findByEmail(String email);

    public void deleteById(int id);

    public List<User> findAll();

    public User findByToken(String token);

    long count();

    public List<User> findTopNByOrderByCreatedAtDesc(int limit, Pageable pageable);

    @Query("SELECT u FROM User u JOIN u.roles r WHERE r.id = :roleId")
    List<User> findUsersByRoleId(@Param("roleId") int roleid);
}
