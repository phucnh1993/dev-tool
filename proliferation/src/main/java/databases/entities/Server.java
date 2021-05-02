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
@Table(name = "Servers")
@EntityListeners(AuditingEntityListener.class)
public class Server {
	@SuppressWarnings("unused")
	private static final long serialVersionUID = 5L;
	
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "Id", nullable = false, columnDefinition = "bigint unsigned")
    private BigInteger id;
	
	@Column(name = "Name", nullable = false, length = 64, columnDefinition = "varchar(64)")
	private String name;
	
	@Column(name = "Description", nullable = false, length = 500, columnDefinition = "varchar(500)")
	private String description;
	
	@Column(name = "Type", nullable = false, length = 50, columnDefinition = "varchar(50)")
	private String type;
	
	@Column(name = "DatabaseId", nullable = false, columnDefinition = "bigint unsigned")
	private BigInteger databaseId;
	
	@Column(name = "IsBalance", nullable = false, columnDefinition = "bit")
	private boolean isBalance;
	
	@Column(name = "IsApplication", nullable = false, columnDefinition = "bit")
	private boolean isApplication;
	
	@Column(name = "IsWebHost", nullable = false, columnDefinition = "bit")
	private boolean isWebHost;
	
	@Column(name = "IsDatabase", nullable = false, columnDefinition = "bit")
	private boolean isDatabase;
	
	@Column(name = "IsRemote", nullable = false, columnDefinition = "bit")
	private boolean isRemote;
	
	@Column(name = "IsVirtual", nullable = false, columnDefinition = "bit")
	private boolean isVirtual;
	
	@Column(name = "IsPowerOn", nullable = false, columnDefinition = "bit")
	private boolean isPowerOn;
	
	@Column(name = "IsIpSix", nullable = false, columnDefinition = "bit")
	private boolean isIpSix;
	
	@Column(name = "Address", nullable = false, length = 50, columnDefinition = "varchar(50)")
	private String address;
	
	@Column(name = "UserName", nullable = false, length = 64, columnDefinition = "varchar(64)")
	private String userName;
	
	@Column(name = "Password", nullable = false, length = 64, columnDefinition = "varbinary(64)")
	private byte[] password;
	
	@Column(name = "Salt", nullable = false, length = 32, columnDefinition = "varchar(32)")
	private String salt;
	
	@Column(name = "CreatedOn", nullable = false, columnDefinition = "date")
	private Date createdOn;
	
	@Column(name = "ModifiedOn", nullable = false, columnDefinition = "datetime")
	private Timestamp modifiedOn;
}
