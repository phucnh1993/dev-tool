package services.language;

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
public class LanguagesResponse {
	@JsonProperty("id")
	private BigInteger id;
	@JsonProperty("content")
	private String content;
	@JsonProperty("applicationName")
	private String applicationName;
}
