
<h1 style="text-align: center; font-weight: bold;background-color: white; padding: 5px 5px 5px 5px; border-radius: 15px; color: black;">MISE EN PLACE DE FAIL2BAN</h1>

<h2 style="text-align: center; font-weight: bold; margin-top: 15px;">Sommaire</h2>
<ol>
	<li><a href="#prerequis">Prérequis</a></li>
	<li><a href="#installation">Installation de fail2ban</a></li>
	<li><a href="#configuration">Configuration de fail2ban</a></li>
	<li><a href="#appliquer">Appliquer la configuration</a></li>
</ol>

<h2 style="text-align: center; font-weight: bold; margin-top: 15px;" id="prerequis">Prérequis</h2>

Installer syslog-ng via cette commande :

```shell
apt update && apt upgrade -y && apt install syslog-ng -y
```

Éditer le fichier **`/etc/systemd/journald.conf`** pour permettre la redirection des logs de journald vers syslog en décommentant la ligne **`#ForwardToSyslog=yes`** :

```journald
[...]
ForwardToSyslog=yes
[...]
```

<h2 style="text-align: center; font-weight: bold; margin-top: 15px;" id="installation">Installation de fail2ban</h2>

Pour commencer installer fail2ban via cette commande :

```shell
apt update && apt upgrade -y && apt install fail2ban iptables -y
```

<h2 style="text-align: center; font-weight: bold; margin-top: 15px;" id="configuration">Configuration de fail2ban</h2>

Nous allons ensuite créer les fichiers **`sshd.local`**, **`nginx.local`**, **`nginx.conf`** et **`jail.local`** :

```shell
touch /etc/fail2ban/jail.d/sshd.local /etc/fail2ban/jail.d/nginx.local /etc/fail2ban/filter.d/nginx.conf /etc/fail2ban/jail.local
```

Et y entrer la configuration suivante pour **`sshd.local`** :

```shell
vim /etc/fail2ban/jail.d/sshd.local
```

```fail2ban
[sshd]
enabled  = true
port     = ssh
filter   = sshd
logpath  = /var/log/auth.log
```

Cette configuration pour le filtre **`nginx.conf`** :

```shell
vim /etc/fail2ban/filtre.d/nginx.conf
```

```fail2ban
[Definition]
failregex = ^<HOST>.*"(GET|POST).*" (403|404) .*$
ignoreregex =
```

Cette configuration pour **`nginx.local`** :

```shell
vim /etc/fail2ban/jail.d/nginx.local
```

```fail2ban
[nginx]
enabled = true
port = http,https
filter = nginx
logpath = /var/log/nginx*/*access.log
action = nftables-multiport[name=404, port="http,https", protocol=tcp]
```

Et pour finir cette configuration pour **`jail.local`** :

```shell
vim /etc/fail2ban/jail.local
```

```fail2ban
[DEFAULT]

maxretry = 3
findtime = 1m
bantime = 5m

banaction = nftables-multiport
banaction_allports = nftables-allports
```

<h2 style="text-align: center; font-weight: bold; margin-top: 15px;" id="appliquer">Appliquer la configuration</h2>

Pour appliquer la configuration il suffit de recharger le daemon fail2ban :

```shell
systemctl reload --now fail2ban
```
