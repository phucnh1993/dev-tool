package creator.domains.entities;

import java.math.BigInteger;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EntityListeners;
import javax.persistence.FetchType;
import javax.persistence.ForeignKey;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Index;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;

import org.springframework.data.jpa.domain.support.AuditingEntityListener;

import lombok.AllArgsConstructor;
import lombok.EqualsAndHashCode;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.ToString;

@Getter 
@Setter 
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "ObjectStructs", indexes = {
		@Index(name = "ix_object_struct_search", columnList = "Activated, Name, CodeTypeId", unique = true)		
})
@EntityListeners(AuditingEntityListener.class)
public class ObjectStruct {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "Id"
			, nullable = false
			, columnDefinition = "bigint unsigned")
    private BigInteger id;
	
	@Column(name = "Activated"
			, nullable = false)
    private boolean activated;
	
	@Column(name = "Name"
			, nullable = false
			, length = 100
			, columnDefinition = "varchar(100) COLLATE ascii_bin")
    private String name;
	
	@Column(name = "Description"
			, nullable = false
			, length = 300
			, columnDefinition = "varchar(300) CHARACTER SET utf8 COLLATE utf8_general_ci")
    private String description;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "CodeTypeId"
			, foreignKey=@ForeignKey(name = "fk_object_struct_code_type")
			, referencedColumnName = "Id"
			, nullable = false
			, columnDefinition = "bigint unsigned")
	@EqualsAndHashCode.Exclude
	@ToString.Exclude
    private DataType codeType;
	
	@OneToMany(mappedBy = "objectStruct")
	@EqualsAndHashCode.Exclude
	@ToString.Exclude
	private List<ObjectPropertyStruct> objectPropertyStructs;
}
