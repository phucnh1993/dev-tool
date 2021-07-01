package creator.domains.entities;

import javax.persistence.EmbeddedId;
import javax.persistence.Entity;
import javax.persistence.EntityListeners;
import javax.persistence.ForeignKey;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.MapsId;
import javax.persistence.Table;

import org.springframework.data.jpa.domain.support.AuditingEntityListener;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter 
@Setter 
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "ObjectPropertyStructs")
@EntityListeners(AuditingEntityListener.class)
public class ObjectPropertyStruct {
	@EmbeddedId
	private ObjectPropertyStructKey id;
	
	@ManyToOne
    @MapsId("structId")
    @JoinColumn(name = "PropertyId", columnDefinition = "bigint unsigned", foreignKey = @ForeignKey(name = "fk_properties"))
	private Property property;
	
	@ManyToOne
    @MapsId("propertyId")
    @JoinColumn(name = "ObjectStructId", columnDefinition = "bigint unsigned", foreignKey = @ForeignKey(name = "fk_object_structs"))
	private ObjectStruct objectStruct;
	
	private int rating;
}
