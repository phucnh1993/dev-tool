package creator.services.application;

import java.math.BigInteger;

import com.fasterxml.jackson.annotation.JsonProperty;

import creator.services.basicType.BasicTypeResponse;
import creator.services.database.DatabaseResponse;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter 
@Setter 
@NoArgsConstructor
@AllArgsConstructor
public class ApplicationDetailResponse {
	@JsonProperty("id")
	private BigInteger id;
	@JsonProperty("name")
	private String name;
	@JsonProperty("description")
	private String description;
	@JsonProperty("isActivated")
	private boolean isActivated;
	@JsonProperty("basicType")
	private BasicTypeResponse basicType;
	@JsonProperty("databaseDev")
	private DatabaseResponse databaseDev;
	@JsonProperty("databaseUat")
	private DatabaseResponse databaseUat;
}
