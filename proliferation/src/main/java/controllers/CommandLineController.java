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

import databases.entities.CommandLine;
import databases.repositories.ICommandLineRepository;
import lombok.RequiredArgsConstructor;
import services.ActionResponse;
import services.FilterRequest;
import services.ResultData;
import services.commandLine.CommandLineAction;
import services.commandLine.CommandLineQuery;
import services.commandLine.CommandLineRequest;
import services.commandLine.CommandLinesResponse;

@RestController
@RequestMapping("/api")
@RequiredArgsConstructor
public class CommandLineController {
	@Autowired
	private final ICommandLineRepository _repo;

	@PersistenceContext
	EntityManager entityManager;
	
	@Autowired(required=true)
	CommandLineQuery _query;
	
	@Autowired(required=true)
	CommandLineAction _action;
	
	@GetMapping("/command-lines")
	public @ResponseBody ResultData<List<CommandLinesResponse>> getAll(FilterRequest filter) {
		return _query.getAll(filter);
	}
	
	@GetMapping("/command-lines/{id}")
	public @ResponseBody ResultData<CommandLine> getOne(@PathVariable BigInteger id) {
		return _query.getDetail(id);
	}
	
	@PostMapping("/command-lines")
	public @ResponseBody ResultData<ActionResponse> newEmployee(@RequestBody CommandLineRequest newCmd) {
		return _action.createCommandLine(_repo, newCmd);
	}
	
	@PutMapping("/command-lines/{id}")
	public @ResponseBody ResultData<ActionResponse> replaceEmployee(@RequestBody CommandLineRequest newCmd, @PathVariable BigInteger id) {
		return _action.updateCommandLine(_repo, newCmd, id);
	}

	@DeleteMapping("/command-lines/{id}")
	public @ResponseBody ResultData<ActionResponse> deleteEmployee(@PathVariable BigInteger id) {
		return _action.deleteCommandLine(_repo, id);
	}
}
