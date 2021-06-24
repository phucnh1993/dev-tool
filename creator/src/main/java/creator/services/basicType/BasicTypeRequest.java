package creator.services.basicType;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter @Setter @NoArgsConstructor
public class BasicTypeRequest {
	private boolean activated;
	private String name;
	private String groupName;
	private String description;
	private int sort;
}
