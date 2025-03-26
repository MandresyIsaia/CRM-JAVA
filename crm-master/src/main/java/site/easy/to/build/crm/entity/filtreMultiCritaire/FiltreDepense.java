package site.easy.to.build.crm.entity.filtreMultiCritaire;

import jakarta.persistence.criteria.CriteriaBuilder;
import jakarta.persistence.criteria.CriteriaQuery;
import jakarta.persistence.criteria.Predicate;
import jakarta.persistence.criteria.Root;
import org.springframework.data.jpa.domain.Specification;
import site.easy.to.build.crm.entity.Depense;

import java.time.LocalDateTime;

public class FiltreDepense {
    public static Specification<Depense> filter(LocalDateTime dateDebut, LocalDateTime dateFin, Boolean leadNull, Boolean ticketNotNull){
        return (Root<Depense> root, CriteriaQuery<?> query, CriteriaBuilder cb) -> {
            Predicate predicate = cb.conjunction();
//            if (nom != null && !nom.isEmpty()) {
//                predicate = cb.and(predicate, cb.like(root.get("nom"), "%" + nom + "%"));
//            }
//            if (categorie != null && !categorie.isEmpty()) {
//                predicate = cb.and(predicate, cb.equal(root.get("categorie"), categorie));
//            }
//            if (prixMin != null) {
//                predicate = cb.and(predicate, cb.greaterThanOrEqualTo(root.get("prix"), prixMin));
//            }
//            if (prixMax != null) {
//                predicate = cb.and(predicate, cb.lessThanOrEqualTo(root.get("prix"), prixMax));
//            }
            if (Boolean.TRUE.equals(leadNull)) {
                predicate = cb.and(predicate, cb.isNull(root.get("lead")));
            }
            if (Boolean.TRUE.equals(ticketNotNull)) {
                predicate = cb.and(predicate, cb.isNotNull(root.get("ticket")));
            }
            if (dateDebut != null) {
                predicate = cb.and(predicate, cb.greaterThanOrEqualTo(root.get("dateDepense"), dateDebut));
            }
            if (dateFin != null) {
                predicate = cb.and(predicate, cb.lessThanOrEqualTo(root.get("dateDepense"), dateFin));
            }

            return predicate;
        };
    }
}
