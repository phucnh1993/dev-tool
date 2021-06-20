package creator.services.application;

import java.math.BigInteger;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import org.springframework.stereotype.Service;

import creator.configs.ConstantConfig;
import creator.domains.entities.Application;
import creator.domains.entities.BasicType;
import creator.domains.entities.Database;
import creator.domains.repositories.IApplicationRepository;
import creator.domains.repositories.IBasicTypeRepository;
import creator.domains.repositories.IDatabaseRepository;
import creator.services.ActionResponse;
import creator.services.ResultData;
import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
public class ApplicationAction {
	@PersistenceContext
	final EntityManager entityManager;
	
	private final IBasicTypeRepository repoBasicType;
	private final IDatabaseRepository repoDatabase;

	public Application setDataApplication(Application data, ApplicationRequest request) {
		data.setName(request.getName());
		data.setDescription(request.getDescription());
		data.setActivated(request.isActivated());
		if (request.getBasicTypeId() != null) {
			BasicType rbt = repoBasicType.findById(request.getBasicTypeId()).get();
			if (rbt != null)
				data.setBasicType(rbt);
		}
		if (request.getDatabaseDevId() != null) {
			Database db = repoDatabase.findById(request.getDatabaseDevId()).get();
			if (db != null)
				data.setDatabaseDev(db);
		}
		if (request.getDatabaseUatId() != null) {
			Database db = repoDatabase.findById(request.getDatabaseUatId()).get();
			if (db != null)
				data.setDatabaseUat(db);
		}
		return data;
	}
	
	public ResultData<ActionResponse> createData(IApplicationRepository _repo, ApplicationRequest newData) {
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		try {
			long startTime = System.nanoTime();
			LocalDateTime now = LocalDateTime.now();
			Application data = new Application();
			data = setDataApplication(data, newData);
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

	public ResultData<ActionResponse> updateData(IApplicationRepository _repo, ApplicationRequest oldData,
			BigInteger id) {
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		try {
			long startTime = System.nanoTime();
			LocalDateTime now = LocalDateTime.now();
			Application data = _repo.findById(id).get();
			data = setDataApplication(data, oldData);
			_repo.save(data);
			ActionResponse temp = new ActionResponse();
			temp.setId(data.getId());
			DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
			temp.setActionOn(now.format(formatter));
			long endTime = System.nanoTime();
			temp.setRuntime((endTime - startTime) / ConstantConfig.ONE_MILLION);
			result.setData(temp);
			result.setTotal(1);
		} catch (Exception ex) {
			System.out.println(ex.getMessage());
			result.setErrorCode(ConstantConfig.UPDATE_DATA_ERROR);
			result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.UPDATE_DATA_ERROR));
		}
		return result;
	}
	
	public ResultData<ActionResponse> deleteData(IApplicationRepository _repo, BigInteger id) {
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
