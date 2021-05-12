package services.commandLine;

import java.math.BigInteger;
import java.sql.Date;
import java.sql.Timestamp;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import org.springframework.stereotype.Service;

import configs.ConstantConfig;
import databases.entities.CommandLine;
import databases.repositories.ICommandLineRepository;
import lombok.RequiredArgsConstructor;
import lombok.var;
import services.ActionResponse;
import services.ResultData;

@Service
@RequiredArgsConstructor
public class CommandLineAction {
	@PersistenceContext
	final EntityManager entityManager;

	public ResultData<ActionResponse> createCommandLine(ICommandLineRepository _repo, CommandLineRequest newCmd) {
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		try {
			long startTime = System.nanoTime();
			LocalDateTime now = LocalDateTime.now();
			CommandLine cmd = new CommandLine();
			cmd.setContent(newCmd.getContent());
			cmd.setApplicationName(newCmd.getApplicationName());
			cmd.setDescription(newCmd.getDescription());
			cmd.setStatus(newCmd.getStatus());
			cmd.setCreatedOn(Date.valueOf(now.toLocalDate()));
			cmd.setModifiedOn(Timestamp.valueOf(now));
			var data = _repo.save(cmd);
			ActionResponse temp = new ActionResponse();
			temp.setId(data.getId());
			DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
			temp.setActionOn(now.format(formatter));
			long endTime = System.nanoTime();
			temp.setRuntime((endTime - startTime) / 1000);
			result.setData(temp);
			result.setTotal(1);
		} catch (Exception ex) {
			result.setErrorCode(ConstantConfig.CREATE_DATA_ERROR);
			result.setMessage(ConstantConfig.StatusMessage.get(ConstantConfig.CREATE_DATA_ERROR));
		}
		return result;
	}

	public ResultData<ActionResponse> updateCommandLine(ICommandLineRepository _repo, CommandLineRequest newCmd,
			BigInteger id) {
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		try {
			long startTime = System.nanoTime();
			LocalDateTime now = LocalDateTime.now();
			CommandLine data = _repo.findById(id).get();
			data.setContent(newCmd.getContent());
			data.setApplicationName(newCmd.getApplicationName());
			data.setDescription(newCmd.getDescription());
			data.setStatus(newCmd.getStatus());
			data.setModifiedOn(Timestamp.valueOf(now));
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
	
	public ResultData<ActionResponse> deleteCommandLine(ICommandLineRepository _repo, BigInteger id) {
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
