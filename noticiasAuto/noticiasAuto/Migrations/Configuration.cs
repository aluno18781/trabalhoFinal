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
                new Equipas { IdEquipa = 1, Nome = "Fiat", DataFundacao = new DateTime(1989, 06, 1), Logo = "fiat.jfif", Fundador = "Giovanni Agnelli", Nacionalidade = "Turim, Itália", },
                new Equipas { IdEquipa = 2, Nome = "Audi", DataFundacao = new DateTime(1909, 06, 16), Logo = "audi.jpg", Fundador = "August Horch", Nacionalidade = "Ingolstadt, Alemanha" },
                new Equipas { IdEquipa = 3, Nome = "Ford", DataFundacao = new DateTime(1903, 06, 16), Logo = "ford.jpg", Fundador = "Henry Ford", Nacionalidade = "Dearborn, Michigan, Estados Unidos" },
                new Equipas { IdEquipa = 4, Nome = "Ferrari", DataFundacao = new DateTime(1939, 09, 13), Logo = "ferrari.jpg", Fundador = "Enzo Ferrari", Nacionalidade = "Maranello, Itália" },
                new Equipas { IdEquipa = 5, Nome = "Citroën", DataFundacao = new DateTime(1919, 01, 1), Logo = "Citroën.jpg", Fundador = "André Citroën", Nacionalidade = "Paris, França" },
                new Equipas { IdEquipa = 6, Nome = "Mitsubishi", DataFundacao = new DateTime(1870, 01, 1), Logo = "Mitsubishi.jpg", Fundador = "Yataro Iwasaki", Nacionalidade = "Tóquio, Japão" },
                new Equipas { IdEquipa = 7, Nome = "Subaru", DataFundacao = new DateTime(1953, 05, 7), Logo = "Subaru.jpg", Fundador = "Kenji Kita Chikuhei Nakajima", Nacionalidade = "Ota,Gunma, Japão" },
                new Equipas { IdEquipa = 8, Nome = "Mercedes", DataFundacao = new DateTime(1926, 01, 1), Logo = "mercedes.jpg", Fundador = "Karl Benz", Nacionalidade = "Stuttgart, Alemanha" },
                new Equipas { IdEquipa = 9, Nome = "Toyota", DataFundacao = new DateTime(1926, 01, 1), Logo = "toyota-logo.jpg", Fundador = "Kiichiro Toyoda", Nacionalidade = "Toyota, Aichi, Japão" },
                new Equipas { IdEquipa = 10, Nome = "Alfa Romeo", DataFundacao = new DateTime(1910, 06, 29), Logo = "alfa.jpg", Fundador = "Nicola Romeo, Alexandre Darracq, Alberto Bragaglia", Nacionalidade = "Turim, Itália" },
                new Equipas { IdEquipa = 11, Nome = "McLaren", DataFundacao = new DateTime(1963, 09, 02), Logo = "McLaren.jpg", Fundador = "Bruce McLaren", Nacionalidade = "Woking, Inglaterra" },
                new Equipas { IdEquipa = 12, Nome = "Renault S.A.", DataFundacao = new DateTime(1989, 02, 25), Logo = "Renault.jpg", Fundador = "Louis Renault, Marcel Renault, Fernand Renault", Nacionalidade = "Boulogne, França" },
                new Equipas { IdEquipa = 13, Nome = "Haas F1 Team.", DataFundacao = new DateTime(2014, 01, 01), Logo = "Haas.jpg", Fundador = "Gene Haas", Nacionalidade = "Kannapolis, Carolina do Norte, EUA" },
                new Equipas { IdEquipa = 14, Nome = "Red Bull Racing.", DataFundacao = new DateTime(2004, 01, 01), Logo = "Red-Bull-Racing.jpg", Fundador = "Dietrich Mateschitz", Nacionalidade = "Milton Keynes, Reino Unido" },


            };

            equipas.ForEach(ee => context.Equipas.AddOrUpdate(e => e.Nome, ee));
            context.SaveChanges();


            var pilotos = new List<Pilotos> {
                new Pilotos { IdPiloto = 1, Nome = "Marku Allen", DataNascimento = new DateTime(1950, 02, 15), Categoria = "Rally", Nacionalidade = "Finlandesa", Fotografia = "Marku.jpg", EquipaFK = 1 },
                new Pilotos { IdPiloto = 2, Nome = "Walter Röhrl", DataNascimento = new DateTime(1947, 03, 07), Categoria = "Rally", Nacionalidade = "Alemã", Fotografia = "walter.jpg", EquipaFK = 2 },
                new Pilotos { IdPiloto = 3, Nome = "Stig Blomqvist", DataNascimento = new DateTime(1946, 07, 29), Categoria = "Rally", Nacionalidade = "Sueca", Fotografia = "stig.jpg", EquipaFK = 3 },
                new Pilotos { IdPiloto = 4, Nome = "Michael Schumacher", DataNascimento = new DateTime(1969, 01, 3), Categoria = "F1", Nacionalidade = "Alemã", Fotografia = "Schumacher.jpg", EquipaFK = 4 },
                new Pilotos { IdPiloto = 5, Nome = "Sebastan Loeb", DataNascimento = new DateTime(1974, 02, 16), Categoria = "Rally", Nacionalidade = "Francesa", Fotografia = "Loeb.jpg", EquipaFK = 5 },
                new Pilotos { IdPiloto = 6, Nome = "Armindo Araújo", DataNascimento = new DateTime(1974, 02, 26), Categoria = "Rally", Nacionalidade = "Portuguesa", Fotografia = "Araujo.jpg", EquipaFK = 6 },
                new Pilotos { IdPiloto = 7, Nome = "Richard Burns", DataNascimento = new DateTime(1971, 01, 17), Categoria = "Rally", Nacionalidade = " Inglesa", Fotografia = "Burns.jpg", EquipaFK = 7 },
                new Pilotos { IdPiloto = 8, Nome = "Bernardo Sousa", DataNascimento = new DateTime(1985, 01, 16), Categoria = "Rally", Nacionalidade = "Portuguesa", Fotografia = "bernardo.jpg", EquipaFK = 5 },
                new Pilotos { IdPiloto = 9, Nome = "Ott Tänak", DataNascimento = new DateTime(1987, 10, 25), Categoria = "Rally", Nacionalidade = "Estónio ", Fotografia = "tanak.jpg", EquipaFK = 9 },
                new Pilotos { IdPiloto = 10, Nome = "Dani Sordo", DataNascimento = new DateTime(1983, 05, 02), Categoria = "Rally", Nacionalidade = "Espanhola", Fotografia = "sordo.jpg", EquipaFK = 5 },
                new Pilotos { IdPiloto = 11, Nome = "Elfyn Evans", DataNascimento = new DateTime(1988, 12, 28), Categoria = "Rally", Nacionalidade = "Galês ", Fotografia = "evans.jpg", EquipaFK = 3 },
                new Pilotos { IdPiloto = 12, Nome = "Esapekka Lappi", DataNascimento = new DateTime(1991, 01, 17), Categoria = "Rally", Nacionalidade = "Finlandês", Fotografia = "lappi.jpg", EquipaFK = 5 },
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
                new utilizadores { IdUser = 4, Nome = "João Sousa", Email = "js@sp.pt" },
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
                new Noticias { IdNoticia = 1,  ListaDeEquipas = new List<Equipas>{equipas[6] }, Fotografia = "araujoNotica.jpg", Titulo = "CPR, RALI DE MORTÁGUA, ARMINDO ARAÚJO: “BOM RESULTADO, MAS TEMOS DE TRABALHAR", Conteudo = "Em entrevista ao Autosport, Armindo Araújo felicitou os vencedores do rali de Mortágua, também mostrando-se satisfeito com os pontos amealhados do segundo lugar. Araújo também fala na extrema competitividade do Campeonato de Portugal de Ralis. Oiça aqui.", UserFK= 1 },
                new Noticias { IdNoticia = 2, ListaDeEquipas = new List<Equipas>{equipas[2] }, Fotografia = "burnsNoticia.jpg", Titulo = "LEMBRA-SE DE: RICHARD BURNS, O PRIMEIRO INGLÊS A VENCER O MUNDIAL DE RALIS” ", Conteudo = "Foi no dia de hoje, há precisamente 17 anos, em 2001, que Richard Burns e Robert Reid asseguraram a conquista do seu título Mundial de Ralis. O terceiro lugar no Rali da Grã-Bretanha foi o suficiente, depois de Colin McRae ter abandonado a prova. Foi o primeiro, e único até hoje, piloto inglês, que não britânico (esse foi o escocês Colin McRae em 1995) a ser Campeão do Mundo de Ralis.Nesse dia, habitualmente bastante reservado em público, Richard Burns colocou de parte a sua tradicional ‘fleuma’ e deu largas ao seu contentamento no final do Rali da Grã-Bretanha. É que, ao cabo e ao resto, o piloto da Subaru tinha acabado de se sagrar Campeão do Mundo de Ralis, isto depois de ter sido vice-campeão em 1999 e 2000.r isso, as primeiras palavras que proferiu na altura refletiam bem o estado de espírito do inglês: “Sinto-me fantástico! Havia uma pressão enorme antes do rali ir para a estrada, pressão vinda de todas as partes, e chegar ao fim da prova com este resultado é absolutamente incrível. Sinto pena em não garantir o título com uma vitória no ‘meu’ rali mas, após as desistências dos meus adversários, a estratégia teve que ser alterada para não corrermos riscos desnecessários. Mais que chegar à vitória, tinha a possibilidade de ser Campeão do Mundo! A conquista do título representa o trabalho e empenho de toda a equipa, que está de parabéns.”Makinen e McRae desistiram cedo: Adeus título… e recordeAo contrário do que tinha acontecido nos cinco anos anteriores, o título mundial não foi para a Finlândia! À partida para este Rali da Grã-Bretanha de 2001, Tommi Makinen e Colin McRae – tal como Carlos Sainz – tinham dois objectivos, mesmo se um deles não passava de secundário: sagrar-se Campeão do Mundo e, de permeio, estabelecer o novo recorde de vitórias em provas do “Mundial” de Ralis. E melhor cenário não poderia existir, pois o Rali da Grã-Bretanha era o palco onde quatro pilotos tinham pretensões ao título, dos quais três poderiam ascender à tão procurada 24ª vitória.Sabia-se que Richard Burns e McRae eram apontados como favoritos para vencer em “casa”, mas foi do lado de Makinen que veio a primeira “surpresa”: abandonou na segunda classificativa, após ter batido numa pedra, que danificou a suspensão do Lancer Evolution WRC e arrancou uma roda ao carro japonês. Mas ainda a notícia do abandono do finlandês estava a ser digerida e o “Mundial” perdia um segundo pretendente ao “ceptro”, pois Colin McRae saiu de estrada na classificativa seguinte: “Tudo aconteceu numa curva para a direita, muito rápida, onde McRae perdeu o controlo do Focus WRC e capotou por quatro vezes, antes de se imobilizar. Quer o piloto como o navegador nada sofreram”, explicou um desalentado Malcolm Wilson.", UserFK = 1 },
                new Noticias { IdNoticia = 3, ListaDeEquipas = new List<Equipas>{equipas[1] }, Fotografia = "SCHUMACHERNoticia.jpg", Titulo = "F1: MICHAEL SCHUMACHER TERÁ DOCUMENTÁRIO", Conteudo = "Um documentário oficial sobre Michael Schumacher, totalmente apoiado pela família, será lançado ainda este ano.Intitulado de ‘Schumacher’, o filme é apoiado por uma grande produtora e apresenta entrevistas com o pai de Michael, Rolf, a sua esposa Corinna, os filhos Gina e Mick e outras pessoas essenciais na carreira do alemão. Também conta com imagens de arquivo da carreia de Schumacher.A Rocket Science, sediada em Londres, é a produtora executiva e a responsável pelas vendas internacionais, sendo que pretende começar a comercializar o filme no festival de cinema de Cannes.", UserFK= 1 },
                new Noticias { IdNoticia = 4, ListaDeEquipas = new List<Equipas>{equipas[1] }, Fotografia = "MarkuNoticia.jpg", Titulo = "Markku Alen. O penta campeão do Rali de Portugal em Castelo Rodrigo", Conteudo = "Markku Alen vai estar em Figueira de Castelo Rodrigo para proporcionar um grande espectáculo na prova mítica nacional que este ano assinala duas décadas.", UserFK = 1 },
                new Noticias { IdNoticia = 5, ListaDeEquipas = new List<Equipas>{equipas[4] }, Fotografia = "StigBlomqvistNoticia.jpg", Titulo = "Recorde quando Blomqvist voou a 189 km/h na Argentina", Conteudo = "Começa a 25 de abril mais uma edição do Rali da Argentina, e a organização do Mundial recordou um dos seus momentos mais impressionantes. Falamos de quando Stig Blomqvist e o Audi Quattro terminaram a primeira especial com uma velocidade média (!) de 189,53 km/hHá feitos que ficam na história de competição e a forma como Stig Blomqvist voou sobre a terra batida da Argentina em 1983 é um deles. O site do WRC recordou agora esta história fantástica, que aqui lhe trazemos. O protagonista é Stig Blomqvist que, por correr o Campeonato Britânico em simultâneo, chegou à prova do WRC em cima do arranque, sem oportunidade de fazer o reconhecimento com o Audi Quattro. A solução foi usar as notas do navegador do seu colega de equipa, Hannu Mikkola.Tenha sido das notas, do jet lag ou por qualquer outro motivo, aquilo que Blomqvist fez é notável. Foram 81km cumpridos de forma alucinante, em apenas 25 minutos e 48 segundos. Daqui resultou uma incrível média de 189,53 km/h, ainda mais impressionante se considerarmos que a afinação do seu Audi Quattro colocava a velocidade máxima nos 210 km/h. Ou seja, o ponteiro do velocímetro deve ter estado a maior parte do tempo bem colado ao limite e o das rotações pouco tempo passou fora do redline!Além de recordar este feito, o WRC recordou também que a média de velocidade mais alta para todo um rali data de 2016. O autor foi Kris Meeke, com o seu Citröen C3 WRC a terminar a corrida na Finlândia com um balanço de 126,62 km/h. Mais uma prova que o piloto britânico é bastante rápido. O problema mesmo é manter-se dentro dos limites da estrada…", UserFK= 1 },
                new Noticias { IdNoticia = 6, ListaDeEquipas = new List<Equipas>{equipas[9] }, Fotografia = "tanakNoticia.jpg", Titulo = "WRC/Rali da Sardenha: Sordo herdou triunfo após azar tardio de Tanak", Conteudo = "Diz uma das leis fundamentais do automobilismo que para terminar em primeiro lugar, primeiro é preciso terminar. Esta norma estará hoje na cabeça de Ott Tanak, da Toyota, que perdeu o Rali da Sardenha precisamente na derradeira especial da prova. Pelo lado contrário, sabendo estar onde era preciso, Dani Sordo (Hyundai) herdou o triunfo, apenas o segundo da sua carreira no Mundial de Ralis (WRC).Sábado tinha sido um dia perfeito para o estónio da Toyota Gazoo Racing, tendo vencido todos os troços da etapa e, no domingo, esperava-se que fosse apenas a confirmação de mais um triunfo, dando sequência àquele obtido em Portugal.No entanto, na ‘Power Stage’, para a qual partiu com cerca de meio minuto de vantagem sobre Sordo, um problema com o sistema de direção assistida tornou o modelo nipónico praticamente incontrolável a ritmos elevados, chegando ao final daquela especial com um atraso de dois minutos face ao homem da Hyundai. Com isso, caiu para o quinto posto, o que lhe concedeu os pontos necessários, ainda assim, para saltar para o comando do Mundial de Pilotos, por troca com Sébastien Ogier(Citroën), que teve uma prova verdadeiramente para esquecer.", UserFK= 1 },
                new Noticias { IdNoticia = 7, ListaDeEquipas = new List<Equipas>{equipas[0] }, Fotografia = "PIERREnoticia.jpg", Titulo = "Pierre Gasly", Conteudo = "Pierre Gasly tem até à pausa de verão para melhorar a sua prestação na Red Bull, de acordo com o Dr. Helmut Marko. Desde que saiu de Toro Rosso para substituir Daniel Ricciardo, o francês tem estado uns furos abaixo do seu colega de equipa, Max Verstappen. Na Áustria, por exemplo, Verstappen venceu enquanto Gasly ficou em sétimo lugar, tendo sido dobrado pelo companheiro de equipa:Isso pode ser parcialmente explicado pelo facto de termos uma nova asa dianteira, o que foi um grande passo, mas infelizmente só nos restava uma para a corrida e foi o Max Verstappen que a utilizou. No entanto, Gasly tem de melhorar, especialmente nas ultrapassagens.Ele tem de cumprir até às férias de Verão.", UserFK= 1 },
                new Noticias { IdNoticia = 8, ListaDeEquipas = new List<Equipas>{equipas[13] }, Fotografia = "romain-grosjeannoticia.jpg", Titulo = "GP FRANÇA F1, ROMAIN GROSJEAN: PARAR DE CULPAR OS PNEUS…", Conteudo = "Romain Grosjean acredita que a Haas precisa de parar de culpar os pneus e começar a culpar-se a si mesmo depois do que aconteceu na qualificação para o Grande Prémio de França.Depois de ambos os pilotos da Haas não se terem classificado entre os 10 primeiros em França, Grosjean, que foi eliminado na Q1, disse que a equipa precisa de assumir a responsabilidade:-Penso que temos de parar de culpar os pneus e começar a culpar - nos a nós. Estiveram 50 graus[temperatura da pista] hoje e é muita energia no circuito.Por isso, não temos qualquer desculpa para não aquecer os pneus.Depois da qualificação Grosjean, o seu companheiro de equipa Kevin Magnussen e o patrão da equipa Gunther Steiner admitiram que não sabiam o porquê da falta de desempenho em Paul Ricard.", UserFK= 2 },
                new Noticias { IdNoticia = 9, ListaDeEquipas = new List<Equipas>{equipas[3]}, Fotografia = "block-chamasNoticia.jpg", Titulo = "Ken Block fez um churrasco… com o seu Escort RS Cosworth", Conteudo = "Ainda se recorda da passagem de Ken Block pelo Mundial de Rallies? A aventura foi marcante em diversos locais do globo, como Portugal. E por marcante queremos aqui dizer que o americano deixou marcas (e muitas vezes até partes do carro) em especiais, ao que juntou alguma falta de competitividade. Por estes motivos, não esteve muitos anos com a Ford na categoria de topo dos campeonatos de rali. Agora o piloto, que será para sempre recordado pelos incríveis vídeos de drift e Gymkhanas, mostrou novamente que as coisas nem sempre lhe correm bem, pois teve um acidente que acabou com um incêndio e a total destruição do Ford Escort RS Cosworth.", UserFK= 5 },
                new Noticias { IdNoticia = 10, ListaDeEquipas = new List<Equipas>{equipas[11] }, Fotografia = "slandoNorrisNoticia.jpg", Titulo = "Seidl impressionado com a velocidade de Norris: O mais importante é a velocidade bruta", Conteudo = "Andreas Seidl descreveu a atual dupla de pilotos, Carlos Sainz e Lando Norris, da equipe McLaren, como o futuro deste time, e acredita que Norris mostrou sua velocidade desde a primeira corrida.Lando Norris disputou roda a roda com Lewis Hamilton no início do Grande Prêmio da Áustria, mas terminou em sexto, apenas um lugar atrás de seu compatriota. Enquanto isso, Sainz se recuperou do 19º no grid depois de receber uma penalidade, para terminar em oitavo lugar.Foi a segunda corrida consecutiva que ambos os pilotos se colocaram entre os dez primeiros.Ambos os pilotos estão em sua primeira temporada com a McLaren, sendo esta a primeira temporada de Norris na F1.Após a corrida no Red Bull Ring, Seidl elogiou a dupla e olhou para o futuro.Estou muito feliz com os dois pilotos e eles serão o futuro desta equipe, disse Seidl, citado pela Sky Sports.Seidl também destacou Norris por seu ritmo bruto e destacou sua consistência, acrescentando: O mais importante é a velocidade bruta, que é a base de todo piloto de sucesso.Ele mostrou desde a primeira corrida que tinha essa velocidade, completou.", UserFK= 6 },
                new Noticias { IdNoticia = 11, ListaDeEquipas = new List<Equipas>{equipas[3] }, Fotografia = "evansNoticia.jpg", Titulo = "WRC, RALI ARGENTINA, PE10: GRANDE ACIDENTE DE ELFYN EVANS", Conteudo = "Elfyn Evans/Scott Martin saíram de estrada na PE10, danificando muito o seu Ford Fiesta WRC. O piloto entrou num longo slide, numa zona rápida, e por azar a frente do carro foi bater numa enorme pedra, a única que se encontrava na berma, e logo com um tamanho muito significativo. A dupla ficou chocalhada, mas fisicamente bem. É que o impacto foi mesmo muito forte.", UserFK= 7 },
                new Noticias { IdNoticia = 12, ListaDeEquipas = new List<Equipas>{equipas[10] }, Fotografia = "raikkonen.noticia.jpg", Titulo = "F1: KIMI RAIKKONEN E A DIFICULDADE DE PILOTAR UM FÓRMULA 1", Conteudo = "Kimi Raikkkonen considera que a Fórmula 1 tornou-se mais fácil comparada com anos anteriores. A meio das discussões para as novas regras para a temporada de 2021, alguns pilotos já fizeram conhecer que gostariam que a Fórmula 1 fosse um desafio mais físico.Kimi Raikkkonen também se pronunciou acerca deste assunto, dizendo que não sabia determinar ao certo se antigamente era mais difícil ou não:É mais difícil agora ou menos difícil? É impossível de dizer.Quando começas a pensar como era há 10 anos, a memória prega - te partidas e não te consegues lembrar corretamente.Mas, é como tudo, acabas por te acostumar.Kimi Raikkkonen estreou - se na Fórmula 1 em 2001, aos 21 anos, vindo direto da Fórmula Renault.Conduziu carros com motores V10, V8 e os V6 turbo - hibridos de agora, passou das regras de reabastecimento até a não poder reabastecer:O experiente piloto também sugeriru a redução da direção assistida para dificultar um pouco a condução dos monolugares.", UserFK= 8 },
                new Noticias { IdNoticia = 13, ListaDeEquipas = new List<Equipas>{equipas[6] }, Fotografia = "araujoNoticia2.jpg", Titulo = "RALI DE PORTUGAL: ARMINDO ARAÚJO FALA EM MISSÃO CUMPRIDA NO NACIONAL", Conteudo = "Armindo Araújo (Hyundai i20) considerou hoje ter 'a primeira parte da missão cumprida', depois de ter assegurado a vitória no Rali de Portugal entre os pilotos do Nacional, cuja classificação ficou fechada após o último troço desta manhã.'Vencer nunca é fácil, mas correu-nos bastante bem. Entrámos bem no rali, com um bom ritmo. O carro foi um forte aliado e hoje também estivemos a ver os nossos adversários à distância. Foi uma boa operação para o Campeonato de Portugal de ralis, até porque fizemos a dobradinha, disse o piloto à agência Lusa.Armindo Araújo destacava o facto de o companheiro de equipa, Bruno Magalhães, ter arrebatado o segundo lugar na prova ao líder do campeonato, Ricardo Teodósio(Skoda Fabia), na derradeira especial.", UserFK= 9 },

            };

            noticias.ForEach(nn => context.Noticias.AddOrUpdate(n => n.Titulo, nn));
            context.SaveChanges();


            var comentarios = new List<Comentarios> {
                new Comentarios { IdComentario = 1, Conteudo = "Araújo a maior maquina de sempre", NoticiaFK = 1, UserFK = 1 },
                new Comentarios { IdComentario = 2, Conteudo = "RICHARD BURNS????quem não lembra?", NoticiaFK = 2, UserFK = 1 },
                new Comentarios { IdComentario = 3, Conteudo = "Documentário?quando vai sair?", NoticiaFK = 3, UserFK = 2 },
                new Comentarios { IdComentario = 4, Conteudo = "Markku Alen?campeão?mas ele sabe conduzir????", NoticiaFK = 4, UserFK = 2 },
                new Comentarios { IdComentario = 5, Conteudo = "189km? n é possivel....", NoticiaFK = 5, UserFK = 3 },
                new Comentarios { IdComentario = 6, Conteudo = "Sordo herdou triunfo após azar tardio de Tanak......ahahahaha que piada...meu deus", NoticiaFK = 6, UserFK = 4 },
                new Comentarios { IdComentario = 7, Conteudo = "Devia descansar de vez disto...", NoticiaFK = 7, UserFK = 5 },
                new Comentarios { IdComentario = 8, Conteudo = "PNEUS...................", NoticiaFK = 8, UserFK = 6 },
                new Comentarios { IdComentario = 9, Conteudo = "Ken Block fez um churrasco…? ahahahahhah", NoticiaFK = 9, UserFK = 7 },
                new Comentarios { IdComentario = 10, Conteudo = "velocidade bruta?ahahahha", NoticiaFK = 10, UserFK = 8 },
                new Comentarios { IdComentario = 11, Conteudo = "uiiiiiiiiiii", NoticiaFK = 11, UserFK = 9 },
                new Comentarios { IdComentario = 12, Conteudo = "f1 não é para todos não", NoticiaFK = 12, UserFK = 10 },
                new Comentarios { IdComentario = 13, Conteudo = "ARMINDO ARAÚJO a maquina de portugal", NoticiaFK = 13, UserFK = 10 },

            };

            comentarios.ForEach(cc => context.Comentarios.AddOrUpdate(c => c.Utilizador, cc));
            context.SaveChanges();


        }
    }
}
    
