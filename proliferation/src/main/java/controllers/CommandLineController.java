package controllers;

import java.math.BigInteger;
import java.sql.Timestamp;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.List;

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

import databases.entities.CommandLine;
import databases.repositories.ICommandLineRepository;
import exceptions.LanguageNotFoundException;
import lombok.RequiredArgsConstructor;
import lombok.var;
import requests.FilterRequest;
import requests.CommandLineRequest;
import responses.ActionResponse;
import responses.ResultData;

@RestController
@RequestMapping("/api")
@RequiredArgsConstructor
public class CommandLineController {
	@Autowired
	private final ICommandLineRepository _repo;
	
	@GetMapping("/command-lines")
	public @ResponseBody ResultData<List<CommandLine>> getAll(FilterRequest filter) {
		ResultData<List<CommandLine>> result = new ResultData<List<CommandLine>>();
		var data = _repo.findAll();
		result.setData(data);
		result.setTotal(data.size());
		result.setErrorCode(0);
		result.setMessage("SUCCESS");
	    return result;
	}
	
	@GetMapping("/command-lines/{id}")
	public @ResponseBody ResultData<CommandLine> getOne(@PathVariable BigInteger id) {
		ResultData<CommandLine> result = new ResultData<CommandLine>();
		result.setData(_repo.findById(id).orElseThrow(() -> new LanguageNotFoundException(id)));
		result.setTotal(1);
		result.setErrorCode(0);
		result.setMessage("SUCCESS");
	    return result;
	}
	
	@PostMapping("/command-lines")
	public @ResponseBody ResultData<ActionResponse> newEmployee(@RequestBody CommandLineRequest newLanguage) {
		long startTime = System.nanoTime();
		LocalDateTime now = LocalDateTime.now();
		CommandLine language = new CommandLine();
		language.setApplicationName(newLanguage.getApplicationName());
		language.setDescription(newLanguage.getDescription());
		language.setContent(newLanguage.getContent());
		language.setStatus(newLanguage.getStatus());
		language.setCreatedOn(Timestamp.valueOf(now));
		language.setModifiedOn(Timestamp.valueOf(now));
		var data = _repo.save(language);
		ResultData<ActionResponse> result = new ResultData<ActionResponse>();
		ActionResponse temp = new ActionResponse();
		temp.setId(data.getId());
		DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
		temp.setActionOn(now.format(formatter));
		long endTime = System.nanoTime();
		temp.setRuntime((endTime - startTime)/1000);
		result.setData(temp);
		result.setTotal(1);
		result.setErrorCode(0);
		result.setMessage("SUCCESS");
	    return result;
	}
	
	@PutMapping("/command-lines/{id}")
	public @ResponseBody ResultData<ActionResponse> replaceEmployee(@RequestBody CommandLine newLanguage, @PathVariable BigInteger id) {
		long startTime = System.nanoTime();
		LocalDateTime now = LocalDateTime.now();
		var data = _repo.findById(id)
	      .map(language -> {
	    	  language.setApplicationName(newLanguage.getApplicationName());
	    	  language.setContent(newLanguage.getContent());
	    	  language.setDescription(newLanguage.getDescription());
	    	  language.setModifiedOn(Timestamp.valueOf(now));
	    	  language.setStatus(newLanguage.getStatus());
	    	  return _repo.save(language);
	      })
	      .orElseGet(() -> {
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
		temp.setRuntime((endTime - startTime)/1000);
		result.setData(temp);
		result.setTotal(1);
		result.setErrorCode(0);
		result.setMessage("SUCCESS");
	    return result;
	}

	@DeleteMapping("/command-lines/{id}")
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
		temp.setRuntime((endTime - startTime)/1000);
		result.setData(temp);
		result.setTotal(1);
		result.setErrorCode(0);
		result.setMessage("SUCCESS");
		return result;
	}
}
