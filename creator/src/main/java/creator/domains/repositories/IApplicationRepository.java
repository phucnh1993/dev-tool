package creator.domains.repositories;

import java.math.BigInteger;

import org.springframework.data.jpa.repository.JpaRepository;

import creator.domains.entities.Application;

public interface IApplicationRepository extends JpaRepository<Application, BigInteger> {}
