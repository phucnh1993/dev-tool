package services.commandLine;

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

	public ResultData<List<CommandLinesResponse>> getAll(FilterRequest filter) {
		ResultData<List<CommandLinesResponse>> result = new ResultData<List<CommandLinesResponse>>();
		try {
			result.setData(new ArrayList<CommandLinesResponse>());
			CriteriaBuilder cb = entityManager.getCriteriaBuilder();
			result.setTotal(count(filter));
			if (result.getTotal() > 0) {
				TypedQuery<CommandLine> typedQuery = entityManager.createQuery(filter.CreateQuery(cb, CommandLine.class))
						.setFirstResult(filter.getOffset()).setMaxResults(filter.getPageSize());
				List<CommandLine> cmd = typedQuery.getResultList();
				List<CommandLinesResponse> data = new ArrayList<CommandLinesResponse>();
				for (int i = 0; i < cmd.size(); i++) {
					data.add(new CommandLinesResponse(cmd.get(i).getId(), cmd.get(i).getApplicationName(), cmd.get(i).getContent()));
				}
				result.setData(data);
			}
		} catch (Exception ex) {
			result.setErrorCode(ConstantConfig.QUERY_DATA_ERROR);
			result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.QUERY_DATA_ERROR));
		}
		return result;
	}
	
	public ResultData<CommandLine> getDetail(BigInteger id) {
		ResultData<CommandLine> result = new ResultData<CommandLine>();
		try {
			CriteriaBuilder cb = entityManager.getCriteriaBuilder();
			CriteriaQuery<CommandLine> query = cb.createQuery(CommandLine.class);
			Root<CommandLine> root = query.from(CommandLine.class);
			query.where(cb.equal(root.get("id"), id));
			TypedQuery<CommandLine> typedQuery = entityManager.createQuery(query);
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
