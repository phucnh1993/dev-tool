package creator.controllers;

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

import creator.domains.entities.Application;
import creator.domains.repositories.IApplicationRepository;
import creator.services.ActionResponse;
import creator.services.FilterRequest;
import creator.services.ResultData;
import creator.services.application.ApplicationAction;
import creator.services.application.ApplicationQuery;
import creator.services.application.ApplicationRequest;
import creator.services.application.ApplicationResponse;
import lombok.RequiredArgsConstructor;

@RestController
@RequestMapping("/api")
@RequiredArgsConstructor
public class ApplicationController {
	@Autowired
	private final IApplicationRepository _repo;

	@PersistenceContext
	EntityManager entityManager;
	
	@Autowired(required=true)
	ApplicationQuery _query;
	
	@Autowired(required=true)
	ApplicationAction _action;
	
	@GetMapping("/applications")
	public @ResponseBody ResultData<List<ApplicationResponse>> getAll(FilterRequest filter) {
		return _query.getAll(filter);
	}
	
	@GetMapping("/applications/{id}")
	public @ResponseBody ResultData<Application> getOne(@PathVariable BigInteger id) {
		return _query.getDetail(id);
	}
	
	@PostMapping("/applications")
	public @ResponseBody ResultData<ActionResponse> create(@RequestBody ApplicationRequest newCmd) {
		return _action.createData(_repo, newCmd);
	}
	
	@PutMapping("/applications/{id}")
	public @ResponseBody ResultData<ActionResponse> update(@RequestBody ApplicationRequest newCmd, @PathVariable BigInteger id) {
		return _action.updateData(_repo, newCmd, id);
	}

	@DeleteMapping("/applications/{id}")
	public @ResponseBody ResultData<ActionResponse> delete(@PathVariable BigInteger id) {
		return _action.deleteData(_repo, id);
	}
}
