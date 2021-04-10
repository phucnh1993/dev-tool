package databases.repositories;

import databases.entities.Language;

import java.math.BigInteger;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ILanguageRepository extends JpaRepository<Language, BigInteger> {}