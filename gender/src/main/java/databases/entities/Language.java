package databases.entities;

import java.io.Serializable;
import java.math.BigInteger;
import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EntityListeners;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Table;

import org.springframework.data.annotation.Id;
import org.springframework.data.jpa.domain.support.AuditingEntityListener;

import lombok.Getter;
import lombok.Setter;
import lombok.NoArgsConstructor;

@Entity
@Table(name = "Languages")
@EntityListeners(AuditingEntityListener.class)
@Getter @Setter @NoArgsConstructor
public class Language implements Serializable {
	private static final long serialVersionUID = 746237126088051312L;
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "Id", nullable = false)
    private BigInteger id;
	
	@Column(name = "Name", nullable = false)
	private String name;
	
	@Column(name = "Version", nullable = true)
	private String version;
	
	@Column(name = "Description", nullable = true)
	private String description;
	
	@Column(name = "CreatedOn", nullable = false)
	private Timestamp createdOn;
	
	@Column(name = "ModifiedOn", nullable = false)
	private Timestamp modifiedOn;
	
	@Column(name = "Status", nullable = false)
	private int status;
}
