package creator.services.dataType;

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
import creator.domains.entities.DataType;
import creator.services.FilterRequest;
import creator.services.ResultData;
import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
public class DataTypeQuery {
	@PersistenceContext
	final EntityManager entityManager;

	public <T> Long count(FilterRequest filter, Class<T> myClass) {
		CriteriaBuilder cb = entityManager.getCriteriaBuilder();
		return entityManager.createQuery(filter.CreateCount(cb, myClass)).getSingleResult();
	}

	public ResultData<List<DataTypeResponse>> getAll(FilterRequest filter) {
		ResultData<List<DataTypeResponse>> result = new ResultData<List<DataTypeResponse>>();
		try {
			result.setData(new ArrayList<DataTypeResponse>());
			CriteriaBuilder cb = entityManager.getCriteriaBuilder();
			result.setTotal(count(filter, DataType.class));
			if (result.getTotal() > 0) {
				TypedQuery<DataType> typedQuery = entityManager.createQuery(filter.CreateQuery(cb, DataType.class))
						.setFirstResult(filter.getOffset()).setMaxResults(filter.getPageSize());
				List<DataType> cmd = typedQuery.getResultList();
				List<DataTypeResponse> data = new ArrayList<DataTypeResponse>();
				for (int i = 0; i < cmd.size(); i++) {
					data.add(new DataTypeResponse(cmd.get(i).getId()
							, cmd.get(i).getGroupType().getId()
							, cmd.get(i).getGroupName()
							, cmd.get(i).getCodeType().getId()
							, cmd.get(i).getCodeName()
							, cmd.get(i).getName()
							, cmd.get(i).getDescription()
							, cmd.get(i).getSort()
							, cmd.get(i).isActivated()));
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
	
	public ResultData<DataType> getDetail(BigInteger id) {
		ResultData<DataType> result = new ResultData<DataType>();
		try {
			CriteriaBuilder cb = entityManager.getCriteriaBuilder();
			CriteriaQuery<DataType> query = cb.createQuery(DataType.class);
			Root<DataType> root = query.from(DataType.class);
			query.where(cb.equal(root.get("id"), id));
			TypedQuery<DataType> typedQuery = entityManager.createQuery(query);
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
