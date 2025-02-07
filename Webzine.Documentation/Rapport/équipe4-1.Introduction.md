# **1. INTRODUCTION** ##
 
Le projet répond au besoin du client de développer une application web de type Webzine, un magazine publié sous la forme d'un site web. </br>
L'objectif principal de ce webzine est de présenter des chroniques détaillées sur des artistes musicaux et leurs titres.

Les fonctionnalités clés de l'application incluent la possibilité pour les utilisateurs de consulter les chroniques rédigées par les créateurs des pages, de laisser des avis, et aussi de créer leurs propres pages de revue. </br>
Ce concept favorise une interaction dynamique entre les amateurs de musique et les contributeurs, créant ainsi une communauté engagée autour de la passion musicale.

Outre la réalisation des objectifs fonctionnels, ce projet vise à renforcer la cohésion entre les équipes de développement (Devs) et réseau (OPS). </br> 
La collaboration étroite entre ces deux domaines est essentielle pour garantir le bon fonctionnement, la performance et la maintenance de l'application web.

## 1.1. Technologies utilisées

Les technologies sélectionnées pour la réalisation de ce projet sont spécifiées selon les besoins des équipes :

### 1.1.1. Côté DEV

 - **C#** et **ASP.NET Core 8.0**, pour la mise en place robuste et efficace du backend de l'application;
 - **Bootstrap**, pour élaborer le CSS;
 - **FontAwesome** pour récupérer des icônes;
 - **SQLite**, pour la base de données dans l'environnement de développement;
 - **PostGgreSQL**, pour la base de données dans l'environnement de production.

### 1.1.2. Côté OPS

- **Zabbix**, pour réaliser la supervision des serveurs ainsi qu'une gestion proactive de l'infrastructure et une réponse rapide aux éventuels problèmes de performance;
- **Nginx** pour le frontend;
- **Grafana**, pour obtenir des dashboards et graphiques;
- **Loki**, pour collecter les logs;
- **Fail2ban**, pour la protection contre les brutes-forces.

## 1.2. L'équipe

### 1.2.1. Présentation

Notre équipe de projet est composée de 4 développeurs :

- Dylann-Nick Etou

- Antoine Couvert

- Lucas Fernandez
  
- Elodie Sponton

et 3 opérateurs réseaux :

- Jean-Emilien Viard

- Andgel Sassignol

- Romain Vidotto


### 1.2.2. Chef de projet

L'équipe est sous la responsabilité de M.Sassignol, chef de projet.

</br>

La suite du rapport détaille l’organisation au sein de l’équipe qu’il s’agisse de la partie DEV ou OPS. </br>
Il passera en revue la cohésion que nous avons mis en place afin de nous tenir informés des réalisations de chacun avant de revenir sur les problèmes rencontrés tout au long de ce projet.

# **2. STRUCTURE DU PROJET** ##


## 2.1. Architecture MVC

Le développement de ce projet suit une approche "en couches", une méthode qui implique l'ajout progressif de couches distinctes pour assurer une structure organisée.

Dans notre cas, nous avons introduit les couches Repository et Context. Cela a pour but de segmenter efficacement le processus de récupération des données, renforçant ainsi la modularité de notre application.

![Schema](images/Structure_du_Projet.png)

Le fichier context permet de définir la configuration de la base de données ainsi que la définition des entitées qu'elle doit contenir.</br>

Le Context facilite les migrations de base de données permettant de changer le schéma de la base de données avec les évolutions de l'application.