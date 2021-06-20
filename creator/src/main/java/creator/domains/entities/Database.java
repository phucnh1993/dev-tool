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
@Table(name = "DatabaseInfos", indexes = {
		@Index(name = "ix_database_search", columnList = "IsActivated, Name", unique = false)		
})
@EntityListeners(AuditingEntityListener.class)
public class Database {
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
	
	@Column(name = "IpAddressV4", nullable = true, length = 15, columnDefinition = "varchar(15) COLLATE ascii_bin")
    private String ipAddressV4;
	
	@Column(name = "IpAddressV6", nullable = true, length = 45, columnDefinition = "varchar(45) COLLATE ascii_bin")
    private String ipAddressV6;
	
	@Column(name = "Port", nullable = true, columnDefinition = "smallint unsigned")
    private Short port;
	
	@Column(name = "Username", nullable = true, length = 128, columnDefinition = "varchar(128) COLLATE ascii_bin")
    private String username;
	
	@Column(name = "Password", nullable = true, length = 128, columnDefinition = "varbinary(128)")
    private byte[] password;
}
