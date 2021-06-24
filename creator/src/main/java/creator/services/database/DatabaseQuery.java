package creator.services.database;

import java.math.BigInteger;
import java.nio.charset.StandardCharsets;
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
import creator.domains.entities.Database;
import creator.services.FilterRequest;
import creator.services.ResultData;
import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
public class DatabaseQuery {
	@PersistenceContext
	final EntityManager entityManager;

	public <T> Long count(FilterRequest filter, Class<T> myClass) {
		CriteriaBuilder cb = entityManager.getCriteriaBuilder();
		return entityManager.createQuery(filter.CreateCount(cb, myClass)).getSingleResult();
	}

	public ResultData<List<DatabaseResponse>> getAll(FilterRequest filter) {
		ResultData<List<DatabaseResponse>> result = new ResultData<List<DatabaseResponse>>();
		try {
			result.setData(new ArrayList<DatabaseResponse>());
			CriteriaBuilder cb = entityManager.getCriteriaBuilder();
			result.setTotal(count(filter, Database.class));
			if (result.getTotal() > 0) {
				TypedQuery<Database> typedQuery = entityManager.createQuery(filter.CreateQuery(cb, Database.class))
						.setFirstResult(filter.getOffset()).setMaxResults(filter.getPageSize());
				List<Database> cmd = typedQuery.getResultList();
				List<DatabaseResponse> data = new ArrayList<DatabaseResponse>();
				for (int i = 0; i < cmd.size(); i++) {
					data.add(new DatabaseResponse(cmd.get(i).getId()
							, cmd.get(i).getName()
							, cmd.get(i).getDescription()
							, cmd.get(i).isActivated()
							, cmd.get(i).getBasicType().getId()
							, cmd.get(i).getTypeName()
							, cmd.get(i).getIpAddressV4()
							, cmd.get(i).getIpAddressV6()
							, cmd.get(i).getPort()
							, cmd.get(i).getUsername()
							, new String(cmd.get(i).getPassword(), StandardCharsets.UTF_8)));
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
	
	public ResultData<Database> getDetail(BigInteger id) {
		ResultData<Database> result = new ResultData<Database>();
		try {
			CriteriaBuilder cb = entityManager.getCriteriaBuilder();
			CriteriaQuery<Database> query = cb.createQuery(Database.class);
			Root<Database> root = query.from(Database.class);
			query.where(cb.equal(root.get("id"), id));
			TypedQuery<Database> typedQuery = entityManager.createQuery(query);
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
