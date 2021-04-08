package exceptions;

import java.math.BigInteger;

public class LanguageNotFoundException extends RuntimeException {
	private static final long serialVersionUID = 1L;

	public LanguageNotFoundException(BigInteger id) {
	    super("Could not find language: " + id);
	}
}
