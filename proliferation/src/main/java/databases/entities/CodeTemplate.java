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
@Table(name = "CodeTemplates")
@EntityListeners(AuditingEntityListener.class)
public class CodeTemplate {
	@SuppressWarnings("unused")
	private static final long serialVersionUID = 3L;
	
	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "Id", nullable = false, columnDefinition = "bigint unsigned")
    private BigInteger id;
	
	@Column(name = "LanguageId", nullable = false, columnDefinition = "bigint unsigned")
	private String languageId;
	
	@Column(name = "TagName", nullable = false, length = 64, columnDefinition = "varchar(64)")
	private String tagName;
	
	@Column(name = "Title", nullable = false, length = 128, columnDefinition = "varchar(128)")
	private String title;
	
	@Column(name = "Content", nullable = false, columnDefinition = "longtext")
	private String content;
	
	@Column(name = "CreatedOn", nullable = false, columnDefinition = "date")
	private Date createdOn;
	
	@Column(name = "ModifiedOn", nullable = false, columnDefinition = "datetime")
	private Timestamp modifiedOn;
	
	@Column(name = "IsActivated", nullable = false, columnDefinition = "bit")
	private boolean isActivated;
	
	@Column(name = "OnlyFirst", nullable = false, columnDefinition = "bit")
	private boolean onlyFirst;
}
