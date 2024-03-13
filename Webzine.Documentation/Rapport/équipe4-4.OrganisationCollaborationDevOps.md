# **4. ORGANISATION DE LA COLLABORATION DEVELOPPEURS/ADMINISTRATION RESEAUX** ##

## 4.1. Comptes rendus d'activité

Chaque jour, à la fin de la journée de travail, nous avons pris le temps de mettre à jour nos comptes rendus d'activité. Cette pratique régulière nous a permis de suivre efficacement l'avancement individuel et collectif du projet.

## 4.2. Daily meetings

Chaque matin, nous avons organisé des réunions rapides, ne dépassant pas une dizaine de minutes. 

Durant ces sessions, tous les membres du groupe ont eu l'opportunité de partager leurs accomplissements de la veille, leurs objectifs pour la journée en cours, ainsi que les difficultés rencontrées. 

Cette communication quotidienne a renforcé la cohésion d'équipe et a été cruciale pour anticiper et résoudre rapidement les éventuels obstacles.

## 4.3 Travail en commun

Lors de certaines tâches les parties Dev et Ops se sont réunies afin de s'entraider dans la production ou la mise en place de certains outils. Par exemple lors de la mise en place des pipelines de déploiement automatiques.

## 4.3.1 Pipelines

Dans le cadre de cette mise en place nous avons dans un premier temps fait un point sur ce qu'étaient réellement les pipelines et les étapes par lesquelles le déploiement automatique devait passer.
L'équipe Dev a ensuite listé les commandes et étapes à executer afin de déployer l'application pour que l'équipe Ops puisse construire la pipeline.

Voici la liste des commandes nécessaires à la création de l'artefact:

<p align="center">
  <img src="images/Commandes_pipeline.png" alt="Schema" width="85%">
</p>

- <b><u>trigger:</u></b> Branche qui déclanchera l'activation de la pipeline lors d'un changement.
- <b><u>pool:</u></b> Agent à appeler pour executer la pipeline.
- <b><u>steps:</u></b> Liste des différentes étapes à effectuer lors du lancement de la pipeline.

## 4.4 Tableau de bord Azure DevOps

Afin d'améliorer la visibilité et le suivi du travail en continu, nous avons créé un tableau de bord dédié sur Azure DevOps.
Ce tableau de bord centralise les informations relatives aux tâches associées à chaque membre du groupe, offrant ainsi une vue d'ensemble instantanée de l'avancement du projet.

![Dashboard](images/Dashboard_Azure_DevOps.png)

## 4.4.1 Widgets et indicateurs

Le tableau de bord est composé de divers widgets et indicateurs personnalisés, permettant un suivi détaillé des éléments clés du projet.

Certains widgets incluent :

- <b>Avancement du sprint actuel:</b> Affiche l'avancement actuel et le temps restant avant la fin du sprint en cours.

- <b>Vue d'ensemble des tâches:</b> Affiche le nombre total de tâches assignées, en cours et terminées.

- <b>Création rapide:</b> Permet de créer rapidement des "Work Items" directement depuis le dashboard.

- <b>Avancement face aux bugs:</b> Affiche le nombre de bugs actifs.

## 4.4.2 Utilisation dans les réunions quotidiennes

Lors de nos réunions quotidiennes, le tableau de bord Azure DevOps est consulté en temps réel pour discuter des progrès, des obstacles éventuels, et pour définir les priorités du jour.
Cette pratique renforce la transparence et assure une meilleure coordination entre les équipes Dev et Ops.

## 4.4.3 Personnabilité et évolutivité

Le tableau de bord est conçu de manière à être personnalisable en fonction des besoins spécifiques de l'équipe.
Des ajustements réguliers sont effectués pour garantir la pertinence des informations affichées et pour répondre aux évolutions du projet.

Cette intégration d'Azure DevOps dans notre processus quotidien a considérablement amélioré la communication et la collaboration au sein de l'équipe, renforçant ainsi l'efficacité globale du projet.

## 4.4.4 Météo d'équipe

Afin de nous assurer de la motivation de tous les membres de l'équipe et pour prévenir les baisses de motivations ou encore les problèmes psychologiques par rapport à ce projet nous avons mis en place des réunions météo d'équipe.

Ces réunions permettent à chacun d'exprimer honnêtement ses ressentis sur le projet et l'équipe en y indiquant son niveau de motivation et son implication ressentie dans le projet.

En plus de tout cela ces réunions nous permettend d'améliorer continuellement la façon de faire et l'accompagnemet des membres du groupe en fonction de leurs besoins.

![Meteo](Images/Météo_d'équipe.png)

## 4.4.5 Taleau classique

Suite à des remarques au sein du groupe sur le fait que nous ne nous tenions pas assez au courant de l'avancée et du contenu des réalisations du coté DEV ou OPS,
nous avons decidé de mettre en place une phase d'explpication des avancements de chacun sur un tableau blanc.

Dans ce tableau nous retrouvons ce qui a été fait par chaque partie avec un explication lors que nécessaire, ainsi que ce qu'il reste à faire,
en détaillant ce qui concerne une partie de l'équipe et ce qui peut-être fait en commun.

| OPS														|     DEV												 |     A faire						   |    Travail en commun    |
|-----------------------------------------------------------|:------------------------------------------------------:|:-----------------------------------:|:-----------------------:|
| Métriques Zabbix finies 2/3								|           BDD seedée avec les données Spotify			 |		  Script de restauration  	   |           [ ]           |
| Grafana accessible depuis réseau externe					|        Remise en forme des routes						 |		         Firewall  	           |           [ ]           |
| Dashboards Grafana terminés								|    Corrections des jalons précédents presque finis     |		        Pagination  	       |           [ ]           |
| Remontées de logs sur les serveurs						|    Mise en place des logs								 |		        Middleware  	       |           [ ]           |
| AppArmor terminé (Cloisonement et sécurisation des infra)	|    Couche de services (vide pour le moment)			 |		 Compléter couche services     |           [ ]           |
| Script de backup terminé									|    Filtres											 |		  Tester environnements  	   |           [x]           |
| Docsify en cours											|														 |		  Compléter documentation  	   |           [x]           |
| Protection de Nginx (blocage accès pas l'extérieur)		|														 |									   |                         |
| Rédaction de la documentation								|														 |									   |                         |

<center>Tableau datant du 08/03/2024</center>