# Installation de ZABBIX

##### 1. Mise en place commune sur tous les serveurs : 

Pensez à changer votre hostname:

```bash
nano /etc/hostname

nano /etc/hosts
```

Pensez à changer votre configuration réseau:

```bash
nano /etc/network/interfaces
```
NTP client : Installez Chrony :

```bash
apt install chrony
```

Activez et démarrez Chrony au démarrage de la machine :

```bash
systemctl enable chrony --now
```

Lister les sources disponibles et utilisées par Chrony :

```bash
chronyc sources
```

Pensez à vérifier votre `timezone` avec :

```bash
timedatectl status
```

_Note : Si besoin de changer : timedatectl set-timezone Europe/Paris_.

##### 2. Installation du front : (SRV-ZABBIX-FRONT)

Installation du front

```bash
sudo apt install apache2 php libapache2-mod-php php-pgsql php-xml php-mbstring
sudo apt install zabbix-frontend-php
```

Rechargez les services pour appliquer la nouvelle configuration :

```bash
systemctl restart zabbix-server apache2 
systemctl enable apache2 zabbix-server
```

Ajouter les dépôts si nécessaire : 

```bash
wget https://repo.zabbix.com/zabbix/6.0/debian/pool/main/z/zabbix-release/zabbix-release_6.0-5+debian12_all.deb
dpkg -i zabbix-release_6.0-5+debian12_all.deb
apt update
```

Modifier le fichier zabbix.conf.php:

```bash
nano /etc/zabbix/web/zabbix.conf.php
```

```php
$DB['TYPE']                     = 'POSTGRESQL';
$DB['SERVER']                   = '192.168.0.17';
$DB['PORT']                     = '5432';
$DB['DATABASE']                 = 'zabbix';
$DB['USER']                     = 'zabbix';
$DB['PASSWORD']                 = 'P@ssw0rd';

$ZBX_SERVER                     = '192.168.0.16';
$ZBX_SERVER_PORT                = '10051';
```

Redémarrer Apache2 : 
```bash
systemctl restart apache2
```

##### 3. Installation la BDD : (SRV-ZABBIX-BDD)

Installez le service `PostgreSQL` :

```bash
apt install postgresql-15 postgresql-client-15 -y
```

Lancez le cluster PG avec la commande suivante et controlez son lancement, puis, automatisez son lancement automatique à chaque redemarrage de la machine:

```bash
pg_ctlcluster 15 main start
systemctl status postgresql@15-main.service
systemctl enable postgresql
```

Modifier la configuration de postgresql:

```bash
nano /etc/postgresql/15/main/postgresql.conf

listen_addresses = '*';
```

```bash
nano /etc/postgresql/15/main/pg_hba.conf
# Ajouter la ligne à la fin du fichier:
host all all 0.0.0.0/0 scram-sha-256
```

Redémarrer postgresql

```bash
systemctl restart postgresql
```
Pour des raisons de sécurités, changez le mot de passe du compte `postgres` sur le SGBD lui même :

```bash
su postgres
psql
```

Définir un mot de passe à l'utilisateur postgres

```sql
ALTER USER postgres PASSWORD 'P@ssw0rd';
\q
```

Créez la base de données :

Créer l'utilisateur zabbix

```bash
adduser zabbix
```

Connectez vous à PostgreSQL en utilisant la commande

```bash
sudo -u postgres psql
```

Créez la base de données :

```bash
sudo -u postgres createuser --pwprompt zabbix

sudo -u postgres createdb -O zabbix zabbix
```

Créez une base de données pour Zabbix avec la commande

```sql
CREATE DATABASE zabbix;
```

Créez un utilisateur pour Zabbix avec la commande

```sql
CREATE USER zabbix WITH PASSWORD 'your_password';

GRANT ALL PRIVILEGES ON DATABASE zabbix TO zabbix;
```

Puis on importe le schéma de la base :

```bash
ssh user@192.168.0.16 sudo zcat /usr/share/zabbix-sql-scripts/postgresql/server.sql.gz | sudo -u zabbix psql zabbix
```

##### 4. Installation de zabbix : (SRV-ZABBIX)

Installez Zabbix :

```bash
wget https://repo.zabbix.com/zabbix/6.0/debian/pool/main/z/zabbix-release/zabbix-release_6.0-5+debian12_all.deb
dpkg -i zabbix-release_6.0-5+debian12_all.deb
apt update
apt install sudo zabbix-server-pgsql zabbix-sql-scripts 
```

Modifier le fichier /etc/zabbix/zabbix_server.conf :

````bash
DBHost=192.168.0.17
DBName=zabbix
DBUser=zabbix
DBPassword=P@ssw0rd
````

Redémarrer le service Zabbix :

```bash
systemctl restart zabbix-server.service
```

Maintenant zabbix est configuré, se rendre sur la page ip/zabbix pour finaliser la configuration.

##### 5. Ajouter un Hôte :

Installer les dépôts zabbix et l'agent zabbix :

```bash
wget https://repo.zabbix.com/zabbix/6.0/debian/pool/main/z/zabbix-release/zabbix-release_6.0-5+debian12_all.deb
dpkg -i zabbix-release_6.0-5+debian12_all.deb
apt update
apt install zabbix-agent
```

Modifier le fichier /etc/zabbix/zabbix_agentd.conf :

```bash
nano /etc/zabbix/zabbix_agentd.conf

Server=192.168.0.16
ServerActive=192.168.0.16
Hostname=SRV-ZABBIX 
```

Redémarrer le service Zabbix :

```bash
systemctl restart zabbix-server.service
```

###### Rendez-vous dans zabbix : 

**On crée un groupes pour mettre toute nos machines****

Configuration -> Groupes d'hôtes -> Créer un groupes d'hôtes :

Nom du groupe : LAN servers
Ajouter

**On ajoute un hôtes 

Configuration -> Hôtes -> Créer un hôte : 

Nom de l'hôte : nom du serveur (SRV-ZABBIX)
Groupes : LAN servers
Interface -> ajouter -> Agent -> ip du serveur ou nom DNS
Activé -> coché 
