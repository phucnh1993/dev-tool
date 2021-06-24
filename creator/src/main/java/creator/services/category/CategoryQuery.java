package creator.services.category;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.TypedQuery;
import javax.persistence.criteria.CriteriaBuilder;

import org.springframework.stereotype.Service;

import creator.configs.ConstantConfig;
import creator.domains.entities.BasicType;
import creator.domains.entities.Database;
import creator.services.FilterRequest;
import creator.services.ResultData;
import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
public class CategoryQuery {
	@PersistenceContext
	final EntityManager entityManager;

	public <T> Long count(FilterRequest filter, Class<T> myClass) {
		CriteriaBuilder cb = entityManager.getCriteriaBuilder();
		return entityManager.createQuery(filter.CreateCount(cb, myClass)).getSingleResult();
	}
	
	public ResultData<List<CategoryResponse>> getBasicType(FilterRequest filter) {
		ResultData<List<CategoryResponse>> result = new ResultData<List<CategoryResponse>>();
		try {
			result.setData(new ArrayList<CategoryResponse>());
			CriteriaBuilder cb = entityManager.getCriteriaBuilder();
			result.setTotal(count(filter, BasicType.class));
			if (result.getTotal() > 0) {
				TypedQuery<BasicType> typedQuery = entityManager.createQuery(filter.CreateQuery(cb, BasicType.class))
						.setFirstResult(filter.getOffset()).setMaxResults(filter.getPageSize());
				List<BasicType> cmd = typedQuery.getResultList();
				List<CategoryResponse> data = new ArrayList<CategoryResponse>();
				for (int i = 0; i < cmd.size(); i++) {
					data.add(new CategoryResponse(cmd.get(i).getId(), cmd.get(i).getName()));
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
	
	public ResultData<List<CategoryResponse>> getDatabase(FilterRequest filter) {
		ResultData<List<CategoryResponse>> result = new ResultData<List<CategoryResponse>>();
		try {
			result.setData(new ArrayList<CategoryResponse>());
			CriteriaBuilder cb = entityManager.getCriteriaBuilder();
			result.setTotal(count(filter, Database.class));
			if (result.getTotal() > 0) {
				TypedQuery<Database> typedQuery = entityManager.createQuery(filter.CreateQuery(cb, Database.class))
						.setFirstResult(filter.getOffset()).setMaxResults(filter.getPageSize());
				List<Database> cmd = typedQuery.getResultList();
				List<CategoryResponse> data = new ArrayList<CategoryResponse>();
				for (int i = 0; i < cmd.size(); i++) {
					data.add(new CategoryResponse(cmd.get(i).getId(), cmd.get(i).getName()));
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
}
