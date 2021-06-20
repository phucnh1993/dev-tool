package creator.services.application;

import java.math.BigInteger;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter @Setter @NoArgsConstructor
public class ApplicationRequest {
	private String name;
	private String description;
	private boolean isActivated;
	private BigInteger basicTypeId;
	private BigInteger databaseDevId;
	private BigInteger databaseUatId;
}
