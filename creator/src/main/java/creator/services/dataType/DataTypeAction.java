package creator.services.dataType;

import java.math.BigInteger;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import org.springframework.stereotype.Service;

import creator.configs.ConstantConfig;
import creator.domains.entities.BasicType;
import creator.domains.entities.DataType;
import creator.domains.repositories.IBasicTypeRepository;
import creator.domains.repositories.IDataTypeRepository;
import creator.services.ActionResponse;
import creator.services.ResultData;
import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
public class DataTypeAction {
	@PersistenceContext
	final EntityManager entityManager;
	
	private final IBasicTypeRepository repoBasicType;

	public DataType setDataType(DataType data, DataTypeRequest request) {
		data.setName(request.getName());
		data.setDescription(request.getDescription());
		data.setActivated(request.isActivated());
		if (request.getGroupTypeId() != null) {
			BasicType rbt = repoBasicType.findById(request.getGroupTypeId()).get();
			if (rbt != null) {
				data.setGroupType(rbt);
				data.setGroupName(rbt.getName());
			}
		}
		if (request.getCodeTypeId() != null) {
			BasicType rbt = repoBasicType.findById(request.getCodeTypeId()).get();
			if (rbt != null) {
				data.setCodeType(rbt);
				data.setCodeName(rbt.getName());
			}
		}
		return data;
	}
	
	public ResultData<ActionResponse> createData(IDataTypeRepository _repo, DataTypeRequest newData) {
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		try {
			long startTime = System.nanoTime();
			LocalDateTime now = LocalDateTime.now();
			DataType data = new DataType();
			data = setDataType(data, newData);
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

	public ResultData<ActionResponse> updateData(IDataTypeRepository _repo, DataTypeRequest oldData,
			BigInteger id) {
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		try {
			long startTime = System.nanoTime();
			LocalDateTime now = LocalDateTime.now();
			DataType data = _repo.findById(id).get();
			data = setDataType(data, oldData);
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
	
	public ResultData<ActionResponse> deleteData(IDataTypeRepository _repo, BigInteger id) {
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
