package creator.domains.entities;

import java.io.Serializable;
import java.math.BigInteger;

import javax.persistence.Column;
import javax.persistence.Embeddable;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter 
@Setter 
@NoArgsConstructor
@AllArgsConstructor
@Embeddable
public class ObjectPropertyStructKey implements Serializable{
	
	private static final long serialVersionUID = 1L;

	@Column(name = "StructId", columnDefinition = "bigint unsigned")
	private BigInteger structId;
	
	@Column(name = "PropertyId", columnDefinition = "bigint unsigned")
	private BigInteger propertyId;
}
