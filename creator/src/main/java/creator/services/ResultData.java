package creator.services;

import creator.configs.ConstantConfig;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class ResultData<T> {
	private T data;
	private long total;
	private long errorCode;
	private String message;

	public ResultData() {
		data = null;
		total = 0;
		errorCode = ConstantConfig.SUCCESS;
		message = ConstantConfig.StatusMessage.get(ConstantConfig.SUCCESS);
	}
}
