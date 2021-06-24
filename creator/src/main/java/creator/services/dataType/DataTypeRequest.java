package creator.services.dataType;

import java.math.BigInteger;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter @Setter @NoArgsConstructor
public class DataTypeRequest {
	private String name;
	private String description;
	private boolean activated;
	private BigInteger groupTypeId;
	private BigInteger codeTypeId;
	private int sort;
}
