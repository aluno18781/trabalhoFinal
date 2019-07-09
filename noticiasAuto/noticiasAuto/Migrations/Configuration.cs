namespace noticiasAuto.Migrations
{
    using noticiasAuto.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<noticiasAuto.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(noticiasAuto.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.



            var equipas = new List<Equipas> {
                new Equipas { IdEquipa = 1, Nome = "Fiat", DataFundacao = new DateTime(1989, 06, 1), Logo = "fiat.jfif", Fundador = "Giovanni Agnelli", Nacionalidade = "Turim, It�lia", },
                new Equipas { IdEquipa = 2, Nome = "Audi", DataFundacao = new DateTime(1909, 06, 16), Logo = "audi.jpg", Fundador = "August Horch", Nacionalidade = "Ingolstadt, Alemanha" },
                new Equipas { IdEquipa = 3, Nome = "Ford", DataFundacao = new DateTime(1903, 06, 16), Logo = "ford.jpg", Fundador = "Henry Ford", Nacionalidade = "Dearborn, Michigan, Estados Unidos" },
                new Equipas { IdEquipa = 4, Nome = "Ferrari", DataFundacao = new DateTime(1939, 09, 13), Logo = "ferrari.jpg", Fundador = "Enzo Ferrari", Nacionalidade = "Maranello, It�lia" },
                new Equipas { IdEquipa = 5, Nome = "Citro�n", DataFundacao = new DateTime(1919, 01, 1), Logo = "Citro�n.jpg", Fundador = "Andr� Citro�n", Nacionalidade = "Paris, Fran�a" },
                new Equipas { IdEquipa = 6, Nome = "Mitsubishi", DataFundacao = new DateTime(1870, 01, 1), Logo = "Mitsubishi.jpg", Fundador = "Yataro Iwasaki", Nacionalidade = "T�quio, Jap�o" },
                new Equipas { IdEquipa = 7, Nome = "Subaru", DataFundacao = new DateTime(1953, 05, 7), Logo = "Subaru.jpg", Fundador = "Kenji Kita Chikuhei Nakajima", Nacionalidade = "Ota,Gunma, Jap�o" },
                new Equipas { IdEquipa = 8, Nome = "Mercedes", DataFundacao = new DateTime(1926, 01, 1), Logo = "mercedes.jpg", Fundador = "Karl Benz", Nacionalidade = "Stuttgart, Alemanha" },
                new Equipas { IdEquipa = 9, Nome = "Toyota", DataFundacao = new DateTime(1926, 01, 1), Logo = "toyota-logo.jpg", Fundador = "Kiichiro Toyoda", Nacionalidade = "Toyota, Aichi, Jap�o" },
                new Equipas { IdEquipa = 10, Nome = "Alfa Romeo", DataFundacao = new DateTime(1910, 06, 29), Logo = "alfa.jpg", Fundador = "Nicola Romeo, Alexandre Darracq, Alberto Bragaglia", Nacionalidade = "Turim, It�lia" },
                new Equipas { IdEquipa = 11, Nome = "McLaren", DataFundacao = new DateTime(1963, 09, 02), Logo = "McLaren.jpg", Fundador = "Bruce McLaren", Nacionalidade = "Woking, Inglaterra" },
                new Equipas { IdEquipa = 12, Nome = "Renault S.A.", DataFundacao = new DateTime(1989, 02, 25), Logo = "Renault.jpg", Fundador = "Louis Renault, Marcel Renault, Fernand Renault", Nacionalidade = "Boulogne, Fran�a" },
                new Equipas { IdEquipa = 13, Nome = "Haas F1 Team.", DataFundacao = new DateTime(2014, 01, 01), Logo = "Haas.jpg", Fundador = "Gene Haas", Nacionalidade = "Kannapolis, Carolina do Norte, EUA" },
                new Equipas { IdEquipa = 14, Nome = "Red Bull Racing.", DataFundacao = new DateTime(2004, 01, 01), Logo = "Red-Bull-Racing.jpg", Fundador = "Dietrich Mateschitz", Nacionalidade = "Milton Keynes, Reino Unido" },


            };

            equipas.ForEach(ee => context.Equipas.AddOrUpdate(e => e.Nome, ee));
            context.SaveChanges();


            var pilotos = new List<Pilotos> {
                new Pilotos { IdPiloto = 1, Nome = "Marku Allen", DataNascimento = new DateTime(1950, 02, 15), Categoria = "Rally", Nacionalidade = "Finlandesa", Fotografia = "Marku.jpg", EquipaFK = 1 },
                new Pilotos { IdPiloto = 2, Nome = "Walter R�hrl", DataNascimento = new DateTime(1947, 03, 07), Categoria = "Rally", Nacionalidade = "Alem�", Fotografia = "walter.jpg", EquipaFK = 2 },
                new Pilotos { IdPiloto = 3, Nome = "Stig Blomqvist", DataNascimento = new DateTime(1946, 07, 29), Categoria = "Rally", Nacionalidade = "Sueca", Fotografia = "stig.jpg", EquipaFK = 3 },
                new Pilotos { IdPiloto = 4, Nome = "Michael Schumacher", DataNascimento = new DateTime(1969, 01, 3), Categoria = "F1", Nacionalidade = "Alem�", Fotografia = "Schumacher.jpg", EquipaFK = 4 },
                new Pilotos { IdPiloto = 5, Nome = "Sebastan Loeb", DataNascimento = new DateTime(1974, 02, 16), Categoria = "Rally", Nacionalidade = "Francesa", Fotografia = "Loeb.jpg", EquipaFK = 5 },
                new Pilotos { IdPiloto = 6, Nome = "Armindo Ara�jo", DataNascimento = new DateTime(1974, 02, 26), Categoria = "Rally", Nacionalidade = "Portuguesa", Fotografia = "Araujo.jpg", EquipaFK = 6 },
                new Pilotos { IdPiloto = 7, Nome = "Richard Burns", DataNascimento = new DateTime(1971, 01, 17), Categoria = "Rally", Nacionalidade = " Inglesa", Fotografia = "Burns.jpg", EquipaFK = 7 },
                new Pilotos { IdPiloto = 8, Nome = "Bernardo Sousa", DataNascimento = new DateTime(1985, 01, 16), Categoria = "Rally", Nacionalidade = "Portuguesa", Fotografia = "bernardo.jpg", EquipaFK = 5 },
                new Pilotos { IdPiloto = 9, Nome = "Ott T�nak", DataNascimento = new DateTime(1987, 10, 25), Categoria = "Rally", Nacionalidade = "Est�nio ", Fotografia = "tanak.jpg", EquipaFK = 9 },
                new Pilotos { IdPiloto = 10, Nome = "Dani Sordo", DataNascimento = new DateTime(1983, 05, 02), Categoria = "Rally", Nacionalidade = "Espanhola", Fotografia = "sordo.jpg", EquipaFK = 5 },
                new Pilotos { IdPiloto = 11, Nome = "Elfyn Evans", DataNascimento = new DateTime(1988, 12, 28), Categoria = "Rally", Nacionalidade = "Gal�s ", Fotografia = "evans.jpg", EquipaFK = 3 },
                new Pilotos { IdPiloto = 12, Nome = "Esapekka Lappi", DataNascimento = new DateTime(1991, 01, 17), Categoria = "Rally", Nacionalidade = "Finland�s", Fotografia = "lappi.jpg", EquipaFK = 5 },
                new Pilotos { IdPiloto = 13, Nome = "Ken Block", DataNascimento = new DateTime(1967, 11, 21), Categoria = "Rally", Nacionalidade = "Americano", Fotografia = "ken.jpg", EquipaFK = 3 },
                new Pilotos { IdPiloto = 14, Nome = "Kimi Raikkonen", DataNascimento = new DateTime(1979,10,17), Categoria = "F1", Nacionalidade = "Finlandesa", Fotografia = "Kimi_Raikkonen.jpg", EquipaFK = 10 },
                new Pilotos { IdPiloto = 15, Nome = "Lando Norris", DataNascimento = new DateTime(1999,11,13), Categoria = "F1", Nacionalidade = "Inglesa", Fotografia = "lando.jpg", EquipaFK = 11 },
                new Pilotos { IdPiloto = 16, Nome = "Daniel Ricciardo", DataNascimento = new DateTime(1989, 07, 01), Categoria = "F1", Nacionalidade = "Australiana", Fotografia = "daniel.jpg", EquipaFK = 12 },
                new Pilotos { IdPiloto = 17, Nome = "Romain Grosjean", DataNascimento = new DateTime(1986, 04, 17), Categoria = "F1", Nacionalidade = "Francesa", Fotografia = "romain.jpg", EquipaFK = 13 },
                new Pilotos { IdPiloto = 18, Nome = "Pierre Gasly", DataNascimento = new DateTime(1996, 02, 07), Categoria = "F1", Nacionalidade = "Francesa", Fotografia = "Pierre.jpg", EquipaFK = 14 },
            };

            pilotos.ForEach(pp => context.Pilotos.AddOrUpdate(p => p.Nome, pp));
            context.SaveChanges();



            var utilizadores = new List<utilizadores> {
                new utilizadores { IdUser = 1, Nome = "Paulo Sousa", Email = "paulo@sp.pt" },
                new utilizadores { IdUser = 2, Nome = "Paulo Silva", Email = "pauloS@sp.pt" },
                new utilizadores { IdUser = 3, Nome = "Miguel Maria", Email = "mm@sp.pt" },
                new utilizadores { IdUser = 4, Nome = "Jo�o Sousa", Email = "js@sp.pt" },
                new utilizadores { IdUser = 5, Nome = "Sara Cardoso", Email = "sc@sp.pt" },
                new utilizadores { IdUser = 6, Nome = "Guilherme Silva", Email = "gs@sp.pt" },
                new utilizadores { IdUser = 7, Nome = "Ana Costa", Email = "Js@sp.pt" },
                new utilizadores { IdUser = 8, Nome = "Diego Amorim", Email = "Js@sp.pt" },
                new utilizadores { IdUser = 9, Nome = "Lurdes Costa", Email = "Js@sp.pt" },
                new utilizadores { IdUser = 10, Nome = "Fernando Viseu", Email = "Js@sp.pt" },
                new utilizadores { IdUser = 11, Nome = "Fernando Costa", Email = "fCosta@sp.pt" },
                new utilizadores { IdUser = 12, Nome = "Paulo Silva", Email = "paulinho@ss.pt" },
                new utilizadores { IdUser = 13, Nome = "Beatriz Silva", Email = "beas@ds.pt" },
                new utilizadores { IdUser = 14, Nome = "Helena Martins", Email = "PSSSS@sp.pt" },
                new utilizadores { IdUser = 15, Nome = "Pedro Silva", Email = "PSSSS@sp.pt" },

            };

            utilizadores.ForEach(uu => context.utilizadores.AddOrUpdate(u => u.Nome, uu));
            context.SaveChanges();





            var noticias = new List<Noticias> {
                new Noticias { IdNoticia = 1,  ListaDeEquipas = new List<Equipas>{equipas[6] }, Fotografia = "araujoNotica.jpg", Titulo = "CPR, RALI DE MORT�GUA, ARMINDO ARA�JO: �BOM RESULTADO, MAS TEMOS DE TRABALHAR", Conteudo = "Em entrevista ao Autosport, Armindo Ara�jo felicitou os vencedores do rali de Mort�gua, tamb�m mostrando-se satisfeito com os pontos amealhados do segundo lugar. Ara�jo tamb�m fala na extrema competitividade do Campeonato de Portugal de Ralis. Oi�a aqui.", UserFK= 1 },
                new Noticias { IdNoticia = 2, ListaDeEquipas = new List<Equipas>{equipas[2] }, Fotografia = "burnsNoticia.jpg", Titulo = "LEMBRA-SE DE: RICHARD BURNS, O PRIMEIRO INGL�S A VENCER O MUNDIAL DE RALIS� ", Conteudo = "Foi no dia de hoje, h� precisamente 17 anos, em 2001, que Richard Burns e Robert Reid asseguraram a conquista do seu t�tulo Mundial de Ralis. O terceiro lugar no Rali da Gr�-Bretanha foi o suficiente, depois de Colin McRae ter abandonado a prova. Foi o primeiro, e �nico at� hoje, piloto ingl�s, que n�o brit�nico (esse foi o escoc�s Colin McRae em 1995) a ser Campe�o do Mundo de Ralis.Nesse dia, habitualmente bastante reservado em p�blico, Richard Burns colocou de parte a sua tradicional �fleuma� e deu largas ao seu contentamento no final do Rali da Gr�-Bretanha. � que, ao cabo e ao resto, o piloto da Subaru tinha acabado de se sagrar Campe�o do Mundo de Ralis, isto depois de ter sido vice-campe�o em 1999 e 2000.r isso, as primeiras palavras que proferiu na altura refletiam bem o estado de esp�rito do ingl�s: �Sinto-me fant�stico! Havia uma press�o enorme antes do rali ir para a estrada, press�o vinda de todas as partes, e chegar ao fim da prova com este resultado � absolutamente incr�vel. Sinto pena em n�o garantir o t�tulo com uma vit�ria no �meu� rali mas, ap�s as desist�ncias dos meus advers�rios, a estrat�gia teve que ser alterada para n�o corrermos riscos desnecess�rios. Mais que chegar � vit�ria, tinha a possibilidade de ser Campe�o do Mundo! A conquista do t�tulo representa o trabalho e empenho de toda a equipa, que est� de parab�ns.�Makinen e McRae desistiram cedo: Adeus t�tulo� e recordeAo contr�rio do que tinha acontecido nos cinco anos anteriores, o t�tulo mundial n�o foi para a Finl�ndia! � partida para este Rali da Gr�-Bretanha de 2001, Tommi Makinen e Colin McRae � tal como Carlos Sainz � tinham dois objectivos, mesmo se um deles n�o passava de secund�rio: sagrar-se Campe�o do Mundo e, de permeio, estabelecer o novo recorde de vit�rias em provas do �Mundial� de Ralis. E melhor cen�rio n�o poderia existir, pois o Rali da Gr�-Bretanha era o palco onde quatro pilotos tinham pretens�es ao t�tulo, dos quais tr�s poderiam ascender � t�o procurada 24� vit�ria.Sabia-se que Richard Burns e McRae eram apontados como favoritos para vencer em �casa�, mas foi do lado de Makinen que veio a primeira �surpresa�: abandonou na segunda classificativa, ap�s ter batido numa pedra, que danificou a suspens�o do Lancer Evolution WRC e arrancou uma roda ao carro japon�s. Mas ainda a not�cia do abandono do finland�s estava a ser digerida e o �Mundial� perdia um segundo pretendente ao �ceptro�, pois Colin McRae saiu de estrada na classificativa seguinte: �Tudo aconteceu numa curva para a direita, muito r�pida, onde McRae perdeu o controlo do Focus WRC e capotou por quatro vezes, antes de se imobilizar. Quer o piloto como o navegador nada sofreram�, explicou um desalentado Malcolm Wilson.", UserFK = 1 },
                new Noticias { IdNoticia = 3, ListaDeEquipas = new List<Equipas>{equipas[1] }, Fotografia = "SCHUMACHERNoticia.jpg", Titulo = "F1: MICHAEL SCHUMACHER TER� DOCUMENT�RIO", Conteudo = "Um document�rio oficial sobre Michael Schumacher, totalmente apoiado pela fam�lia, ser� lan�ado ainda este ano.Intitulado de �Schumacher�, o filme � apoiado por uma grande produtora e apresenta entrevistas com o pai de Michael, Rolf, a sua esposa Corinna, os filhos Gina e Mick e outras pessoas essenciais na carreira do alem�o. Tamb�m conta com imagens de arquivo da carreia de Schumacher.A Rocket Science, sediada em Londres, � a produtora executiva e a respons�vel pelas vendas internacionais, sendo que pretende come�ar a comercializar o filme no festival de cinema de Cannes.", UserFK= 1 },
                new Noticias { IdNoticia = 4, ListaDeEquipas = new List<Equipas>{equipas[1] }, Fotografia = "MarkuNoticia.jpg", Titulo = "Markku Alen. O penta campe�o do Rali de Portugal em Castelo Rodrigo", Conteudo = "Markku Alen vai estar em Figueira de Castelo Rodrigo para proporcionar um grande espect�culo na prova m�tica nacional que este ano assinala duas d�cadas.", UserFK = 1 },
                new Noticias { IdNoticia = 5, ListaDeEquipas = new List<Equipas>{equipas[4] }, Fotografia = "StigBlomqvistNoticia.jpg", Titulo = "Recorde quando Blomqvist voou a 189 km/h na Argentina", Conteudo = "Come�a a 25 de abril mais uma edi��o do Rali da Argentina, e a organiza��o do Mundial recordou um dos seus momentos mais impressionantes. Falamos de quando Stig Blomqvist e o Audi Quattro terminaram a primeira especial com uma velocidade m�dia (!) de 189,53 km/hH� feitos que ficam na hist�ria de competi��o e a forma como Stig Blomqvist voou sobre a terra batida da Argentina em 1983 � um deles. O site do WRC recordou agora esta hist�ria fant�stica, que aqui lhe trazemos. O protagonista � Stig Blomqvist que, por correr o Campeonato Brit�nico em simult�neo, chegou � prova do WRC em cima do arranque, sem oportunidade de fazer o reconhecimento com o Audi Quattro. A solu��o foi usar as notas do navegador do seu colega de equipa, Hannu Mikkola.Tenha sido das notas, do jet lag ou por qualquer outro motivo, aquilo que Blomqvist fez � not�vel. Foram 81km cumpridos de forma alucinante, em apenas 25 minutos e 48 segundos. Daqui resultou uma incr�vel m�dia de 189,53 km/h, ainda mais impressionante se considerarmos que a afina��o do seu Audi Quattro colocava a velocidade m�xima nos 210 km/h. Ou seja, o ponteiro do veloc�metro deve ter estado a maior parte do tempo bem colado ao limite e o das rota��es pouco tempo passou fora do redline!Al�m de recordar este feito, o WRC recordou tamb�m que a m�dia de velocidade mais alta para todo um rali data de 2016. O autor foi Kris Meeke, com o seu Citr�en C3 WRC a terminar a corrida na Finl�ndia com um balan�o de 126,62 km/h. Mais uma prova que o piloto brit�nico � bastante r�pido. O problema mesmo � manter-se dentro dos limites da estrada�", UserFK= 1 },
                new Noticias { IdNoticia = 6, ListaDeEquipas = new List<Equipas>{equipas[9] }, Fotografia = "tanakNoticia.jpg", Titulo = "WRC/Rali da Sardenha: Sordo herdou triunfo ap�s azar tardio de Tanak", Conteudo = "Diz uma das leis fundamentais do automobilismo que para terminar em primeiro lugar, primeiro � preciso terminar. Esta norma estar� hoje na cabe�a de Ott Tanak, da Toyota, que perdeu o Rali da Sardenha precisamente na derradeira especial da prova. Pelo lado contr�rio, sabendo estar onde era preciso, Dani Sordo (Hyundai) herdou o triunfo, apenas o segundo da sua carreira no Mundial de Ralis (WRC).S�bado tinha sido um dia perfeito para o est�nio da Toyota Gazoo Racing, tendo vencido todos os tro�os da etapa e, no domingo, esperava-se que fosse apenas a confirma��o de mais um triunfo, dando sequ�ncia �quele obtido em Portugal.No entanto, na �Power Stage�, para a qual partiu com cerca de meio minuto de vantagem sobre Sordo, um problema com o sistema de dire��o assistida tornou o modelo nip�nico praticamente incontrol�vel a ritmos elevados, chegando ao final daquela especial com um atraso de dois minutos face ao homem da Hyundai. Com isso, caiu para o quinto posto, o que lhe concedeu os pontos necess�rios, ainda assim, para saltar para o comando do Mundial de Pilotos, por troca com S�bastien Ogier(Citro�n), que teve uma prova verdadeiramente para esquecer.", UserFK= 1 },
                new Noticias { IdNoticia = 7, ListaDeEquipas = new List<Equipas>{equipas[0] }, Fotografia = "PIERREnoticia.jpg", Titulo = "Pierre Gasly", Conteudo = "Pierre Gasly tem at� � pausa de ver�o para melhorar a sua presta��o na Red Bull, de acordo com o Dr. Helmut Marko. Desde que saiu de Toro Rosso para substituir Daniel Ricciardo, o franc�s tem estado uns furos abaixo do seu colega de equipa, Max Verstappen. Na �ustria, por exemplo, Verstappen venceu enquanto Gasly ficou em s�timo lugar, tendo sido dobrado pelo companheiro de equipa:Isso pode ser parcialmente explicado pelo facto de termos uma nova asa dianteira, o que foi um grande passo, mas infelizmente s� nos restava uma para a corrida e foi o Max Verstappen que a utilizou. No entanto, Gasly tem de melhorar, especialmente nas ultrapassagens.Ele tem de cumprir at� �s f�rias de Ver�o.", UserFK= 1 },
                new Noticias { IdNoticia = 8, ListaDeEquipas = new List<Equipas>{equipas[13] }, Fotografia = "romain-grosjeannoticia.jpg", Titulo = "GP FRAN�A F1, ROMAIN GROSJEAN: PARAR DE CULPAR OS PNEUS�", Conteudo = "Romain Grosjean acredita que a Haas precisa de parar de culpar os pneus e come�ar a culpar-se a si mesmo depois do que aconteceu na qualifica��o para o Grande Pr�mio de Fran�a.Depois de ambos os pilotos da Haas n�o se terem classificado entre os 10 primeiros em Fran�a, Grosjean, que foi eliminado na Q1, disse que a equipa precisa de assumir a responsabilidade:-Penso que temos de parar de culpar os pneus e come�ar a culpar - nos a n�s. Estiveram 50 graus[temperatura da pista] hoje e � muita energia no circuito.Por isso, n�o temos qualquer desculpa para n�o aquecer os pneus.Depois da qualifica��o Grosjean, o seu companheiro de equipa Kevin Magnussen e o patr�o da equipa Gunther Steiner admitiram que n�o sabiam o porqu� da falta de desempenho em Paul Ricard.", UserFK= 2 },
                new Noticias { IdNoticia = 9, ListaDeEquipas = new List<Equipas>{equipas[3]}, Fotografia = "block-chamasNoticia.jpg", Titulo = "Ken Block fez um churrasco� com o seu Escort RS Cosworth", Conteudo = "Ainda se recorda da passagem de Ken Block pelo Mundial de Rallies? A aventura foi marcante em diversos locais do globo, como Portugal. E por marcante queremos aqui dizer que o americano deixou marcas (e muitas vezes at� partes do carro) em especiais, ao que juntou alguma falta de competitividade. Por estes motivos, n�o esteve muitos anos com a Ford na categoria de topo dos campeonatos de rali. Agora o piloto, que ser� para sempre recordado pelos incr�veis v�deos de drift e Gymkhanas, mostrou novamente que as coisas nem sempre lhe correm bem, pois teve um acidente que acabou com um inc�ndio e a total destrui��o do Ford Escort RS Cosworth.", UserFK= 5 },
                new Noticias { IdNoticia = 10, ListaDeEquipas = new List<Equipas>{equipas[11] }, Fotografia = "slandoNorrisNoticia.jpg", Titulo = "Seidl impressionado com a velocidade de Norris: O mais importante � a velocidade bruta", Conteudo = "Andreas Seidl descreveu a atual dupla de pilotos, Carlos Sainz e Lando Norris, da equipe McLaren, como o futuro deste time, e acredita que Norris mostrou sua velocidade desde a primeira corrida.Lando Norris disputou roda a roda com Lewis Hamilton no in�cio do Grande Pr�mio da �ustria, mas terminou em sexto, apenas um lugar atr�s de seu compatriota. Enquanto isso, Sainz se recuperou do 19� no grid depois de receber uma penalidade, para terminar em oitavo lugar.Foi a segunda corrida consecutiva que ambos os pilotos se colocaram entre os dez primeiros.Ambos os pilotos est�o em sua primeira temporada com a McLaren, sendo esta a primeira temporada de Norris na F1.Ap�s a corrida no Red Bull Ring, Seidl elogiou a dupla e olhou para o futuro.Estou muito feliz com os dois pilotos e eles ser�o o futuro desta equipe, disse Seidl, citado pela Sky Sports.Seidl tamb�m destacou Norris por seu ritmo bruto e destacou sua consist�ncia, acrescentando: O mais importante � a velocidade bruta, que � a base de todo piloto de sucesso.Ele mostrou desde a primeira corrida que tinha essa velocidade, completou.", UserFK= 6 },
                new Noticias { IdNoticia = 11, ListaDeEquipas = new List<Equipas>{equipas[3] }, Fotografia = "evansNoticia.jpg", Titulo = "WRC, RALI ARGENTINA, PE10: GRANDE ACIDENTE DE ELFYN EVANS", Conteudo = "Elfyn Evans/Scott Martin sa�ram de estrada na PE10, danificando muito o seu Ford Fiesta WRC. O piloto entrou num longo slide, numa zona r�pida, e por azar a frente do carro foi bater numa enorme pedra, a �nica que se encontrava na berma, e logo com um tamanho muito significativo. A dupla ficou chocalhada, mas fisicamente bem. � que o impacto foi mesmo muito forte.", UserFK= 7 },
                new Noticias { IdNoticia = 12, ListaDeEquipas = new List<Equipas>{equipas[10] }, Fotografia = "raikkonen.noticia.jpg", Titulo = "F1: KIMI RAIKKONEN E A DIFICULDADE DE PILOTAR UM F�RMULA 1", Conteudo = "Kimi Raikkkonen considera que a F�rmula 1 tornou-se mais f�cil comparada com anos anteriores. A meio das discuss�es para as novas regras para a temporada de 2021, alguns pilotos j� fizeram conhecer que gostariam que a F�rmula 1 fosse um desafio mais f�sico.Kimi Raikkkonen tamb�m se pronunciou acerca deste assunto, dizendo que n�o sabia determinar ao certo se antigamente era mais dif�cil ou n�o:� mais dif�cil agora ou menos dif�cil? � imposs�vel de dizer.Quando come�as a pensar como era h� 10 anos, a mem�ria prega - te partidas e n�o te consegues lembrar corretamente.Mas, � como tudo, acabas por te acostumar.Kimi Raikkkonen estreou - se na F�rmula 1 em 2001, aos 21 anos, vindo direto da F�rmula Renault.Conduziu carros com motores V10, V8 e os V6 turbo - hibridos de agora, passou das regras de reabastecimento at� a n�o poder reabastecer:O experiente piloto tamb�m sugeriru a redu��o da dire��o assistida para dificultar um pouco a condu��o dos monolugares.", UserFK= 8 },
                new Noticias { IdNoticia = 13, ListaDeEquipas = new List<Equipas>{equipas[6] }, Fotografia = "araujoNoticia2.jpg", Titulo = "RALI DE PORTUGAL: ARMINDO ARA�JO FALA EM MISS�O CUMPRIDA NO NACIONAL", Conteudo = "Armindo Ara�jo (Hyundai i20) considerou hoje ter 'a primeira parte da miss�o cumprida', depois de ter assegurado a vit�ria no Rali de Portugal entre os pilotos do Nacional, cuja classifica��o ficou fechada ap�s o �ltimo tro�o desta manh�.'Vencer nunca � f�cil, mas correu-nos bastante bem. Entr�mos bem no rali, com um bom ritmo. O carro foi um forte aliado e hoje tamb�m estivemos a ver os nossos advers�rios � dist�ncia. Foi uma boa opera��o para o Campeonato de Portugal de ralis, at� porque fizemos a dobradinha, disse o piloto � ag�ncia Lusa.Armindo Ara�jo destacava o facto de o companheiro de equipa, Bruno Magalh�es, ter arrebatado o segundo lugar na prova ao l�der do campeonato, Ricardo Teod�sio(Skoda Fabia), na derradeira especial.", UserFK= 9 },

            };

            noticias.ForEach(nn => context.Noticias.AddOrUpdate(n => n.Titulo, nn));
            context.SaveChanges();


            var comentarios = new List<Comentarios> {
                new Comentarios { IdComentario = 1, Conteudo = "Ara�jo a maior maquina de sempre", NoticiaFK = 1, UserFK = 1 },
                new Comentarios { IdComentario = 2, Conteudo = "RICHARD BURNS????quem n�o lembra?", NoticiaFK = 2, UserFK = 1 },
                new Comentarios { IdComentario = 3, Conteudo = "Document�rio?quando vai sair?", NoticiaFK = 3, UserFK = 2 },
                new Comentarios { IdComentario = 4, Conteudo = "Markku Alen?campe�o?mas ele sabe conduzir????", NoticiaFK = 4, UserFK = 2 },
                new Comentarios { IdComentario = 5, Conteudo = "189km? n � possivel....", NoticiaFK = 5, UserFK = 3 },
                new Comentarios { IdComentario = 6, Conteudo = "Sordo herdou triunfo ap�s azar tardio de Tanak......ahahahaha que piada...meu deus", NoticiaFK = 6, UserFK = 4 },
                new Comentarios { IdComentario = 7, Conteudo = "Devia descansar de vez disto...", NoticiaFK = 7, UserFK = 5 },
                new Comentarios { IdComentario = 8, Conteudo = "PNEUS...................", NoticiaFK = 8, UserFK = 6 },
                new Comentarios { IdComentario = 9, Conteudo = "Ken Block fez um churrasco�? ahahahahhah", NoticiaFK = 9, UserFK = 7 },
                new Comentarios { IdComentario = 10, Conteudo = "velocidade bruta?ahahahha", NoticiaFK = 10, UserFK = 8 },
                new Comentarios { IdComentario = 11, Conteudo = "uiiiiiiiiiii", NoticiaFK = 11, UserFK = 9 },
                new Comentarios { IdComentario = 12, Conteudo = "f1 n�o � para todos n�o", NoticiaFK = 12, UserFK = 10 },
                new Comentarios { IdComentario = 13, Conteudo = "ARMINDO ARA�JO a maquina de portugal", NoticiaFK = 13, UserFK = 10 },

            };

            comentarios.ForEach(cc => context.Comentarios.AddOrUpdate(c => c.Utilizador, cc));
            context.SaveChanges();


        }
    }
}
    
