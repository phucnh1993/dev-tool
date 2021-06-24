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

import creator.domains.entities.Database;
import creator.domains.repositories.IDatabaseRepository;
import creator.services.ActionResponse;
import creator.services.FilterRequest;
import creator.services.ResultData;
import creator.services.database.DatabaseAction;
import creator.services.database.DatabaseQuery;
import creator.services.database.DatabaseRequest;
import creator.services.database.DatabaseResponse;
import lombok.RequiredArgsConstructor;

@RestController
@RequestMapping("/api")
@RequiredArgsConstructor
public class DatabaseController {
	@Autowired
	private final IDatabaseRepository _repo;

	@PersistenceContext
	EntityManager entityManager;
	
	@Autowired(required=true)
	DatabaseQuery _query;
	
	@Autowired(required=true)
	DatabaseAction _action;
	
	@GetMapping("/databases")
	public @ResponseBody ResultData<List<DatabaseResponse>> getAll(FilterRequest filter) {
		return _query.getAll(filter);
	}
	
	@GetMapping("/databases/{id}")
	public @ResponseBody ResultData<Database> getOne(@PathVariable BigInteger id) {
		return _query.getDetail(id);
	}
	
	@PostMapping("/databases")
	public @ResponseBody ResultData<ActionResponse> create(@RequestBody DatabaseRequest newCmd) {
		return _action.createData(_repo, newCmd);
	}
	
	@PutMapping("/databases/{id}")
	public @ResponseBody ResultData<ActionResponse> update(@RequestBody DatabaseRequest newCmd, @PathVariable BigInteger id) {
		return _action.updateData(_repo, newCmd, id);
	}

	@DeleteMapping("/databases/{id}")
	public @ResponseBody ResultData<ActionResponse> delete(@PathVariable BigInteger id) {
		return _action.deleteData(_repo, id);
	}
}
