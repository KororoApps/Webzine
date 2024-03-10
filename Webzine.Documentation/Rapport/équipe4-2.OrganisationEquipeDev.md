# **2. ORGANISATION DE L'EQUIPE DE DEVELOPPEURS** ##

## 2.1. Reflexion commune pour commencer la création de l'application

Afin de débuter sur la même base et d'être tous en accord, nous avons travailler ensemble sur la création du model de données :

![Logo](images/Modelisation_donnees.png)

Une fois établie, il nous a permis d'identifier les entités à créer pour notre application ainsi que les données nécessaires à chacune pour que l'application finale fonctionne correctement avec tous les éléments nécessaires.

| FONCTIONNALITES																| TEMPS PASSE |
|-------------------------------------------------------------------------------|:-----------:|
| Mise en place du projet Azure avec Epic, Feature, UserStory et Task			|     1h30    |
|Création du projet sur Visual Studio avec installation des nuggets nécessaires |     1h00    |
| Répartition de la création des fausses données								|     0h15    |

## 2.1. Répartition des tâches

### 2.2.1. Répartition au sein de l'équipe 

![Logo](images/Camembert.png)

Vous pouvez retrouver nos [Comptes Rendus d'Activité](https://groupesbtest.sharepoint.com/:x:/s/DIIAGE2026DI1P4/EY5e9Z9cSJlNhY6EC677OKkBNBYJHpZv8_6OMtE7qLdtiQ?e=SJ8cjc&wdOrigin=TEAMS-MAGLEV.teams_ns.rwc&wdExp=TEAMS-TREATMENT&wdhostclicktime=1708886671961&web=1) pour un détail précis du travail effectué

### 2.2.2. Lucas FERNANDEZ
| TÂCHES												| TEMPS PASSE |
|-------------------------------------------------------|:-----------:|
| Mise en place du backlog AzureDevops					|    0h15     |
| Mise en place des User Stories sur AzureDevops		|    1h00     |
| Création des fausses données pour l'entité Artiste	|    4h00     |
| Création de l'entité Artiste							|    1h00     |
| Création de la page Artiste							|    2h00     |
| Création de la page Dashboard							|    1h30     |
| Création du Dashboard	Azure DevOps					|    1h30     |
| Correction et assignation des tâches Azure DevOps		|    1h00     |
| Rédaction de la documentation							|    3h00     |

### 2.2.3. Dylann-Nick ETOU

| TÂCHES												| TEMPS PASSE |
|-------------------------------------------------------|:-----------:|
| Création du layout									|             |
| Création de la navbar									|             |
| Création de la liste des styles à droite des pages    |             |
| Création du footer									|             |

### 2.2.4. Antoine COUVERT

| TÂCHES																										| TEMPS PASSE |
|---------------------------------------------------------------------------------------------------------------|:-----------:|
| Création de la page Contact et de ses données																	|     3h15    |
| Test de l'application et listing des bugs et des points ne correspondant pas exactement à la demande client   |     2h30    |
| Création des fausses données pour l'entité Style																|     4h00    | 
|  Création de l'entité Style																					|     1h00    |

### 2.2.5. Elodie SPONTON

| TÂCHES JALON 1																						| TEMPS PASSE |
|-----------------------------------------------------------------------------------------------|:-----------:|
| Création des fausses données pour l'entité Titre												|    4h00     |
| Création des fausses données pour l'entité Commentaire										|    1h00     |
| Création des fausses données pour l'entité Style												|    1h00     |
| Création des fausses données pour l'entité Artiste											|    4h00     |
| Création de l'entité Titre																	|    1h00     |
| Création de la page Titre																		|    6h00     |
| Création de la page Recherche																	|    0h30     | 
| Création de la page API Version																|    0h10     |
| Création des pages administration (CRUD) des commentaires										|             2h00 |
| Création des pages administration (CRUD)  des titres											|    8h00     |
| Création des pages administration (CRUD)  des styles											|    3h00     | 
| Création des pages administration (CRUD)  des commentaires									|    2h30     |
| Création des pages administration (CRUD)  des artistes										|    3h00     |
| Mise en place des fausses données pour l'ensemble de l'application dans un fichier commun     |    11h00    |
| Création d'un View Component et d'une View Partial pour la colonne à droite de l'application  |    3h30     | 
| Mise au propre du code																		|    7h00     |

</br>

| TÂCHES JALON 2																						| TEMPS PASSE |
|-----------------------------------------------------------------------------------------------|:-----------:|
| Corrections Jalon 1												|    7h00     |
| Création de la BDD avec SQLite et la seeder avec les fausses données										|    4h00     |
| Mise en place des Repositories pour les Titres									|    3h00     |
| Ajout de certaines fonctionnalités qui n'étaient pas présentes dans l'application ou qui fonctionnaient mal										|    12h00     |
| Entité Style : Mise en place de la validation du formulaire de création d'un style										|    1h15     |
| Entité Artiste : Mise en place de la validation du formulaire de création d'un artiste 										|    0h15     |
| Entité Commentaire : Mise en place de la validation du formulaire de création d'un commentaire 									|    1h30     |
| Entité Titre : Mise en place de la validation du formulaire de création d'un titre 			|    1h00     |
| Entité Style : Mise en place de la validation du formulaire de l'édition d'un style 			|    00h45     |
| Correction de la création de la BDD		|    1h00     |

</br>

| TÂCHES JALON 3																						| TEMPS PASSE |
|-----------------------------------------------------------------------------------------------|:-----------:|
| Seeder la BDD avec les données de Spotify												|    19h00     |
| Pagination des pages Accueil, Liste des titres, Listes des commentaires et Liste des artistes										|    4h30     |

## 2.2. Fonctionnement de l'équipe

Nous avons commencé en nous répartissant les tâches équitablement dans l'équipe puis avons décidé, pour faire avancer le projet au maximum, que dès que l'un de nous terminait sa tâche il travaillait sur une nouvelle en informant les autres membres de l'équipe au préalable.

## 2.3. Intéraction entres les membres

## 2.3.1. Utilisation de AzureDevOps

L'organisation des tâches et des fichiers a été réalisée à travers AzureDevOps, nous permettant une gestion efficace du projet.

Nous avons construit ensemble le squelette de l'application, en mettant en commun nos points de vue et méthodes. 

Une fois cela accompli, nous nous sommes répartis les Users Stories, en débutant par les plus cruciales pour assurer une progression rapide.

## 2.3.2. Code review

Après l'achèvement de chaque tâche individuelle, nous avons organisé des sessions de pull requests. Celles-ci ont permises de résoudre les conflits éventuels en équipe. 

Une fois tous les codes fusionnés sur la branche principale, nous avons réitéré le processus en nous répartissant de nouvelles tâches pour maintenir un flux de travail continu.

## 2.3.3. Comptes rendus d'activité et Daily meeting

Tout comme pour la collaboration dev/ops, la mise à jour régulière de nos CRA et les daily meeting tous les matins nous ont permis de connaître régulièrement l'avancée individuel de chacun et par conséquent de l'application en général.

## 2.3.4. Discussions Teams

En dehors des périodes d'école, il nous est difficile de nous rendre disponible aux mêmes moments.

Nous avons utilisé les conversations Teams de notre Equipe pour se faire part de notre avancée et demander des calls si nécessaire.
