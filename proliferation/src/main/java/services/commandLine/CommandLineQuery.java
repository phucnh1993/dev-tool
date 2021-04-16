package services.commandLine;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.TypedQuery;
import javax.persistence.criteria.CriteriaBuilder;

import org.springframework.stereotype.Service;

import configs.ConstantConfig;
import databases.entities.CommandLine;
import lombok.RequiredArgsConstructor;
import services.FilterRequest;
import services.ResultData;

@Service
@RequiredArgsConstructor
public class CommandLineQuery {
	@PersistenceContext
	final EntityManager entityManager;

	public Long count(FilterRequest filter) {
		CriteriaBuilder cb = entityManager.getCriteriaBuilder();
		return entityManager.createQuery(filter.CreateCount(cb, CommandLine.class)).getSingleResult();
	}

	public ResultData<List<CommandLine>> getAll(FilterRequest filter) {
		ResultData<List<CommandLine>> result = new ResultData<List<CommandLine>>();
		result.setData(new ArrayList<CommandLine>());
		result.setErrorCode(ConstantConfig.SUCCESS);
		result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.SUCCESS));
		CriteriaBuilder cb = entityManager.getCriteriaBuilder();
		result.setTotal(count(filter));
		if (result.getTotal() > 0) {
			TypedQuery<CommandLine> typedQuery = entityManager.createQuery(filter.CreateQuery(cb, CommandLine.class)).setFirstResult(filter.getOffset())
					.setMaxResults(filter.getPageSize());
			result.setData(typedQuery.getResultList());
		}
		return result;
	}
}
