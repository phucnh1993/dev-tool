package creator.domains.entities;

import java.math.BigInteger;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EntityListeners;
import javax.persistence.FetchType;
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
@Table(name = "Applications", indexes = {
		@Index(name = "ix_application_search", columnList = "IsActivated, Name", unique = false)		
})
@EntityListeners(AuditingEntityListener.class)
public class Application {
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "Id", nullable = false, columnDefinition = "bigint unsigned")
    private BigInteger id;
	
	@Column(name = "IsActivated", nullable = false)
    private boolean isActivated;
	
	@Column(name = "Name", nullable = false, length = 100, columnDefinition = "varchar(100) COLLATE ascii_bin")
    private String name;
	
	@Column(name = "Description", nullable = false, length = 300, columnDefinition = "varchar(300) CHARACTER SET utf8 COLLATE utf8_general_ci")
    private String description;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "BasicTypeId", referencedColumnName = "Id", nullable = false, columnDefinition = "bigint unsigned")
    private BasicType basicType;
	
	@Column(name = "TypeName", nullable = false, length = 100, columnDefinition = "varchar(100) COLLATE ascii_bin")
	private String typeName;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "databaseDevId", referencedColumnName = "Id", nullable = true, columnDefinition = "bigint unsigned")
    private Database databaseDev;
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "databaseUatId", referencedColumnName = "Id", nullable = true, columnDefinition = "bigint unsigned")
    private Database databaseUat;
}
