package requests;

import java.sql.Timestamp;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
public class FilterRequest {
	private Timestamp from;
	private Timestamp to;
	private String keyWords;
	private int pageIndex;
	private int pageSize;
}
