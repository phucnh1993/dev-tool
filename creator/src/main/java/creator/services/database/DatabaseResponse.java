package creator.services.database;

import java.math.BigInteger;

import com.fasterxml.jackson.annotation.JsonProperty;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter @Setter @NoArgsConstructor @AllArgsConstructor
public class DatabaseResponse {
	@JsonProperty("id")
	private BigInteger id;
	@JsonProperty("name")
	private String name;
	@JsonProperty("description")
	private String description;
	@JsonProperty("activated")
	private boolean activated;
	@JsonProperty("basicTypeId")
	private BigInteger basicTypeId;
	@JsonProperty("typeName")
	private String typeName;
	@JsonProperty("ipAddressV4")
	private String ipAddressV4;
	@JsonProperty("ipAddressV6")
	private String ipAddressV6;
	@JsonProperty("port")
	private Short port;
	@JsonProperty("username")
	private String username;
	@JsonProperty("password")
	private String password;
}
