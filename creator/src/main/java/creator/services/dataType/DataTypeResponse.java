package creator.services.dataType;

import java.math.BigInteger;

import com.fasterxml.jackson.annotation.JsonProperty;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter @Setter @NoArgsConstructor @AllArgsConstructor
public class DataTypeResponse {
	@JsonProperty("id")
	private BigInteger id;
	@JsonProperty("name")
	private String name;
	@JsonProperty("description")
	private String description;
	@JsonProperty("sort")
	private int sort;
	@JsonProperty("activated")
	private boolean activated;
	@JsonProperty("groupTypeId")
	private BigInteger groupTypeId;
	@JsonProperty("groupName")
	private String groupName;
	@JsonProperty("codeTypeId")
	private BigInteger codeTypeId;
	@JsonProperty("codeName")
	private String codeName;
}
