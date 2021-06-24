package creator.services.database;

import java.math.BigInteger;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import org.springframework.stereotype.Service;

import creator.configs.ConstantConfig;
import creator.domains.entities.BasicType;
import creator.domains.entities.Database;
import creator.domains.repositories.IBasicTypeRepository;
import creator.domains.repositories.IDatabaseRepository;
import creator.services.ActionResponse;
import creator.services.ResultData;
import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
public class DatabaseAction {
	@PersistenceContext
	final EntityManager entityManager;
	
	private final IBasicTypeRepository repoBasicType;

	public Database setDatabase(Database data, DatabaseRequest request) {
		data.setName(request.getName());
		data.setDescription(request.getDescription());
		data.setActivated(request.isActivated());
		if (request.getBasicTypeId() != null) {
			BasicType rbt = repoBasicType.findById(request.getBasicTypeId()).get();
			if (rbt != null) {
				data.setBasicType(rbt);
				data.setTypeName(rbt.getName());
			}
		}
		data.setIpAddressV4(request.getIpAddressV4());
		data.setIpAddressV6(request.getIpAddressV6());
		data.setPort(request.getPort());
		data.setUsername(request.getUsername());
		data.setPassword(request.getPassword().getBytes());
		return data;
	}
	
	public ResultData<ActionResponse> createData(IDatabaseRepository _repo, DatabaseRequest newData) {
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		try {
			long startTime = System.nanoTime();
			LocalDateTime now = LocalDateTime.now();
			Database data = new Database();
			data = setDatabase(data, newData);
			_repo.save(data);
			ActionResponse act = new ActionResponse();
			act.setId(data.getId());
			DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
			act.setActionOn(now.format(formatter));
			long endTime = System.nanoTime();
			act.setRuntime((endTime - startTime) / ConstantConfig.ONE_MILLION);
			result.setData(act);
			result.setTotal(1);
		} catch (Exception ex) {
			System.out.println(ex.getMessage());
			result.setErrorCode(ConstantConfig.CREATE_DATA_ERROR);
			result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.CREATE_DATA_ERROR));
		}
		return result;
	}

	public ResultData<ActionResponse> updateData(IDatabaseRepository _repo, DatabaseRequest oldData,
			BigInteger id) {
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		try {
			long startTime = System.nanoTime();
			LocalDateTime now = LocalDateTime.now();
			Database data = _repo.findById(id).get();
			data = setDatabase(data, oldData);
			_repo.save(data);
			ActionResponse act = new ActionResponse();
			act.setId(data.getId());
			DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
			act.setActionOn(now.format(formatter));
			long endTime = System.nanoTime();
			act.setRuntime((endTime - startTime) / ConstantConfig.ONE_MILLION);
			result.setData(act);
			result.setTotal(1);
		} catch (Exception ex) {
			System.out.println(ex.getMessage());
			result.setErrorCode(ConstantConfig.UPDATE_DATA_ERROR);
			result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.UPDATE_DATA_ERROR));
		}
		return result;
	}
	
	public ResultData<ActionResponse> deleteData(IDatabaseRepository _repo, BigInteger id) {
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
			temp.setRuntime((endTime - startTime) / ConstantConfig.ONE_MILLION);
			result.setData(temp);
			result.setTotal(1);
		} catch (Exception ex) {
			System.out.println(ex.getMessage());
			result.setErrorCode(ConstantConfig.DELETE_DATA_ERROR);
			result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.DELETE_DATA_ERROR));
		}
		return result;
	}
}
