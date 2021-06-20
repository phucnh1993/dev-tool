package creator.services.application;

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

import creator.configs.ConstantConfig;
import creator.domains.entities.Application;
import creator.services.FilterRequest;
import creator.services.ResultData;
import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
public class ApplicationQuery {
	@PersistenceContext
	final EntityManager entityManager;

	public Long count(FilterRequest filter) {
		CriteriaBuilder cb = entityManager.getCriteriaBuilder();
		return entityManager.createQuery(filter.CreateCount(cb, Application.class)).getSingleResult();
	}

	public ResultData<List<ApplicationResponse>> getAll(FilterRequest filter) {
		ResultData<List<ApplicationResponse>> result = new ResultData<List<ApplicationResponse>>();
		try {
			result.setData(new ArrayList<ApplicationResponse>());
			CriteriaBuilder cb = entityManager.getCriteriaBuilder();
			result.setTotal(count(filter));
			if (result.getTotal() > 0) {
				TypedQuery<Application> typedQuery = entityManager.createQuery(filter.CreateQuery(cb, Application.class))
						.setFirstResult(filter.getOffset()).setMaxResults(filter.getPageSize());
				List<Application> cmd = typedQuery.getResultList();
				List<ApplicationResponse> data = new ArrayList<ApplicationResponse>();
				for (int i = 0; i < cmd.size(); i++) {
					data.add(new ApplicationResponse(cmd.get(i).getId()
							, cmd.get(i).getName()
							, cmd.get(i).getDescription()
							, cmd.get(i).isActivated()
							, cmd.get(i).getBasicType().getId()
							, cmd.get(i).getTypeName()
							, cmd.get(i).getDatabaseDev().getId()
							, cmd.get(i).getDatabaseUat().getId()));
				}
				result.setData(data);
			}
		} catch (Exception ex) {
			System.out.println(ex.getMessage());
			result.setErrorCode(ConstantConfig.QUERY_DATA_ERROR);
			result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.QUERY_DATA_ERROR));
		}
		return result;
	}
	
	public ResultData<Application> getDetail(BigInteger id) {
		ResultData<Application> result = new ResultData<Application>();
		try {
			CriteriaBuilder cb = entityManager.getCriteriaBuilder();
			CriteriaQuery<Application> query = cb.createQuery(Application.class);
			Root<Application> root = query.from(Application.class);
			query.where(cb.equal(root.get("id"), id));
			TypedQuery<Application> typedQuery = entityManager.createQuery(query);
			result.setData(typedQuery.getSingleResult());
			if (result.getData() != null) {
				result.setTotal(1);
			}
		} catch (Exception ex) {
			System.out.println(ex.getMessage());
			result.setErrorCode(ConstantConfig.QUERY_DATA_ERROR);
			result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.QUERY_DATA_ERROR));
		}
		return result;
	}
}
