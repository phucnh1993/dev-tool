package configs;

import java.util.HashMap;
import java.util.Map;

public class ConstantConfig {
	// Default value
	public static final int PAGE_INDEX_DEFAULT = 1;
	public static final int PAGE_SIZE_DEFAULT = 10;
	
	// Error code for api
	public static final long SUCCESS = 0;
	public static final long UNKNOW_ERROR = 1;
	public static final long QUERY_DATA_ERROR = 2;
	public static final long CREATE_DATA_ERROR = 3;
	public static final long UPDATE_DATA_ERROR = 4;
	public static final long DELETE_DATA_ERROR = 5;
	
	// Mapping Error Code with Message
	public static Map<Long, String> StatusMessage = new HashMap<>();
	
	// Function create mapping error code
	public static void CreateStatusMessage() {
		StatusMessage.put(UNKNOW_ERROR, "Unknow error");
		StatusMessage.put(SUCCESS, "Success");
		StatusMessage.put(QUERY_DATA_ERROR, "Query data error");
		StatusMessage.put(CREATE_DATA_ERROR, "Create data error");
		StatusMessage.put(UPDATE_DATA_ERROR, "Update data error");
		StatusMessage.put(DELETE_DATA_ERROR, "Delete data error");
	}
}
