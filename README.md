# LLLDeslocamento
AppDeslocamento


Usar bando de dados no SQL Manager:
	"AppDbContext": "Server=localhost;Database=llldeslocamento;Trusted_Connection=False;"


Usar bando de dados no Docker: 
	"AppDbContext": "Server=localhost,49154;Database=llldeslocamento;Trusted_Connection=False;User Id=sa;Password=Alunos@123;"


Migrations:

First use:

	- dotnet tool install --global dotnet-ef

Criar migrations:

	- dotnet ef migrations add <nome para migration> --project .\AppDeslocamento.Data --startup-project .\AppDeslocamento.WebAPI --context AppDbContext

Executar e atualizar migrations:

	- dotnet ef database update --project .\AppDeslocamento.Data --startup-project .\AppDeslocamento.WebAPI --context AppDbContext
