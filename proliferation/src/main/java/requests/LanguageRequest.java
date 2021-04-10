package requests;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter @Setter @NoArgsConstructor
public class LanguageRequest {
	private String name;
	private String version;
	private String description;
	private short status;
}
