package creator.domains.entities;

import java.math.BigInteger;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EntityListeners;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Index;
import javax.persistence.OneToMany;
import javax.persistence.Table;

import org.springframework.data.jpa.domain.support.AuditingEntityListener;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter 
@Setter 
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "BasicTypes", indexes = {
		@Index(name = "ix_basic_type_search", columnList = "Activated, GroupName, Name", unique = false)		
})
@EntityListeners(AuditingEntityListener.class)
public class BasicType {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "Id", nullable = false, columnDefinition = "bigint unsigned")
    private BigInteger id;
	
	@Column(name = "Activated", nullable = false)
    private boolean activated;
	
	@Column(name = "Name", nullable = false, length = 100, columnDefinition = "varchar(100) COLLATE ascii_bin")
    private String name;
	
	@Column(name = "GroupName", nullable = false, length = 50, columnDefinition = "varchar(50) COLLATE ascii_bin")
    private String groupName;
	
	@Column(name = "Description", nullable = false, length = 300, columnDefinition = "varchar(300) CHARACTER SET utf8 COLLATE utf8_general_ci")
    private String description;
	
	@Column(name = "Sort", nullable = false)
    private int sort;
	
	@OneToMany(fetch = FetchType.LAZY, mappedBy = "basicType")
    private List<Application> applications;
	
	@OneToMany(fetch = FetchType.LAZY, mappedBy = "basicType")
    private List<Database> databases;
	
	@OneToMany(fetch = FetchType.LAZY, mappedBy = "groupType")
    private List<DataType> dataTypeGroups;
	
	@OneToMany(fetch = FetchType.LAZY, mappedBy = "codeType")
    private List<DataType> dataTypeCodes;
	
	@OneToMany(fetch = FetchType.LAZY, mappedBy = "codeType")
    private List<ObjectStruct> objectStructCodes;
}
