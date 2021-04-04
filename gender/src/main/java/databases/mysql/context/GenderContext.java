package databases.mysql.context;

import databases.mysql.repositories.ILanguageRepository;
import org.springframework.boot.SpringApplication;
import org.springframework.context.ApplicationContext;
import lombok.RequiredArgsConstructor;

@RequiredArgsConstructor
public class GenderContext {
	private ILanguageRepository languages;
	
	public GenderContext(String[] args) {
		ApplicationContext context = SpringApplication.run(GenderContext.class, args);
		languages = context.getBean(ILanguageRepository.class);
	}

	public ILanguageRepository getLanguages() {
		return languages;
	}
}
