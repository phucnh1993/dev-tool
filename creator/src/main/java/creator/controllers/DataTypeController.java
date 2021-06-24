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

import creator.domains.entities.DataType;
import creator.domains.repositories.IDataTypeRepository;
import creator.services.ActionResponse;
import creator.services.FilterRequest;
import creator.services.ResultData;
import creator.services.dataType.DataTypeAction;
import creator.services.dataType.DataTypeQuery;
import creator.services.dataType.DataTypeRequest;
import creator.services.dataType.DataTypeResponse;
import lombok.RequiredArgsConstructor;

@RestController
@RequestMapping("/api")
@RequiredArgsConstructor
public class DataTypeController {
	@Autowired
	private final IDataTypeRepository _repo;

	@PersistenceContext
	EntityManager entityManager;
	
	@Autowired(required=true)
	DataTypeQuery _query;
	
	@Autowired(required=true)
	DataTypeAction _action;
	
	@GetMapping("/dataTypes")
	public @ResponseBody ResultData<List<DataTypeResponse>> getAll(FilterRequest filter) {
		return _query.getAll(filter);
	}
	
	@GetMapping("/dataTypes/{id}")
	public @ResponseBody ResultData<DataType> getOne(@PathVariable BigInteger id) {
		return _query.getDetail(id);
	}
	
	@PostMapping("/dataTypes")
	public @ResponseBody ResultData<ActionResponse> create(@RequestBody DataTypeRequest newCmd) {
		return _action.createData(_repo, newCmd);
	}
	
	@PutMapping("/dataTypes/{id}")
	public @ResponseBody ResultData<ActionResponse> update(@RequestBody DataTypeRequest newCmd, @PathVariable BigInteger id) {
		return _action.updateData(_repo, newCmd, id);
	}

	@DeleteMapping("/dataTypes/{id}")
	public @ResponseBody ResultData<ActionResponse> delete(@PathVariable BigInteger id) {
		return _action.deleteData(_repo, id);
	}
}
