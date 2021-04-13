package services.language;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.TypedQuery;
import javax.persistence.criteria.CriteriaBuilder;

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

	public Long count(FilterRequest filter) {
		CriteriaBuilder cb = entityManager.getCriteriaBuilder();
		return entityManager.createQuery(filter.CreateCount(cb, Language.class)).getSingleResult();
	}

	public ResultData<List<Language>> getAll(FilterRequest filter) {
		ResultData<List<Language>> result = new ResultData<List<Language>>();
		result.setData(new ArrayList<Language>());
		result.setErrorCode(ConstantConfig.SUCCESS);
		result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.SUCCESS));
		CriteriaBuilder cb = entityManager.getCriteriaBuilder();
		result.setTotal(count(filter));
		if (result.getTotal() > 0) {
			TypedQuery<Language> typedQuery = entityManager.createQuery(filter.CreateQuery(cb, Language.class)).setFirstResult(filter.getOffset())
					.setMaxResults(filter.getPageSize());
			result.setData(typedQuery.getResultList());
		}
		return result;
	}
}
