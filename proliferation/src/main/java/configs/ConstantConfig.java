package configs;

import java.util.HashMap;
import java.util.Map;

public class ConstantConfig {
	public static final int PAGE_INDEX_DEFAULT = 1;
	public static final int PAGE_SIZE_DEFAULT = 10;
	
	public static final long UNKNOW_ERROR = 0;
	public static final long SUCCESS = 1;
	
	public static Map<Long, String> StatusMessage = new HashMap<>();
	
	public static void CreateStatusMessage() {
		StatusMessage.put(UNKNOW_ERROR, "Unknow error");
		StatusMessage.put(SUCCESS, "Success");
	}
}
