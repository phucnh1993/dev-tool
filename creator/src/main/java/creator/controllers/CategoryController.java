package creator.controllers;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import creator.services.FilterRequest;
import creator.services.ResultData;
import creator.services.category.CategoryQuery;
import creator.services.category.CategoryResponse;
import lombok.RequiredArgsConstructor;

@RestController
@RequestMapping("/api/categories")
@RequiredArgsConstructor
public class CategoryController {
	@PersistenceContext
	EntityManager entityManager;
	
	@Autowired(required=true)
	CategoryQuery _query;
	
	@GetMapping("/basicTypes")
	public @ResponseBody ResultData<List<CategoryResponse>> getAll(FilterRequest filter) {
		return _query.getBasicType(filter);
	}
}
