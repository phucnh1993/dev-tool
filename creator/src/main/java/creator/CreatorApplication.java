package creator;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.domain.EntityScan;
import org.springframework.boot.autoconfigure.security.servlet.SecurityAutoConfiguration;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

import creator.configs.ConstantConfig;


@SpringBootApplication
@EnableAutoConfiguration(exclude = {SecurityAutoConfiguration.class})
@ComponentScan("creator.controllers")
@ComponentScan("creator.services")
@EntityScan("creator.domains.entities")
@EnableJpaRepositories("databases.repositories")
public class CreatorApplication {

	public static void main(String[] args) {
		ConstantConfig.CreateStatusMessage();
		SpringApplication.run(CreatorApplication.class, args);
	}

}
