package startup;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
@EnableAutoConfiguration
public class Program {
	public static void main(String[] args) {
		SpringApplication app = new SpringApplication(Program.class);
		app.run(args);
	}
}
