package creator.services;

import com.fasterxml.jackson.annotation.JsonProperty;

import creator.configs.ConstantConfig;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class ResultData<T> {
	@JsonProperty("data")
	private T data;
	@JsonProperty("total")
	private long total;
	@JsonProperty("errorCode")
	private long errorCode;
	@JsonProperty("message")
	private String message;

	public ResultData() {
		data = null;
		total = 0;
		errorCode = ConstantConfig.SUCCESS;
		message = ConstantConfig.StatusMessage.get(ConstantConfig.SUCCESS);
	}
}
