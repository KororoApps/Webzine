# **5. PROBLEMES TECHNIQUES** ##

## 5.1. Ce qui n'a pas été réalisé

### 5.1.1. Création de la base de donnée dans l'environnement de Production

Lors du lancement de l'application dans un environnement de Production, la base de données ne doit pas être supprimée, cependant, à chaque lancement de l'application, une base de données est créée.

Nous n'avons pas eu le temps de le mettre en place, mais l'idéal aurait été de vérifier qu'une base de donnée n'existe pas déjà, et dans le cas où une BDD est déjà présente, indiquer qu'il ne faut pas la créer.

## 5.2. Ce qui a été mal réalisé

### 5.2.1. Uniformisation du code

Le code n'est pas uniforme sur l'ensemble de l'application malgré plusieurs code reviews.

L'idéal est que chacun prenne le temps pour relire entièrement le code et vérifier qu'il est écrit de la même manière sur l'ensemble de l'application.

## 5.3. Erreurs commises

### 5.3.1. Manque de code reviews

Nous n'avons pas assez fait de code review, ce qui fait défaut à notre groupe puisque nous ne savons pas toujours de quelle manière la personne qui a rédigé le code l'a fait ainsi et comment cela le rend fonctionnel.

De plus, le manque de code review a laissé passer des erreurs dans le code qui a par le suite impacté le bon fonctionnement de l'application.

### 5.3.2. Manque d'échanges pendant les daily meeting

Nous n'avons pas pris le temps d'approfondir le sujet lorsque quelqu'un nous a indiqué butter sur un sujet pendant les daily mettings.

Cela est particulièrement notable du côté ops.

L'un de nos camarades été bloqué sur un sujet, mais nous n'avons pas insisté pour connaître les raisons de ce bloquage et ce qu'il allait faire pour résoudre le problème.
Cela nous a porté défaut puisque le Grafana n'a pas pu être réalisé pour le Jalon 2.

## 5.4. Progrès réalisés

À travers les trois jalons de notre projet, nous avons tracé un chemin d'apprentissage et de progrès remarquable. 
Débutant avec l'objectif ambitieux de créer une plateforme Webzine dédiée à la musique, nous avons relevé des défis techniques et organisationnels avec détermination et esprit d'équipe.

### 5.4.1. Jalon 1

Le premier jalon nous a permis de progresser rapidement dans l'élaboration d'une application complète, suivant la composition MVC.
Nous avons appris à créer une application visuellement convaincainte en C# et ASP.Net Core avec l'aide de Bootstrap, Font Awesome et Bogus.

### 5.4.2. Jalon 2

Le deuxième jalon a marqué une transition vers une application, non seulement fonctionnelle visuellement, mais également fonctionnelle réellement à l'aide de la mise en place d'une base de données, permettant ainsi d'ajouter et de supprimer des données.

### 5.4.3. Jalon 3

Enfin, le troisième jalon a représenté le point culminant de notre projet, où nous avons enrichi notre application avec de l'édition des données et la mise en place d'un seeder Spotify.

### 5.4.4. En résumé

Dans l'ensemble, ce projet a renforcé notre collaboration  Dev/Ops et nos compétences techniques. 

Nous n'avions jamais utilisé réellement Azure DevOps pour la répartition et le suivi des tâches.
Ce projet nous a poussé à l'utiliser plus approfondi, allant jusqu'à créer un Dashboard pour le suivi de l'avancement des tâches au sein de toute l'équipe.

Nous savons maintenant utiliser des méthodes rigoureuses pour s'organiser et renforcer la cohésion d'équipe, permettant de surmonter les obstacles grâce à une collaboration proactive. 

Les leçons apprises témoignent de notre engagement envers l'excellence et notre capacité à relever de nouveaux défis à l'avenir.

## 5.5. Comment être plus efficace

De part l'amélioration continue, nous apprennons de nos erreurs et ne saurons que faire mieux pour la suite.

Nous allons donc améliorer notre communication au sein de toute l'équipe pour mieux compérendre l'avancée et les bloquages de administrateurs réseaux.

Nous tâcherons de réaliser bien plus méthodiquement des code reviews afin de détecter au plus tôt les erreurs dans le code de chacun et de comprendre le fonctionnement de la fonctionnalité créée.

## 5.6. Améliorations techniques possibles

Une des améliorations techniques notables serait d'ajouter un fichier de configuration, global pour l'application, qui soit plus facile à comprendre pour le client que la modification du fichier appSettings.

Ainsi, il n'y aurait également pas de rique que le client puisse modifier le code par erreur.
