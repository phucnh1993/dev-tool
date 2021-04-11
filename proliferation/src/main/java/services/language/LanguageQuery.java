package services.language;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.TypedQuery;
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

import org.springframework.stereotype.Service;

import configs.ConstantConfig;
import databases.entities.Language;
import lombok.RequiredArgsConstructor;
import requests.FilterRequest;
import responses.ResultData;

@Service
@RequiredArgsConstructor
public class LanguageQuery {
	@PersistenceContext
	final EntityManager entityManager;

	public ResultData<List<Language>> getAll(FilterRequest filter) {
		ResultData<List<Language>> result = new ResultData<List<Language>>();
		result.setData(new ArrayList<Language>());
		result.setErrorCode(ConstantConfig.SUCCESS);
		result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.SUCCESS));
		CriteriaBuilder criteriaBuilder = entityManager.getCriteriaBuilder();
		CriteriaQuery<Language> criteriaQuery = criteriaBuilder.createQuery(Language.class);
		CriteriaQuery<Long> countQuery = criteriaBuilder.createQuery(Long.class);
		List<Predicate> predicates = new ArrayList<Predicate>();
		// Tạo root của câu query
		Root<Language> root = criteriaQuery.from(Language.class);
		if (filter.getKeyWords() != null && !filter.getKeyWords().trim().isEmpty()) {
			Predicate condition = criteriaBuilder.like(countQuery.from(Language.class).get("Name"),
					filter.getKeyWords() + "%");
			predicates.add(condition);
		}
		if (filter.getFrom() != null && !filter.getFrom().trim().isEmpty()) {
			Predicate condition = criteriaBuilder
					.greaterThanOrEqualTo(countQuery.from(Language.class).get("ModifiedOn"), filter.getFrom());
			predicates.add(condition);
		}
		if (filter.getTo() != null && !filter.getTo().trim().isEmpty()) {
			Predicate condition = criteriaBuilder.lessThanOrEqualTo(countQuery.from(Language.class).get("ModifiedOn"),
					filter.getTo());
			predicates.add(condition);
		}

		// Tạo câu truy vấn
		CriteriaQuery<Language> select = criteriaQuery.select(root);

		// Đếm giá trị của câu query
		countQuery.select(criteriaBuilder.count(root));

		// countQuery.where(criteriaBuilder.like(countQuery.from(Language.class).get("Name"),
		// filter.getKeyWords() + "%"));
		if (predicates.size() > 0) {
			predicates.forEach((element) -> {
				countQuery.where(criteriaBuilder.and(element));
			});
		}

		result.setTotal(entityManager.createQuery(countQuery).getSingleResult());
		if (result.getTotal() > 0) {

			TypedQuery<Language> typedQuery = entityManager.createQuery(select).setFirstResult(filter.getOffset())
					.setMaxResults(filter.getPageSize());
			result.setData(typedQuery.getResultList());
		}
		return result;
	}
}
