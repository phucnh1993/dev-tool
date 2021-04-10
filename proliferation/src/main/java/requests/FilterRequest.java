package requests;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
public class FilterRequest {
	private String from;
	private String to;
	private String keyWords;
	private int pageIndex;
	private int pageSize;
}
