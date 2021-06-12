package creator.services.basicType;

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

import lombok.RequiredArgsConstructor;

import creator.domains.entities.BasicType;
import creator.configs.ConstantConfig;
import creator.services.FilterRequest;
import creator.services.ResultData;

@Service
@RequiredArgsConstructor
public class BasicTypeQuery {
	@PersistenceContext
	final EntityManager entityManager;

	public Long count(FilterRequest filter) {
		CriteriaBuilder cb = entityManager.getCriteriaBuilder();
		return entityManager.createQuery(filter.CreateCount(cb, BasicType.class)).getSingleResult();
	}

	public ResultData<List<BasicTypeResponse>> getAll(FilterRequest filter) {
		ResultData<List<BasicTypeResponse>> result = new ResultData<List<BasicTypeResponse>>();
		try {
			result.setData(new ArrayList<BasicTypeResponse>());
			CriteriaBuilder cb = entityManager.getCriteriaBuilder();
			result.setTotal(count(filter));
			if (result.getTotal() > 0) {
				TypedQuery<BasicType> typedQuery = entityManager.createQuery(filter.CreateQuery(cb, BasicType.class))
						.setFirstResult(filter.getOffset()).setMaxResults(filter.getPageSize());
				List<BasicType> cmd = typedQuery.getResultList();
				List<BasicTypeResponse> data = new ArrayList<BasicTypeResponse>();
				for (int i = 0; i < cmd.size(); i++) {
					data.add(new BasicTypeResponse(cmd.get(i).getId(), cmd.get(i).getName(), cmd.get(i).getDescription(), cmd.get(i).getSort()));
				}
				result.setData(data);
			}
		} catch (Exception ex) {
			result.setErrorCode(ConstantConfig.QUERY_DATA_ERROR);
			result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.QUERY_DATA_ERROR));
		}
		return result;
	}
	
	public ResultData<BasicType> getDetail(BigInteger id) {
		ResultData<BasicType> result = new ResultData<BasicType>();
		try {
			CriteriaBuilder cb = entityManager.getCriteriaBuilder();
			CriteriaQuery<BasicType> query = cb.createQuery(BasicType.class);
			Root<BasicType> root = query.from(BasicType.class);
			query.where(cb.equal(root.get("id"), id));
			TypedQuery<BasicType> typedQuery = entityManager.createQuery(query);
			result.setData(typedQuery.getSingleResult());
			if (result.getData() != null) {
				result.setTotal(1);
			}
		} catch (Exception ex) {
			result.setErrorCode(ConstantConfig.QUERY_DATA_ERROR);
			result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.QUERY_DATA_ERROR));
		}
		return result;
	}
}
