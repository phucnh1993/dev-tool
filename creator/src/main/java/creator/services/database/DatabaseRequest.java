package creator.services.database;

import java.math.BigInteger;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter @Setter @NoArgsConstructor
public class DatabaseRequest {
	private String name;
	private String description;
	private boolean activated;
	private BigInteger basicTypeId;
	private String ipAddressV4;
	private String ipAddressV6;
	private Short port;
	private String username;
	private String password;
}
