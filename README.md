# Defective-Detective_DJD

## Authors:

**Ana Dos Santos** - a21900297 [AnSantos99](https://github.com/AnSantos99)

**Diana Levay** - a21801515 [nanilevay](https://github.com/nanilevay)

**Joana Silva** -21805651 [LegendaryBananaCat](https://github.com/LegendaryBananaCat)

### Tarefas de cada membro

**Ana Dos Santos**
som, sistema de diálogo inicial, notificações, ajuda no código, relatório, UML, doxygen, comentários no código, monólogo inicial

**Joana Silva**
Dialogo e sistema de triggers do monólogo finais, modificações no sistema de som, ajuda com organização do código, NPC, movimento do jogador e câmara

**Diana Levay**
Inventário, junção com rotate dos objetos com manipulação de inventário, organização dos puzzles e colocação destes na scene, comentação das classes e organização do código

### Descrição da Solução
O jogo é um 3D puzzle adventure onde o jogador tem que interagir com objetos ligados ao seu inventário e também com personagens que mostram falas simples. 

Maior parte do projeto é feito através de ativar e desativar objetos existentes na scene, sendo que foram utilizadas diferentes classes para o efeito, embora se tenha tentado seguir uma estrutura, usando Eventos, design patterns e Co-rotinas, sendo que por restrições temporais maioria foi diretamente inspirado, existem vários momentos onde se utilizam triggers e booleans. Foi feito um controlador de movimento do jogador, um inventário, que está associado a este e também um script isolado que define os comportamentos do inventário, foram implementadas e adaptadas interfaces de tutoriais de terceiros que serão referenciados mais adiante. 

Há momentos onde se lê e interpreta o input do jogador, onde se mostram menus e se interage com botões usando o MonoBehaviour do unity. São usadas também tags por facilidade e tempo, o input do jogador é medido em diferentes momentos através de getKeyDowns e também do rato, existe também um sistema em panel que mostra as várias notificações assim como um sound manager, e um sistema de "monólogos" do jogador controlados por triggers em determinadas instâncias. 

Existe também um menu principal que permite fazer load de scenes e navegar entre os panels do jogo. Haverá tambem um sistema de som, ja presente na solução mas que ainda não funciona na totalidade, que estará pronto na entrega de Design de Som.

### UML Diagram

O seguinte diagrama descreve a estrutura de classes do projeto e as conexões entre cada classe.

## References

**For Programs**
API do Unity, https://www.youtube.com/watch?v=90OiysC4j5Y&list=PLboXykqtm8dynMisqs4_oKvAIZedixvtf&index=11, https://www.youtube.com/watch?v=TjwI3kqWQWw, https://answers.unity.com/questions/294448/how-to-make-player-have-the-ability-to-pickup-and.html, https://ekx.itch.io/monologue-for-unity3d, https://www.udemy.com/course/3dmotive-learn-to-build-a-3d-puzzle-game-with-unity/

**For Diagrams**
<https://www.draw.io/>

Na classe do monológo, o aluno Pedro Inácio (a21802050) ajudou com as co-rotinas e facilitou a mudança entre os diálogos das galinhas.
