
<h1 style="text-align: center; font-weight: bold;background-color: white; padding: 5px 5px 5px 5px; border-radius: 15px; color: black;">MISE EN PLACE D'UN REVERSE PROXY NGINX</h1>
	
<h2 style="text-align: center; font-weight: bold; margin-top: 15px;">Sommaire</h2>
<ol>
	<li><a href="#prerequis">Prérequis (Optionnel)</a></li>
	<li><a href="#installation">Installation d'nginx</a></li>
	<li><a href="#configuration">Configuration du reverse proxy</a></li>
	<li><a href="#appliquer">Appliquer la configuration</a></li>
</ol>

<h2 style="text-align: center; font-weight: bold; margin-top: 15px;" id="prerequis">Prérequis (Optionnel)</h2>

> [!NOTE]
> Pour simplifier l'édition des adresses IP pour la résolution des différents serveurs il est préférable de centraliser toutes les adresses dans le fichier **`hosts`**.



Éditer le fichier **`/etc/hosts`** pour permettre la résolution des différents serveurs via des noms de domaines :

```
127.0.0.1       localhost
127.0.1.1       SRV-FRONT
192.168.0.11    SRV-WEB
192.168.0.12    SRV-BDD
192.168.0.13    SRV-LOG
192.168.0.14    SRV-BACKUP
192.168.0.15    SRV-ZABBIX-FRONT
192.168.0.16    SRV-ZABBIX
192.168.0.17    SRV-ZABBIX-BDD
```

<h2 style="text-align: center; font-weight: bold; margin-top: 15px;" id="installation">Installation d'nginx</h2>

Pour commencer installer nginx via cette commande :

```shell
apt update && apt upgrade -y && apt install nginx -y
```

<h2 style="text-align: center; font-weight: bold; margin-top: 15px;" id="configuration">Configuration du reverse proxy</h2>

Créer ensuite un répertoire **`old`** :

```shell
mkdir /etc/nginx/sites-available/old
```

Et déplacer tous les fichiers qui ce trouve dans le répertoire **`sites-available`** vers le dossiers **`old`** que nous venons de créer :

```shell
mv /etc/nginx/sites-available/!(old) /etc/nginx/sites-available/old/
```

Créer ensuite le fichier **`01-srv-web`** dans le répertoire **`sites-available`** :

```shell
vim /etc/nginx/sites-available/01-srv-web
```

Et entrez y la configuration ci-dessous :

```nginx
server {
        listen 80;

        location /web {
	            proxy_pass http://SRV-WEB/;
        }

        location /zabbix {
                proxy_pass http://SRV-ZABBIX-FRONT/zabbix/;
        }
}
```

<h2 style="text-align: center; font-weight: bold; margin-top: 15px;" id="appliquer">Appliquer la configuration</h2>

Dans un premier temps supprimer tous le contenu du répertoire **`sites-enabled`** :

```shell
rm /etc/nginx/sites-enabled/*
```

Puis créer un lien symbolique du fichier **`01-srv-wev`** vers le répertoire **`sites-enabled`** :

```shell
ln -s /etc/nginx/sites-available/01-srv-web /etc/nginx/sites-enabled/01-srv-web
```

Pour finir vérifier le statut du service nginx :

```shell
systemctl status nginx
```

Si le service et déjà activer faite :

```shell
systemctl reload --now nginx
```

Sinon faite :

```shell
systemctl enable --now nginx
```