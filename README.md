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