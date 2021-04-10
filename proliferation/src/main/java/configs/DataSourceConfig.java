package configs;

import java.util.HashMap;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.sql.DataSource;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Primary;
import org.springframework.context.annotation.PropertySource;
import org.springframework.context.annotation.PropertySources;
import org.springframework.core.env.Environment;
import org.springframework.dao.annotation.PersistenceExceptionTranslationPostProcessor;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;
import org.springframework.jdbc.datasource.DriverManagerDataSource;
import org.springframework.jdbc.datasource.embedded.EmbeddedDatabaseBuilder;
import org.springframework.jdbc.datasource.embedded.EmbeddedDatabaseType;
import org.springframework.orm.jpa.JpaTransactionManager;
import org.springframework.orm.jpa.LocalContainerEntityManagerFactoryBean;
import org.springframework.orm.jpa.vendor.HibernateJpaVendorAdapter;
import org.springframework.transaction.PlatformTransactionManager;
import org.springframework.transaction.annotation.EnableTransactionManagement;

@Configuration
@EnableJpaRepositories
@EnableTransactionManagement
// @PropertySources({ @PropertySource("classpath:datasource.properties") })
public class DataSourceConfig {
	@Autowired
	private Environment env;

	@Primary
	@Bean
	public DataSource dsDatasource() {
//		DriverManagerDataSource dataSource = new DriverManagerDataSource();
//		dataSource.setDriverClassName(env.getProperty("spring.datasource.driver-class-name"));
//		dataSource.setUrl(env.getProperty("spring.datasource.url"));
//		dataSource.setUsername(env.getProperty("spring.datasource.username"));
//		dataSource.setPassword(env.getProperty("spring.datasource.password"));
//		return dataSource;
		EmbeddedDatabaseBuilder builder = new EmbeddedDatabaseBuilder();
	    return builder.setType(EmbeddedDatabaseType.HSQL).build();
	}

	@Primary
	@Bean
	public EntityManager productionEntityManager(EntityManagerFactory emf) {
		return emf.createEntityManager();
	}

	@Primary
	@Bean
	public LocalContainerEntityManagerFactoryBean dsEntityManager() {
		LocalContainerEntityManagerFactoryBean factory = new LocalContainerEntityManagerFactoryBean();
		factory.setDataSource(dsDatasource());
		factory.setPackagesToScan(new String[] { Constants.PACKAGE_ENTITIES });
		factory.setPersistenceUnitName(Constants.JPA_UNIT_NAME);
		HibernateJpaVendorAdapter vendorAdapter = new HibernateJpaVendorAdapter();
		factory.setJpaVendorAdapter(vendorAdapter);
		HashMap<String, Object> properties = new HashMap<>();
		properties.put("hibernate.dialect", env.getProperty("spring.jpa.properties.hibernate.dialect"));
		properties.put("hibernate.show-sql", env.getProperty("spring.jpa.show-sql"));
		properties.put("hibernate.generate-ddl", env.getProperty("spring.jpa.generate-ddl"));
		factory.setJpaPropertyMap(properties);
		factory.afterPropertiesSet();
		return factory;
	}

	@Primary
	@Bean
	public PlatformTransactionManager dsTransactionManager() {
		JpaTransactionManager transactionManager = new JpaTransactionManager();
		transactionManager.setEntityManagerFactory(dsEntityManager().getObject());
		return transactionManager;
	}
	
	@Primary
	@Bean
	public PlatformTransactionManager transactionManager(EntityManagerFactory entityManagerFactory) {
		JpaTransactionManager transactionManager = new JpaTransactionManager();
		transactionManager.setEntityManagerFactory(entityManagerFactory);
		return transactionManager;
	}

	@Primary
	@Bean
	public PersistenceExceptionTranslationPostProcessor productionExceptionTranslation() {
		return new PersistenceExceptionTranslationPostProcessor();
	}
}
