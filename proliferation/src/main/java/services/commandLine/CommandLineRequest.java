package services.commandLine;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter @Setter @NoArgsConstructor
public class CommandLineRequest {
	private String applicationName;
	private String content;
	private String description;
	private short status;
}
