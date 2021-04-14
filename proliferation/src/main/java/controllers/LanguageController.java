package controllers;

import java.math.BigInteger;
import java.sql.Date;
import java.sql.Timestamp;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import databases.entities.Language;
import databases.repositories.ILanguageRepository;
import lombok.RequiredArgsConstructor;
import lombok.var;
import requests.FilterRequest;
import responses.ActionResponse;
import responses.ResultData;
import services.language.LanguageQuery;
import services.language.LanguageRequest;
import services.language.LanguagesResponse;

@RestController
@RequestMapping("/api")
@RequiredArgsConstructor
public class LanguageController {
	@Autowired
	private final ILanguageRepository _repo;

	@PersistenceContext
	EntityManager entityManager;
	
	@Autowired(required=true)
	LanguageQuery _query;

	// private static final Logger LOGGER =
	// LoggerFactory.getLogger(UserController.class);

	@GetMapping("/languages")
	public @ResponseBody ResultData<List<LanguagesResponse>> getAll(FilterRequest filter) {
		return _query.getAll(filter);
	}

	@GetMapping("/languages/{id}")
	public @ResponseBody ResultData<Language> getOne(@PathVariable BigInteger id) {
		return _query.getDetail(id);
	}

	@PostMapping("/languages")
	public @ResponseBody ResultData<ActionResponse> newEmployee(@RequestBody LanguageRequest newLanguage) {
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
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		ActionResponse temp = new ActionResponse();
		temp.setId(data.getId());
		DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
		temp.setActionOn(now.format(formatter));
		long endTime = System.nanoTime();
		temp.setRuntime((endTime - startTime) / 1000);
		result.setData(temp);
		result.setTotal(1);
		result.setErrorCode(0);
		result.setMessage("SUCCESS");
		return result;
	}

	@PutMapping("/languages/{id}")
	public @ResponseBody ResultData<ActionResponse> replaceEmployee(@RequestBody Language newLanguage,
			@PathVariable BigInteger id) {
		long startTime = System.nanoTime();
		LocalDateTime now = LocalDateTime.now();
		var data = _repo.findById(id).map(language -> {
			language.setName(newLanguage.getName());
			language.setVersion(newLanguage.getVersion());
			language.setDescription(newLanguage.getDescription());
			language.setModifiedOn(Timestamp.valueOf(now));
			language.setStatus(newLanguage.getStatus());
			return _repo.save(language);
		}).orElseGet(() -> {
			newLanguage.setId(id);
			return _repo.save(newLanguage);
		});
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		ActionResponse temp = new ActionResponse();
		temp.setId(data.getId());
		DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
		temp.setActionOn(now.format(formatter));
		temp.setActionOn(now.format(formatter));
		long endTime = System.nanoTime();
		temp.setRuntime((endTime - startTime) / 1000);
		result.setData(temp);
		result.setTotal(1);
		result.setErrorCode(0);
		result.setMessage("SUCCESS");
		return result;
	}

	@DeleteMapping("/languages/{id}")
	public @ResponseBody ResultData<ActionResponse> deleteEmployee(@PathVariable BigInteger id) {
		long startTime = System.nanoTime();
		_repo.deleteById(id);
		LocalDateTime now = LocalDateTime.now();
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		ActionResponse temp = new ActionResponse();
		temp.setId(id);
		DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
		temp.setActionOn(now.format(formatter));
		temp.setActionOn(now.format(formatter));
		long endTime = System.nanoTime();
		temp.setRuntime((endTime - startTime) / 1000);
		result.setData(temp);
		result.setTotal(1);
		result.setErrorCode(0);
		result.setMessage("SUCCESS");
		return result;
	}
}
