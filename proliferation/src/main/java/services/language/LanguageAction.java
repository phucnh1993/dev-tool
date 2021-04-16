package services.language;

import java.math.BigInteger;
import java.sql.Date;
import java.sql.Timestamp;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import org.springframework.stereotype.Service;

import configs.ConstantConfig;
import databases.entities.Language;
import databases.repositories.ILanguageRepository;
import lombok.RequiredArgsConstructor;
import lombok.var;
import services.ActionResponse;
import services.ResultData;

@Service
@RequiredArgsConstructor
public class LanguageAction {
	@PersistenceContext
	final EntityManager entityManager;

	public ResultData<ActionResponse> createLanguage(ILanguageRepository _repo, LanguageRequest newLanguage) {
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		try {
			long startTime = System.nanoTime();
			LocalDateTime now = LocalDateTime.now();
			Language language = new Language();
			language.setName(newLanguage.getName());
			language.setDescription(newLanguage.getDescription());
			language.setVersion(newLanguage.getVersion());
			language.setStatus(newLanguage.getStatus());
			language.setCreatedOn(Date.valueOf(now.toLocalDate()));
			language.setModifiedOn(Timestamp.valueOf(now));
			var data = _repo.save(language);
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

	public ResultData<ActionResponse> updateLanguage(ILanguageRepository _repo, LanguageRequest oldLanguage,
			BigInteger id) {
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		try {
			long startTime = System.nanoTime();
			LocalDateTime now = LocalDateTime.now();
			Language data = _repo.findById(id).get();
			data.setName(oldLanguage.getName());
			data.setVersion(oldLanguage.getVersion());
			data.setDescription(oldLanguage.getDescription());
			data.setModifiedOn(Timestamp.valueOf(now));
			data.setStatus(oldLanguage.getStatus());
			_repo.save(data);
			ActionResponse temp = new ActionResponse();
			temp.setId(data.getId());
			DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
			temp.setActionOn(now.format(formatter));
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
	
	public ResultData<ActionResponse> deleteLanguage(ILanguageRepository _repo, BigInteger id) {
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
