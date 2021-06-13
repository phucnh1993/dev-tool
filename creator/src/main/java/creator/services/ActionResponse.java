package creator.services;

import java.math.BigInteger;

import com.fasterxml.jackson.annotation.JsonProperty;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
public class ActionResponse {
	@JsonProperty("id")
	private BigInteger id;
	@JsonProperty("actionOn")
	private String actionOn;
	@JsonProperty("runtime")
	private long runtime;
}
