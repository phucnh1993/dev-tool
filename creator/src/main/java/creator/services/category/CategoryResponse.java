package creator.services.category;

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
public class CategoryResponse {
	@JsonProperty("id")
	private BigInteger id;
	@JsonProperty("name")
	private String name;
}
