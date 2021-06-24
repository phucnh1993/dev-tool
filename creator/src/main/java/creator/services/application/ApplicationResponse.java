package creator.services.application;

import java.math.BigInteger;

import com.fasterxml.jackson.annotation.JsonProperty;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter 
@Setter 
@NoArgsConstructor
@AllArgsConstructor
public class ApplicationResponse {
	@JsonProperty("id")
	private BigInteger id;
	@JsonProperty("name")
	private String name;
	@JsonProperty("description")
	private String description;
	@JsonProperty("activated")
	private boolean isActivated;
	@JsonProperty("basicTypeId")
	private BigInteger basicTypeId;
	@JsonProperty("typeName")
	private String typeName;
	@JsonProperty("databaseDevId")
	private BigInteger databaseDevId;
	@JsonProperty("databaseUatId")
	private BigInteger databaseUatId;
}
