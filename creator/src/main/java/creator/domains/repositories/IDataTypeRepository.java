package creator.domains.repositories;

import java.math.BigInteger;

import org.springframework.data.jpa.repository.JpaRepository;

import creator.domains.entities.DataType;

public interface IDataTypeRepository extends JpaRepository<DataType, BigInteger> {}