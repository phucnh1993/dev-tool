package databases.entities;

import java.sql.Date;

@Entity
@Table(name = "Languages")
@EntityListeners(AuditingEntityListener.class)
public class Language {
	@Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private long id;
	@Column(name = "Name", nullable = false)
	private String name;
	@Column(name = "Version", nullable = true)
	private String version;
	@Column(name = "Description", nullable = true)
	private String description;
	@Column(name = "CreatedOn", nullable = false)
	private Date createdOn;
	@Column(name = "ModifiedOn", nullable = false)
	private Date modifiedOn;
	@Column(name = "Status", nullable = false)
	private unsigned byte status;
}
