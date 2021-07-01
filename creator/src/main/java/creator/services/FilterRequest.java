package creator.services;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

import creator.configs.ConstantConfig;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
public class FilterRequest {
	private String from;
	private String to;
	private String keyWords;
	private Boolean activated;
	private String groupName;
	private int pageIndex = ConstantConfig.PAGE_INDEX_DEFAULT;
	private int pageSize = ConstantConfig.PAGE_SIZE_DEFAULT;
	private boolean isDescSort = false;
	private String fieldSort;

	public int getOffset() {
		return (pageIndex - ConstantConfig.PAGE_INDEX_DEFAULT) * pageSize;
	}

	public <T> List<Predicate> CreateListPredicate(CriteriaBuilder cb, Root<T> root, Class<T> myClass) {
		List<Predicate> predicates = new ArrayList<Predicate>();
		if (this.keyWords != null && !this.keyWords.trim().isEmpty())
			predicates.add(cb.like(root.get("name"), this.keyWords + "%"));
		if (this.from != null && !this.from.trim().isEmpty())
			predicates.add(cb.greaterThanOrEqualTo(root.get("modifiedOn"), this.from));
		if (this.to != null && !this.to.trim().isEmpty())
			predicates.add(cb.lessThanOrEqualTo(root.get("modifiedOn"), this.to));
		if (this.groupName != null && !this.groupName.trim().isEmpty())
			predicates.add( cb.like(root.get("groupName"), this.groupName + "%"));
		if (this.activated != null)
			predicates.add(cb.equal(root.get("activated"), this.activated));
		return predicates;
	}
	
	public <T> CriteriaQuery<T> UseListPredicate(CriteriaQuery<T> query, List<Predicate> predicates) {
		query = query.where(predicates.toArray(new Predicate[]{}));
		return query;
	}

	public <T> CriteriaQuery<Long> CreateCount(CriteriaBuilder cb, Class<T> myClass) {
		CriteriaQuery<Long> query = cb.createQuery(Long.class);
		Root<T> root = query.from(myClass);
		List<Predicate> predicates = CreateListPredicate(cb, root, myClass);
		query.select(cb.count(root));
		query = UseListPredicate(query, predicates);
		return query;
	}

	public <T> CriteriaQuery<T> CreateQuery(CriteriaBuilder cb, Class<T> myClass) {
		CriteriaQuery<T> query = cb.createQuery(myClass);
		Root<T> root = query.from(myClass);
		List<Predicate> predicates = CreateListPredicate(cb, root, myClass);
		query = UseListPredicate(query, predicates);
		if (this.fieldSort != null && !this.fieldSort.trim().isEmpty()) {
			if (!this.isDescSort) {
				query = query.orderBy(cb.asc(root.get(this.fieldSort)));
			} else {
				query = query.orderBy(cb.desc(root.get(this.fieldSort)));
			}
		} else {
			query = query.orderBy(cb.desc(root.get("id")));
		}
		return query;
	}
}
