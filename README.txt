Instruções
-------

1. Abra o arquivo CarrierProjSolution.sln localizado na pasta raiz do repositório*.
2. O projeto atual roda em banco local em uma versão light. 
Caso deseje rodar no SQL server, altere a connection string no arquivo web.config que está dentro da pasta CarrierProj. 
Neste caso é necessário criar um banco previamente.
3. Dê Build no projeto (ctrl+shift+b).
4. No Package Manager Console digite update-database**.
5. Rode o projeto.

*Podem aparecer mensagens de erro devido a diferentes versões do Visual Studio. Este projeto foi desenvolvido com o VS2015 Community Edition.
**Caso ocorra erro ao rodar a migração, será necessário reinstalar packages. 
Através do Manager NuGet Packages for Solution desinstal e Microsoft.AspNet.Identity.EntityFramework  e o EntityFramework.
Instale na ordem inversa da desinstalação. Build e rode novamente o update-database.

---------
Contato: lfaggiani@gmail.com
Leonardo Faggiani
