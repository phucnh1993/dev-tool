package databases.entities;

import java.math.BigInteger;
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
@Table(name = "CommandLines")
@EntityListeners(AuditingEntityListener.class)
public class CommandLine {
	@SuppressWarnings("unused")
	private static final long serialVersionUID = 2L;
	
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "Id", nullable = false, columnDefinition = "bigint unsigned")
    private BigInteger id;
	
	@Column(name = "ApplicationName", nullable = false, length = 100, columnDefinition = "varchar(100)")
	private String applicationName;
	
	@Column(name = "Content", nullable = false, length = 2048, columnDefinition = "varchar(2048)")
	private String content;
	
	@Column(name = "Description", nullable = false, length = 500, columnDefinition = "varchar(500)")
	private String description;
	
	@Column(name = "CreatedOn", nullable = false, columnDefinition = "date")
	private Timestamp createdOn;
	
	@Column(name = "ModifiedOn", nullable = false, columnDefinition = "datetime")
	private Timestamp modifiedOn;
	
	@Column(name = "Status", nullable = false, columnDefinition = "tinyint unsigned")
	private short status;
}
