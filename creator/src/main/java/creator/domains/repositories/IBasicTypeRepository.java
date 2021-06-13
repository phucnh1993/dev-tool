package creator.domains.repositories;

import java.math.BigInteger;

import org.springframework.data.jpa.repository.JpaRepository;

import creator.domains.entities.BasicType;

public interface IBasicTypeRepository extends JpaRepository<BasicType, BigInteger>  {}
