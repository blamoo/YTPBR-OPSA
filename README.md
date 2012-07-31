Projeto YTPBR - OPSA
====================

O que significa OPSA?
---------------------

Significa PRERIGO. Brincadeira, significa "O Pacote de Scripts da Ave".
Criativo, não?

Como instalar?
--------------

Copie os arquivos .cs dentro de uma das pastas a seguir:

	<Documentos>\Vegas Script Menu\ (se necessário, crie-a)
	<Pasta de instalação do Vegas>\Script Menu

como usar?
----------

1. Abra o Vegas
2. Acesse o menu `Tools > Scripting` ou `Tools > Scripting > ytpbr-opsa`
3. Selecione o script desejado

Se o Vegas já estava aberto quando os arquivos foram copiados, ou se os scripts não aparecerem no menu tente isso:

1. Acesse a opção `Tools > Scripting > Rescan Script Menu Folder`
2. Acesse o menu `Tools > Scripting` ou `Tools > Scripting > ytpbr-opsa`
3. Selecione o script desejado

Se mesmo assim os scripts não aparecerem na lista, tente instalar o pacote em uma das pastas alternativas ou use-os através da opção `Tools > Scripting > Run Script...`.

Em último caso, entre em contato comigo.

Quais scripts estão disponíveis?
--------------------------------

No momento temos 6 scripts no pacote:

* Agrupar eventos de duas faixas.cs
* Aplicar fade aos eventos selecionados.cs
* Selecionar eventos intercalados nas faixas selecionadas.cs
* Selecionar eventos pares nas faixas selecionadas.cs
* Selecionar eventos ímpares nas faixas selecionadas.cs
* Tremer evento de vídeo selecionado.cs

O que eles fazem?
-----------------

#### Agrupar eventos de duas faixas.cs
--------------------------------------

##### Função
Agrupa eventos em sequência em duas faixas selecionadas em uma lista.
	
##### Exemplo de uso
Útil para recuperar o agrupamento das faixas de áudio e vídeo de um MV.
	
#### Aplicar fade aos eventos selecionados.cs
----------------------------------------------

##### Função
Aplica fade in e fade out a todos os eventos selecionados no projeto.

#####  Exemplo de uso
Aplicar um fade pequeno (de 10ms por exemplo) no início e no final de um evento de áudio pode reduzir os "estalos" que ocorrem entre um evento e outro.

#### Selecionar eventos intercalados nas faixas selecionadas.cs
---------------------------------------------------------------

##### Função
Seleciona eventos intercalados nas faixas selecionadas, definindo-se o intervalo entre as faixas e o ínidice de início (Que começa em 0 e deve ser menor que o intervalo). Por exemplo:
>Selecionar de 3 em 3 eventos, começando pelo 1º (Evento 0)
>Selecionar de 5 em 5 eventos, começando pelo 3º (Evento 2)

##### Exemplo de uso
Criar um efeito de virar a imagem de um lado para o outro a cada nota (efeito muito utilizado em MVs)

##### Observação
Os scripts `Selecionar eventos ímpares nas faixas selecionadas.cs` e `Selecionar eventos pares nas faixas selecionadas.cs` são apenas atalhos para essa funcionalidade, com parâmetros `Intervalo: 2; Início: 0` e `Intervalo: 2; Início: 1` respectivamente.


#### Tremer evento de vídeo selecionado.cs
------------------------------------------

##### Função
Cria keyframes aleatórios no primeiro evento selecionado (de cima pra baixo, da esquerda para a direita no projeto).

Os valores aleatórios que podem ser alterados são: posição, tamanho do quadro e rotação.

O script também permite definir a distância entre os keyframes e aumentar/diminuir a intensidade das modificações ao longo do evento.

##### Exemplo de uso
Criar um efeito de terremoto, de instabilidade no movimento de uma câmera empunhada ou de explosão.

Perguntas frequentes
--------------------

##### Como você tem uma lista de perguntas frequentes se acabou de lançar isso?
Ok, eu menti. Só estou tentando prever peguntas simples...

##### Não entendi como um script funciona. Me explica?
Pretendo fazer vídeos explicando o uso do pacote, mas ainda não tenho nada planejado. Leia a descrição com atenção e em último caso, entre em contato.

##### Uso Vegas versão -30.0. Por que os scripts não funcionam?
Os scripts foram testados e desenvolvidos no Vegas 10.0, e as mudanças no motor de scripts não foram tão drásticas desde o Vegas 8.0. Se você tiver algum problema de incompatibilidade, entre em contato.

##### Faz um script de &lt;alguma coisa&gt;?
Se os recursos do Vegas permitirem, faço sim. Entre em contato e sugira :)

##### No céu tem pão?
Piada interna, negativo.

Avisos
-----

* Scripts mal-intencionados podem danificar seu computador, pois podem usar os mesmo recursos de uma aplicação baseada em .NET Framework.
* As versões disponibilizadas no endereço oficial (indicado no final desse arquivo) são extremamente seguras, desde que usadas **sem nenhuma modificação**.
* Mesmo assim, não me responsabilizo pelos efeitos do uso desses scripts.
* Se possível, salve seu projeto antes de usar um script.
* O código fonte dos scripts (arquivos com extensão .cs) pode ser lido com um editor de texto comum (Bloco de notas, Notepad++, Visual Studio). Sinta-se à vontade para lê-lo e entendê-lo.
* Caso tenha alguma experiência com desenvolvimento em linguagem C#, faça as modificações que quiser nos scripts, e se possível me envie sua sugestão :)

Endereço oficial do projeto
---------------------------
[YTPBR-OPSA no GitHub](http://github.com/Blamoo/ytpbr-opsa)

Contato
-------
* Email: <blamooBR@gmail.com>
* Twitter: <http://twitter.com/_Blamoo>
* YouTube: <http://youtube.com/daruuza>