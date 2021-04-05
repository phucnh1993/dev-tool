package responses;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
public class ResultData<T> {
	private T data;
	private int total;
	private long errorCode;
	private String message;
}
