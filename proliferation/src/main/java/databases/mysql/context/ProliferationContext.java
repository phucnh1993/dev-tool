package databases.mysql.context;

import databases.mysql.repositories.ILanguageRepository;
import org.springframework.boot.SpringApplication;
import org.springframework.context.ApplicationContext;
import lombok.RequiredArgsConstructor;

@RequiredArgsConstructor
public class ProliferationContext {
	private ILanguageRepository languages;
	
	public ProliferationContext(String[] args) {
		ApplicationContext context = SpringApplication.run(ProliferationContext.class, args);
		languages = context.getBean(ILanguageRepository.class);
	}

	public ILanguageRepository getLanguages() {
		return languages;
	}
}
