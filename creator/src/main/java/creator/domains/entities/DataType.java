package creator.domains.entities;

import java.math.BigInteger;

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
@Table(name = "DataTypes", indexes = {
		@Index(name = "ix_data_type_search", columnList = "Activated, GroupTypeId, CodeTypeId, Name", unique = false)		
})
@EntityListeners(AuditingEntityListener.class)
public class DataType {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "Id", nullable = false, columnDefinition = "bigint unsigned")
    private BigInteger id;
	
	@Column(name = "Activated", nullable = false)
    private boolean activated;
	
	@Column(name = "Name", nullable = false, length = 100, columnDefinition = "varchar(100) COLLATE ascii_bin")
    private String name;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "GroupTypeId"
			, foreignKey=@ForeignKey(name = "fk_datatypes_group")
			, referencedColumnName = "Id"
			, nullable = false
			, columnDefinition = "bigint unsigned")
    private BasicType groupType;
	
	@Column(name = "GroupName", nullable = false, length = 100, columnDefinition = "varchar(100) COLLATE ascii_bin")
    private String groupName;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "CodeTypeId"
			, foreignKey=@ForeignKey(name = "fk_datatypes_code")
			, referencedColumnName = "Id"
			, nullable = false
			, columnDefinition = "bigint unsigned")
    private BasicType codeType;
	
	@Column(name = "CodeName", nullable = false, length = 100, columnDefinition = "varchar(100) COLLATE ascii_bin")
    private String codeName;
	
	@Column(name = "Description", nullable = false, length = 300, columnDefinition = "varchar(300) CHARACTER SET utf8 COLLATE utf8_general_ci")
    private String description;
	
	@Column(name = "Sort", nullable = false)
    private int sort;
}
