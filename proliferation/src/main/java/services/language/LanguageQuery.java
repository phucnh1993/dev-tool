package services.language;

import java.math.BigInteger;
import java.util.ArrayList;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.TypedQuery;
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
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

	public Long count(FilterRequest filter) {
		CriteriaBuilder cb = entityManager.getCriteriaBuilder();
		return entityManager.createQuery(filter.CreateCount(cb, Language.class)).getSingleResult();
	}

	public ResultData<List<LanguagesResponse>> getAll(FilterRequest filter) {
		ResultData<List<LanguagesResponse>> result = new ResultData<List<LanguagesResponse>>();
		result.setData(new ArrayList<LanguagesResponse>());
		result.setErrorCode(ConstantConfig.SUCCESS);
		result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.SUCCESS));
		CriteriaBuilder cb = entityManager.getCriteriaBuilder();
		result.setTotal(count(filter));
		if (result.getTotal() > 0) {
			TypedQuery<Language> typedQuery = entityManager.createQuery(filter.CreateQuery(cb, Language.class)).setFirstResult(filter.getOffset())
					.setMaxResults(filter.getPageSize());
			List<Language> languages = typedQuery.getResultList();
			List<LanguagesResponse> data = new ArrayList<LanguagesResponse>();
			for (int i = 0; i < languages.size(); i++) {
				data.add(new LanguagesResponse(languages.get(i).getId(), languages.get(i).getName(), languages.get(i).getVersion()));
			}
			result.setData(data);
		}
		return result;
	}
	
	public ResultData<Language> getDetail(BigInteger id) {
		ResultData<Language> result = new ResultData<Language>();
		result.setErrorCode(ConstantConfig.SUCCESS);
		result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.SUCCESS));
		CriteriaBuilder cb = entityManager.getCriteriaBuilder();
		CriteriaQuery<Language> query = cb.createQuery(Language.class);
		Root<Language> root = query.from(Language.class);
		query.where(cb.equal(root.get("id"), id));
		TypedQuery<Language> typedQuery = entityManager.createQuery(query);
		result.setData(typedQuery.getSingleResult());
		if (result.getData() != null) {
			result.setTotal(1);
		}
		return result;
	}
}
