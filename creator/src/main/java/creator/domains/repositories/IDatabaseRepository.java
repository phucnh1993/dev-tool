package creator.domains.repositories;

import java.math.BigInteger;

import org.springframework.data.jpa.repository.JpaRepository;

import creator.domains.entities.Database;

public interface IDatabaseRepository extends JpaRepository<Database, BigInteger> {}
