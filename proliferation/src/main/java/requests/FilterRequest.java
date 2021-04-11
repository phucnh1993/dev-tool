package requests;

import configs.ConstantConfig;
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
	private int pageIndex = ConstantConfig.PAGE_INDEX_DEFAULT;
	private int pageSize = ConstantConfig.PAGE_SIZE_DEFAULT;
	private boolean isDescSort = false;
	private String fieldSort;
	
	public int getOffset() {
		return (pageIndex - ConstantConfig.PAGE_INDEX_DEFAULT) * pageSize;
	}
}
