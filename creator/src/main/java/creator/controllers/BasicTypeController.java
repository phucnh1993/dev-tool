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

import creator.domains.repositories.IBasicTypeRepository;
import creator.services.basicType.*;
import creator.domains.entities.BasicType;
import creator.services.FilterRequest;
import creator.services.ResultData;
import creator.services.ActionResponse;
import lombok.RequiredArgsConstructor;

@RestController
@RequestMapping("/api")
@RequiredArgsConstructor
public class BasicTypeController {
	@Autowired
	private final IBasicTypeRepository _repo;

	@PersistenceContext
	EntityManager entityManager;
	
	@Autowired(required=true)
	BasicTypeQuery _query;
	
	@Autowired(required=true)
	BasicTypeAction _action;
	
	@GetMapping("/basicTypes")
	public @ResponseBody ResultData<List<BasicTypeResponse>> getAll(FilterRequest filter) {
		return _query.getAll(filter);
	}
	
	@GetMapping("/basicTypes/{id}")
	public @ResponseBody ResultData<BasicType> getOne(@PathVariable BigInteger id) {
		return _query.getDetail(id);
	}
	
	@PostMapping("/basicTypes")
	public @ResponseBody ResultData<ActionResponse> create(@RequestBody BasicTypeRequest newCmd) {
		return _action.createData(_repo, newCmd);
	}
	
	@PutMapping("/basicTypes/{id}")
	public @ResponseBody ResultData<ActionResponse> update(@RequestBody BasicTypeRequest newCmd, @PathVariable BigInteger id) {
		return _action.updateData(_repo, newCmd, id);
	}

	@DeleteMapping("/basicTypes/{id}")
	public @ResponseBody ResultData<ActionResponse> delete(@PathVariable BigInteger id) {
		return _action.deleteData(_repo, id);
	}
}
