namespace noticiasAuto.Migrations
{
    using noticiasAuto.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<noticiasAuto.Models.NoticiasDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(noticiasAuto.Models.NoticiasDB context)
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
                new Pilotos { IdPiloto = 7, Nome = "Lewis Hamilton", DataNascimento = new DateTime(1985, 01, 07), Categoria = "F1", Nacionalidade = "Inglesa", Fotografia = "Hamilton.jpg", EquipaFK = 8 },
                new Pilotos { IdPiloto = 7, Nome = "Valtteri Bottas", DataNascimento = new DateTime(1989, 08, 28), Categoria = "F1", Nacionalidade = "Finlandesa", Fotografia = "ValtteriBottas.jpg", EquipaFK = 8 },
                new Pilotos { IdPiloto = 7, Nome = "Sebastian Vettel", DataNascimento = new DateTime(1987, 07, 03), Categoria = "F1", Nacionalidade = "Alemã", Fotografia = "SebastianVettel.jpg", EquipaFK = 4 },
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
                new utilizadores { IdUser = 12, Nome = "Pedro Silva", Email = "PSSSS@sp.pt" },

            };

            utilizadores.ForEach(uu => context.Utilizadores.AddOrUpdate(u => u.Nome, uu));
            context.SaveChanges();



            var noticias = new List<Noticias> {
                new Noticias { IdNoticia = 1, Fotografia = "araujoNotica.jpg", Titulo = "CPR, RALI DE MORTÁGUA, ARMINDO ARAÚJO: “BOM RESULTADO, MAS TEMOS DE TRABALHAR", Conteudo = "Em entrevista ao Autosport, Armindo Araújo felicitou os vencedores do rali de Mortágua, também mostrando-se satisfeito com os pontos amealhados do segundo lugar. Araújo também fala na extrema competitividade do Campeonato de Portugal de Ralis. Oiça aqui.", UserFK= 1 },
                new Noticias { IdNoticia = 2, Fotografia = "burnsNoticia.jpg", Titulo = "LEMBRA-SE DE: RICHARD BURNS, O PRIMEIRO INGLÊS A VENCER O MUNDIAL DE RALIS” ", Conteudo = "Foi no dia de hoje, há precisamente 17 anos, em 2001, que Richard Burns e Robert Reid asseguraram a conquista do seu título Mundial de Ralis. O terceiro lugar no Rali da Grã-Bretanha foi o suficiente, depois de Colin McRae ter abandonado a prova. Foi o primeiro, e único até hoje, piloto inglês, que não britânico (esse foi o escocês Colin McRae em 1995) a ser Campeão do Mundo de Ralis.Nesse dia, habitualmente bastante reservado em público, Richard Burns colocou de parte a sua tradicional ‘fleuma’ e deu largas ao seu contentamento no final do Rali da Grã-Bretanha. É que, ao cabo e ao resto, o piloto da Subaru tinha acabado de se sagrar Campeão do Mundo de Ralis, isto depois de ter sido vice-campeão em 1999 e 2000.r isso, as primeiras palavras que proferiu na altura refletiam bem o estado de espírito do inglês: “Sinto-me fantástico! Havia uma pressão enorme antes do rali ir para a estrada, pressão vinda de todas as partes, e chegar ao fim da prova com este resultado é absolutamente incrível. Sinto pena em não garantir o título com uma vitória no ‘meu’ rali mas, após as desistências dos meus adversários, a estratégia teve que ser alterada para não corrermos riscos desnecessários. Mais que chegar à vitória, tinha a possibilidade de ser Campeão do Mundo! A conquista do título representa o trabalho e empenho de toda a equipa, que está de parabéns.”Makinen e McRae desistiram cedo: Adeus título… e recordeAo contrário do que tinha acontecido nos cinco anos anteriores, o título mundial não foi para a Finlândia! À partida para este Rali da Grã-Bretanha de 2001, Tommi Makinen e Colin McRae – tal como Carlos Sainz – tinham dois objectivos, mesmo se um deles não passava de secundário: sagrar-se Campeão do Mundo e, de permeio, estabelecer o novo recorde de vitórias em provas do “Mundial” de Ralis. E melhor cenário não poderia existir, pois o Rali da Grã-Bretanha era o palco onde quatro pilotos tinham pretensões ao título, dos quais três poderiam ascender à tão procurada 24ª vitória.Sabia-se que Richard Burns e McRae eram apontados como favoritos para vencer em “casa”, mas foi do lado de Makinen que veio a primeira “surpresa”: abandonou na segunda classificativa, após ter batido numa pedra, que danificou a suspensão do Lancer Evolution WRC e arrancou uma roda ao carro japonês. Mas ainda a notícia do abandono do finlandês estava a ser digerida e o “Mundial” perdia um segundo pretendente ao “ceptro”, pois Colin McRae saiu de estrada na classificativa seguinte: “Tudo aconteceu numa curva para a direita, muito rápida, onde McRae perdeu o controlo do Focus WRC e capotou por quatro vezes, antes de se imobilizar. Quer o piloto como o navegador nada sofreram”, explicou um desalentado Malcolm Wilson.", UserFK = 1 },
                new Noticias { IdNoticia = 3, Fotografia = "SCHUMACHERNoticia.jpg", Titulo = "F1: MICHAEL SCHUMACHER TERÁ DOCUMENTÁRIO", Conteudo = "Um documentário oficial sobre Michael Schumacher, totalmente apoiado pela família, será lançado ainda este ano.Intitulado de ‘Schumacher’, o filme é apoiado por uma grande produtora e apresenta entrevistas com o pai de Michael, Rolf, a sua esposa Corinna, os filhos Gina e Mick e outras pessoas essenciais na carreira do alemão. Também conta com imagens de arquivo da carreia de Schumacher.A Rocket Science, sediada em Londres, é a produtora executiva e a responsável pelas vendas internacionais, sendo que pretende começar a comercializar o filme no festival de cinema de Cannes.", UserFK= 1 },
                new Noticias { IdNoticia = 4, Fotografia = "MarkuNoticia.jpg", Titulo = "Markku Alen. O penta campeão do Rali de Portugal em Castelo Rodrigo", Conteudo = "Markku Alen vai estar em Figueira de Castelo Rodrigo para proporcionar um grande espectáculo na prova mítica nacional que este ano assinala duas décadas.", UserFK = 1 },
                new Noticias { IdNoticia = 5, Fotografia = "StigBlomqvistNoticia.jpg", Titulo = "Recorde quando Blomqvist voou a 189 km/h na Argentina", Conteudo = "Começa a 25 de abril mais uma edição do Rali da Argentina, e a organização do Mundial recordou um dos seus momentos mais impressionantes. Falamos de quando Stig Blomqvist e o Audi Quattro terminaram a primeira especial com uma velocidade média (!) de 189,53 km/hHá feitos que ficam na história de competição e a forma como Stig Blomqvist voou sobre a terra batida da Argentina em 1983 é um deles. O site do WRC recordou agora esta história fantástica, que aqui lhe trazemos. O protagonista é Stig Blomqvist que, por correr o Campeonato Britânico em simultâneo, chegou à prova do WRC em cima do arranque, sem oportunidade de fazer o reconhecimento com o Audi Quattro. A solução foi usar as notas do navegador do seu colega de equipa, Hannu Mikkola.Tenha sido das notas, do jet lag ou por qualquer outro motivo, aquilo que Blomqvist fez é notável. Foram 81km cumpridos de forma alucinante, em apenas 25 minutos e 48 segundos. Daqui resultou uma incrível média de 189,53 km/h, ainda mais impressionante se considerarmos que a afinação do seu Audi Quattro colocava a velocidade máxima nos 210 km/h. Ou seja, o ponteiro do velocímetro deve ter estado a maior parte do tempo bem colado ao limite e o das rotações pouco tempo passou fora do redline!Além de recordar este feito, o WRC recordou também que a média de velocidade mais alta para todo um rali data de 2016. O autor foi Kris Meeke, com o seu Citröen C3 WRC a terminar a corrida na Finlândia com um balanço de 126,62 km/h. Mais uma prova que o piloto britânico é bastante rápido. O problema mesmo é manter-se dentro dos limites da estrada…", UserFK= 1 },
                new Noticias { IdNoticia = 5, Fotografia = "SebastanNoticia.jpg", Titulo = "Tanak vence no Chile com Ogier em segundo e Loeb em terceiro", Conteudo = "Ott Tanak conquistou a vitória no Rally do Chile, enquanto Sebastien Ogier ficou em segundo lugar, fora do alcance de Sebastien Loeb.Tanak gostou do novo evento, ao contrário de muitos dos competidores que tiveram dificuldade com aderência, para enfrentar os estágios desconhecidos, conquistando sua segunda vitória em 2019.Tanak está em segundo lugar no campeonato, 10 pontos atrás do líder Ogier.Havia 5,1 segundos entre Ogier e Loeb para o domingo, que o piloto da Hyundai conseguiu reduzir para 1,1 segundo no primeiro estágio da corrida.No entanto, a diferença aumentou à medida que a manhã avançava e o segundo melhor tempo de Ogier, apesar do incomum incidente de seu extintor de incêndio, que explodiu no carro, permitiu que ele mantivesse a diferença por mais de sete segundos.O Chile marca o primeiro pódio de Loeb para a equipe Hyundai.A dupla da M-Sport de Elfyn Evans e Teemu Suninen terminou o rally em quarto e quinto, um sucesso para a equipe, considerando as lutas que os pilotos enfrentaram.Esapekka Lappi terminou em sexto, com seu C3 tendo dificuldade de baixa aderência de manhã.Andreas Mikkelsen estava com um certo otimismo excessivo, mas terminou o final de semana em sétimo.Kris Meeke subiu de volta para a oitava posição após colidir com um toco de árvore no sábado, ao passar pelo vencedor da WRC2 Pro, Kalle Rovanpera.Mads Ostberg completou o top 10, quase 3 minutos à frente de Jari-Matti Latvala, que reiniciou o rally no domingo, depois de uma falha no eixo de tração na noite de sábado.Latvala estava em terceiro lugar antes do incidente, mas teve o consolo de conquistar três pontos no campeonato.", UserFK= 1 }

            };

            noticias.ForEach(nn => context.Noticias.AddOrUpdate(n => n.Titulo, nn));
            context.SaveChanges();

               
            var comentarios = new List<Comentarios> {
                new Comentarios { IdComentario = 1, Conteudo = "Teste-------Teste------teste-----", NoticiaFK = 2, UserFK = 1 },
                new Comentarios { IdComentario = 1, Conteudo = "Teste-------Teste------teste-----", NoticiaFK = 2, UserFK = 1 },
                new Comentarios { IdComentario = 2, Conteudo = "Teste-------Teste------teste-----", NoticiaFK = 2, UserFK = 1 },
                new Comentarios { IdComentario = 3, Conteudo = "Teste-------Teste------teste-----", NoticiaFK = 2, UserFK = 2 },
                new Comentarios { IdComentario = 4, Conteudo = "Teste-------Teste------teste-----", NoticiaFK = 2, UserFK = 1 },
                new Comentarios { IdComentario = 5, Conteudo = "Teste-------Teste------teste-----", NoticiaFK = 2, UserFK = 6 },
                new Comentarios { IdComentario = 6, Conteudo = "Teste-------Teste------teste-----", NoticiaFK = 3, UserFK = 1 },
                new Comentarios { IdComentario = 7, Conteudo = "Teste-------Teste------teste-----", NoticiaFK = 5, UserFK = 1 },
                new Comentarios { IdComentario = 8, Conteudo = "Teste-------Teste------teste-----", NoticiaFK = 3, UserFK = 8 },
                new Comentarios { IdComentario = 9, Conteudo = "Teste-------Teste------teste-----", NoticiaFK = 2, UserFK = 1 },
                new Comentarios { IdComentario = 10, Conteudo = "Teste-------Teste------teste-----", NoticiaFK = 2, UserFK = 1 },
                new Comentarios { IdComentario = 11, Conteudo = "Teste-------Teste------teste-----", NoticiaFK = 2, UserFK = 9 },
               
            };

            comentarios.ForEach(cc => context.Comentarios.AddOrUpdate(c => c.Utilizador, cc));
            context.SaveChanges();


        }
    }
}
