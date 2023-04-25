Eu me inspirei no jogo BloonsTD6, onde hordas de balões vem e você precisa estourar eles com diversas torres.

O jogo inicia parado, com você podendo comprar a torre que desejar pôr na partida. Para as hordas começarem a vir você precisa apertar o botão "Play".

Começa com 4 inimigos mais fracos, 3 médios e 2 fortes e assim se repete infinitamente. O jogador ao abater uma unidade recebe "coins" e pontuação. 

As "coins" são feitas para comprar novas unidades, a pontuação é o seu desempenho durante a partida e será mostrado a sua pontuação mais alta no final da partida.

Eu tentei balancear as torres, sendo que você só pode colocar 5 torres no jogo inteiro e não é possivel remover torres já colocadas.

Os inimigos não tem um pathfinder definido, eles apenas iniciam de um ponto A e vão até o ponto B, que é a linha branca chamada "goal".

Eu não usei o sistema de canvas do Unity, pois eu acho ruim de trabalhar com o sistema de UI do Unity. Eu usei mais sistemas de actions do C# e OnMouseDown.

No jogo temos 3 tipos de torres:
- A torreta: Dispara projéteis, é a única torre que causa dano no jogo.
- A torre de lentidão: Desacelera a movimentação dos inimigos quando dispará sua "wave" de tempos em tempos, os inimigos que passarem por ela serão desacelerados.
- A torre dos castelo: Ela da um "buff" à torre próximas, aumentando a cadência de tiro.

Os inimigos são 3:
- O inimigo capsula: É o inimigo mais fraco, causa 10 de dano e tem 22 de vida. Também é o que menos da "coins" e pontuação.
- O inimigo Fantasma: É o inimigo de nível médio do jogo, causa 20 de dano e tem 45 de vida.
- O inimigo Diamante: É o inimigo mais forte, causa 30 de dano no jogador e tem 60 de vida.

O jogador terá que trabalhar para que os inimigos não cheguem a linha branca e assim perca vida, podendo usar apenas torres de torreta ou alternar entre elas.

Como eu disse, para começar o jogo o jogador precisa clickar no "Play". Tem também o botão de pause, onde o jogador poderá pausar o jogo, se clickar novamente no mesmo o jogo
volta da onde parou.

Quando o jogador está sem vidas, o game over aparece e o jogador poderá apertar o botão de "restart" para recomeçar a cena.

Para fazer o sistema de loja usei a classe Task do C# para fazer uma função assíncrona e respawnar o objeto assim que o jogador puxar a torre da loja.

Eu pensei em fazer uma versão bem demonstrativa, um MVP, para ir aprimorando ao longo do tempo. Tentei seguir o principio SOLID durante o desenvolvimento e as melhores práticas
do OOP.
