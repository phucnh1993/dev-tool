package databases.entities;

import java.math.BigInteger;
import java.sql.Date;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EntityListeners;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
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
@Table(name = "Projects")
@EntityListeners(AuditingEntityListener.class)
public class Project {
	@SuppressWarnings("unused")
	private static final long serialVersionUID = 4L;
	
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "Id", nullable = false, columnDefinition = "bigint unsigned")
    private BigInteger id;
	
	@Column(name = "Name", nullable = false, length = 100, columnDefinition = "varchar(100)")
	private String name;
	
	@Column(name = "Code", nullable = false, length = 32, columnDefinition = "varchar(32)")
	private String code;
	
	@Column(name = "Description", nullable = false, length = 500, columnDefinition = "varchar(500)")
	private String description;
	
	@Column(name = "LanguageId", nullable = false, columnDefinition = "bigint unsigned")
	private String languageId;
	
	@Column(name = "IsIpSix", nullable = false, columnDefinition = "bit")
	private boolean isIpSix;
	
	@Column(name = "DatabaseAddress", nullable = false, length = 50, columnDefinition = "varchar(50)")
	private String databaseAddress;
	
	@Column(name = "DatabaseName", nullable = false, length = 100, columnDefinition = "varchar(100)")
	private String databaseName;
	
	@Column(name = "DatabaseType", nullable = false, length = 50, columnDefinition = "varchar(50)")
	private String databaseType;
	
	@Column(name = "UserName", nullable = false, length = 100, columnDefinition = "varchar(100)")
	private String userName;
	
	@Column(name = "Password", nullable = false, length = 64, columnDefinition = "varbinary(64)")
	private byte[] password;
	
	@Column(name = "Salt", nullable = false, length = 32, columnDefinition = "varchar(32)")
	private String salt;
	
	@Column(name = "CreatedOn", nullable = false, columnDefinition = "date")
	private Date createdOn;
	
	@Column(name = "ModifiedOn", nullable = false, columnDefinition = "datetime")
	private Timestamp modifiedOn;
	
	@Column(name = "Status", nullable = false, columnDefinition = "tinyint unsigned")
	private short status;
}
