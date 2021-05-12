package controllers;

import java.math.BigInteger;
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
import services.ActionResponse;
import services.FilterRequest;
import services.ResultData;
import services.language.LanguageAction;
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
	
	@Autowired(required=true)
	LanguageAction _action;

	@GetMapping("/languages")
	public @ResponseBody ResultData<List<LanguagesResponse>> getAll(FilterRequest filter) {
		return _query.getAll(filter);
	}

	@GetMapping("/languages/{id}")
	public @ResponseBody ResultData<Language> getOne(@PathVariable BigInteger id) {
		return _query.getDetail(id);
	}

	@PostMapping("/languages")
	public @ResponseBody ResultData<ActionResponse> createLanaguage(@RequestBody LanguageRequest newLanguage) {
		return _action.createLanguage(_repo, newLanguage);
	}

	@PutMapping("/languages/{id}")
	public @ResponseBody ResultData<ActionResponse> updateLanaguage(@RequestBody LanguageRequest oldLanguage,
			@PathVariable BigInteger id) {
		return _action.updateLanguage(_repo, oldLanguage, id);
	}

	@DeleteMapping("/languages/{id}")
	public @ResponseBody ResultData<ActionResponse> deleteEmployee(@PathVariable BigInteger id) {
		return _action.deleteLanguage(_repo, id);
	}
}
