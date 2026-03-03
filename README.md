# DebuggingXR-Lab

## Etape 1

J'initialise le repo sur github puis le clone sur mon PC
Je crée le projet unity dans le dossier cloné
J'essaye de commit, j'échoue, mais je ne comprends pas le problème immédiatement. Je laisse de côté
J'installe OpenXR Plugin, XR Toolkit. InputSystem est déjà présent
Je modifie le debug avec ce qui est recommandé, et je change de plateforme vers android
Je comprends que le problème viens du git ignore mal placé (source du repo, et non source du projet unity)
Je corrige, puis je commit avec les tags requis

Je build sur unity mais je ne peux pas grab le cube, ni me mettre immédiatement sur le casque car les builds sont assez longs 
donc je le ferais après

## Etape 2

Pour la structuration des dossiers, je place le dossier Scripts dans le root du projet unity (et pas dans les assets)
Pour découvrir des commandes plus rapides j'uilise :
"Bootstrap","Models","Services","Controllers","Views" | ForEach-Object { mkdir "scripts\$_" }

Je crée le timemodel.cs
Je crée solarsystemconfig.cs, je me suis rendu compte qu'il manquait le dossier config donc je le rajoute
Puisque le script n'apparaît pas dans les assets je comprends qu'il faut que je place le dossier scripts dans assets.
Je crée l'asset (via le menu assets, et pas via un gameobject)
Je récupère le contenu de PlanetData.cs
Je crée le fichier PlanetData dans Models, puisque ce sont des données que je ne suis pas sensé modifié durant le TP
J'ajoute le service d'accès au planète
J'ajoute la vue planète
J'ajoute le controller du système solaire
J'ajoute le bootstrapper
Au moment d'ajouter les gameobject je me rends compte qu'il y a une erreur :
Assets\Scripts\Bootstrap\AppBootstrapper.cs(19,29): error CS0246: The type or namespace name 'PlanetEphemerisService' could not be found (are you missing a using directive or an assembly reference?)
C'est probablmeent du à l'absence de la classe qui implémente l'interface IEphemerisService, laquelle classe est pourtant appelée dans le bootstrap.
Je crée donc une classe EphemerisService.
Je me rends compte que c'était dans le TP et que j'ai sauté cette partie par erreur, je corrige ce manquement.
J'ajoute le component app, puis le solarsystemconfig, mais je me retrouve bloqué à l'assignation des planetview
Pour règler ce problème j'ajoute manuellement des gamecomponents vide, je les renomme en planète et je leur ajoute le script planet view. Je les assigne ensuite au BootStrap. Cependant je remarque qu'il manque la position du soleil pour avoir la configuration coseillée ou recommandée par le TP.
Comme cette méthode est chronophage je crée un prefab de planète que j'importerai ultérieurement.
Les logs sont bons pour le boot, par contre je n'observ pas vraiment un log par planète. Je ne vois pas non plus les planètes.
Je ne suis pas certain d'avoir saisi le bug, les planètes n'apparaissent pas vraiment, et je ne sais pas si les planètes doivent avoir un log particulier, donc j'enregistre l'étape 2 sous le tag. Les propriétés exigées sur la structure du code sont normalement respectées.
Après pas mal de temps à  ne pas comprendre le fait de ne rien voir, j'ai changé le service lié au planète afin d'appliquer la correction de la configuration liée à la distance entre les planètes.
Finalement ce n'était pas du tout ça, donc je retire tout ce qui est raltif à ça, c'était une hallucination de l'IA.

Comme je n'ai pas réglé mon problème d'affichage des planètes, j'ai corrigé des trucs pour configurer plus rapidement le système.
J'ai créé des materials pour les couleurs des planètes, histoire de les distinguer, puis des prefabs pour chaque planète. J'ai remarqué que je n'avais toujours aucun affichage peu importe ce que je faisais, puis j'ai réalisé que je n'avais pas mis les planètes en enfant de l'app. Une fois cela fait, j'ai modifié le plane pour qu'il soit transparent et j'ai pu voir les planètes, légèrement en mouvement, puisque j'avais déjà configuré le time controller.

J'ai resauvegardé sous la forme du tag 1.1.1-architecturecorr

## Etape 3

Je crée le composant TimeController dans Controller.
Les logs créés semblent corrects, les planètes se déplacent et les vitesses sont ajustées.
Je remarque néanmoins une légère translation du système par rapport au soleil. Je corrige ça.
Je remarque aussi que Mercure reste immobile. Je ne sais pas trop d'où ça vient, je creseurais plus tard.

Pour la partie rendu des orbites je ne parviens pas tellement à faire fonctionner le line renderer.
Je crée un script orbit renderer qui est placé dans les vues puisque cela correspond à des objets visibles.
Je modifie aussi le bootstrap afin d'initialiser les orbites au lancement de l'application.
J'observe que le line renderer ne suit pas forcément l'orbite (pas de changement de direction).
En déchochant world space il suit la planète mais n'est pas forcément orienté correctement.
Donc je saute cette partie et j'y reviendrai plus tard.

## Etape 4

J'ajoute la structure de solarsystemroot.
Je teste si c'est possible de le mettre hors du parent app, mais ça ne fonctionne pas, donc je crée le flux sous l'app poiur que cela continue à fonctionner.
Je place le handle, sous la forme d'une tige rectangulaire transparente.
Pour tester je lance un build sur casque VR.

Pour le scale controller, je commence par créer un script dans le dossier controllers.
Sur ce scale controller on s'inspire de ce qui a été fait sur les TP de navigation. On va modifier le scale du solarsystemroot. 
Après avoir ajouté le script, je modifie le bootstrapper afin qu'il prenne en compte le contrôleur.
Pour pouvoir interagir, je veux mettre des boutons. Donc je me penche un peu sur la partie implémentation UI avant.
J'ai implémenter via un canva UI les différents boutons, j'ai modifié la partie BootStrapper pour qu'elle prenne en compte l'ui créée.
Un script de UIController permet de mettre à jour l'UI, et inversement que l'UI mettte à jour le solarsystemroot.
Cependant je suis bloqué car je ne parviens par à interagir (que ce soit en simulation ou dans le casque vr) avec mon application.
Celle-ci s'ouvre, mais je ne peux pas la lancer en plein écran (tandis qu'avec d'autres applications c'est le cas).

Pour la sélection d'une planète, je commence par implément une view supplémentaire (SelectablePlanet.cs). Ensuite pour contrôler le fait de sélectionner et de zoomer il faut créer un FocusController. Puis signifier au BootStrapper que l'on utilise maintenant les modes de sélection.

J'enregistre une version intermédiaire des modes de grab.

## Etape 5 

Une partie de l'interface est déjà en place.
Je crée un script debugoverlay dans le dossier view.
