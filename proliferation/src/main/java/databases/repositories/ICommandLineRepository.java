package databases.repositories;

import java.math.BigInteger;

import org.springframework.data.jpa.repository.JpaRepository;

import databases.entities.CommandLine;

public interface ICommandLineRepository extends JpaRepository<CommandLine, BigInteger> {}
