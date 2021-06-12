package creator.services.basicType;

import java.math.BigInteger;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import org.springframework.stereotype.Service;


import lombok.RequiredArgsConstructor;
import lombok.var;

import creator.domains.entities.BasicType;
import creator.domains.repositories.IBasicTypeRepository;
import creator.configs.ConstantConfig;
import creator.services.ResultData;
import creator.services.ActionResponse;

@Service
@RequiredArgsConstructor
public class BasicTypeAction {
	@PersistenceContext
	final EntityManager entityManager;

	public ResultData<ActionResponse> createData(IBasicTypeRepository _repo, BasicTypeRequest newData) {
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		try {
			long startTime = System.nanoTime();
			LocalDateTime now = LocalDateTime.now();
			BasicType data = new BasicType();
			data.setName(newData.getName());
			data.setDescription(newData.getDescription());
			data.setSort(newData.getSort());
			var temp = _repo.save(data);
			ActionResponse act = new ActionResponse();
			act.setId(temp.getId());
			DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
			act.setActionOn(now.format(formatter));
			long endTime = System.nanoTime();
			act.setRuntime((endTime - startTime) / 1000);
			result.setData(act);
			result.setTotal(1);
		} catch (Exception ex) {
			result.setErrorCode(ConstantConfig.CREATE_DATA_ERROR);
			result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.CREATE_DATA_ERROR));
		}
		return result;
	}

	public ResultData<ActionResponse> updateData(IBasicTypeRepository _repo, BasicTypeRequest oldData,
			BigInteger id) {
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		try {
			long startTime = System.nanoTime();
			LocalDateTime now = LocalDateTime.now();
			BasicType data = _repo.findById(id).get();
			data.setName(oldData.getName());
			data.setDescription(oldData.getDescription());
			data.setSort(oldData.getSort());
			_repo.save(data);
			ActionResponse temp = new ActionResponse();
			temp.setId(data.getId());
			DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
			temp.setActionOn(now.format(formatter));
			long endTime = System.nanoTime();
			temp.setRuntime((endTime - startTime) / 1000);
			result.setData(temp);
			result.setTotal(1);
		} catch (Exception ex) {
			result.setErrorCode(ConstantConfig.UPDATE_DATA_ERROR);
			result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.UPDATE_DATA_ERROR));
		}
		return result;
	}
	
	public ResultData<ActionResponse> deleteData(IBasicTypeRepository _repo, BigInteger id) {
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		try {
			long startTime = System.nanoTime();
			_repo.deleteById(id);
			LocalDateTime now = LocalDateTime.now();
			ActionResponse temp = new ActionResponse();
			temp.setId(id);
			DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
			temp.setActionOn(now.format(formatter));
			long endTime = System.nanoTime();
			temp.setRuntime((endTime - startTime) / 1000);
			result.setData(temp);
			result.setTotal(1);
		} catch (Exception ex) {
			result.setErrorCode(ConstantConfig.DELETE_DATA_ERROR);
			result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.DELETE_DATA_ERROR));
		}
		return result;
	}
}
