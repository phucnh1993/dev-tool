package creator.services.basicType;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter @Setter @NoArgsConstructor
public class BasicTypeRequest {
	private boolean isActivated;
	private String name;
	private String group;
	private String description;
	private int sort;
}
