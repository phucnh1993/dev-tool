package databases.entities;

import java.io.Serializable;
import java.math.BigInteger;
import java.sql.Date;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EntityListeners;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Table;

import javax.persistence.Id;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;
import lombok.NoArgsConstructor;

@Getter 
@Setter 
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "Languages")
@EntityListeners(AuditingEntityListener.class)
public class Language implements Serializable {
	private static final long serialVersionUID = 1L;
	
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "Id", nullable = false, columnDefinition = "bigint unsigned")
    private BigInteger id;
	
	@Column(name = "Name", nullable = false, length = 100, columnDefinition = "varchar(100)")
	private String name;
	
	@Column(name = "Version", nullable = false, length = 20, columnDefinition = "varchar(20)")
	private String version;
	
	@Column(name = "Description", nullable = false, length = 500, columnDefinition = "varchar(500)")
	private String description;
	
	@Column(name = "CreatedOn", nullable = false, columnDefinition = "date")
	private Date createdOn;
	
	@Column(name = "ModifiedOn", nullable = false, columnDefinition = "datetime")
	private Timestamp modifiedOn;
	
	@Column(name = "Status", nullable = false, columnDefinition = "tinyint unsigned")
	private short status;
}
