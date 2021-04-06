package startup;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.jdbc.DataSourceAutoConfiguration;
import org.springframework.boot.autoconfigure.jdbc.DataSourceTransactionManagerAutoConfiguration;
import org.springframework.boot.autoconfigure.orm.jpa.HibernateJpaAutoConfiguration;

@SpringBootApplication
@EnableAutoConfiguration(exclude={DataSourceAutoConfiguration.class, 
		DataSourceTransactionManagerAutoConfiguration.class,
		HibernateJpaAutoConfiguration.class })
public class Program {
	public static void main(String[] args) {
		SpringApplication app = new SpringApplication(Program.class);
		app.run(args);
	}
}
