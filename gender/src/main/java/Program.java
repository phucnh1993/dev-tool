import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import databases.mysql.context.GenderContext;
import lombok.RequiredArgsConstructor;
import lombok.var;

@SpringBootApplication
@RequiredArgsConstructor
public class Program {
	public static void main(String[] args) {
		SpringApplication.run(Program.class, args);
		GenderContext gender = new GenderContext(args);
		var language = gender.getLanguages();
		var data = language.findAll();
		System.out.println(data);
	}
}
