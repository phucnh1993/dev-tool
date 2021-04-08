package responses;

import java.math.BigInteger;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
public class ActionResponse {
	private BigInteger id;
	private String actionOn;
	private long runtime;
}
