
# Mise en place de Apparmor

*Je prend pour exemple le service apache2* sur le serveur SRV-ZABBIX-FRONT

*RAPPEL :*
*- Enforce : Profil créé, chargé, les restrictions sont actives*
*- Complain : Profil créé, chargé, les restrictions ne sont pas actives mais simplement journalisées*
*- Unconfined : Profil créé, non chargé, aucun log et aucune restriction*

##### Installation de Apparmor : 

Installer apparmor et syslog

```bash
apt install apparmor-utils syslog-ng
```

Listez l'ensemble des règles déjà actives sur votre machine :

```bash
aa-status
```

Listez l'ensemble des processus qui pourraient recevoir un renforcement sur votre machine (qui ont un port d'écoute ouvert) :

```bash
aa-unconfined
```

On crée la structure du fichier de profil avec :

```bash
aa-autodep apache2
#Pour postgresql :
#aa-autodep /usr/lib/postgresql/15/bin/postgres
```

Vous pouvez aller lire le contenu de ce nouveau fichier généré avec :

```bash
tail /etc/apparmor.d/usr.sbin.apache2
```

_Note : Si vous faites de nouveau un `aa-status` vous pouvez constater que **apache2** est en état `unconfined`. Un profil existe, mais il n'est pas chargé._  

Positionnez vous dans le répertoire `/etc/apparmor.d` puis passez l'état de du service ***apache2*** du mode `unconfined` à `complain` avec :

```bash
cd /etc/apparmor.d/

aa-complain usr.sbin.apache2
```

Cette commande aura pour effet de journaliser tous les éléments exécutés par le binaire ***apache2*** dans le fichier syslog.

```bash
tail -f /var/log/syslog
```

_Note : Si vous faites de nouveau un `aa-status` vous pouvez constater que ***apache2*** est en état `complain`._  

> [!WARNING]
>  ###### **Maintenant, il faut manipuler un maximum le service pour logger l'ensemble de ses accès. Au plus basique :**

```bash
systemctl stop apache2
systemctl start apache2
systemctl restart apache2
```

Une fois effectué, vous pouvez commencer à enregistrer les autorisations dans le fichiers de règle dédié avec :

```bash
aa-logprof usr.sbin.apache2
```

Exemple de ce que l'interface peut vous demander :

```
Updating AppArmor profiles in /etc/apparmor.d.
Reading log entries from /var/log/syslog.
Complain-mode changes:

Profil:         /usr/sbin/apache2
Chemin d'accès: /etc/gai.conf
Nouveau mode:   owner r
Gravité:        unknown

 [1 - owner /etc/gai.conf r,]
(A)llow / [(D)eny] / (I)gnore / (G)lob / Glob with (E)xtension / (N)ew / Audi(t) / (O)wner permissions off / Abo(r)t / (F)inish
```

_Note : Vous pouvez avoir dans un premier temps, cette demande :_

```bash
(I)nherit / (C)hild / (N)amed / (U)nconfined / (X) ix On / (D)eny / Abo(r)t / (F)inish
```

_En ce cas, tapez `I` pour demander un listing des demandes d'accès._

Etant en phase de création, nous allons autoriser toutes les demandes. Pour cela, tapez `A` sur chaque demandes jusqu'à avoir :

```bash
The following local profiles were changed. Would you like to save them?

 [1 - /usr/sbin/apache2]
(S)ave Changes / Save Selec(t)ed Profile / [(V)iew Changes] / View Changes b/w (C)lean profiles / Abo(r)t
```

Faites `S` pour sauvegarder les nouvelles entrées.  
Vous pouvez lire l'ensemble de ces nouvelles entrées :

```bash
more /etc/apparmor.d/usr.sbin.apache2
```

Passez ensuite votre service *apache2* du mode `complain` à `enforce` pour bloquer et journaliser tous les accès non désirés avec :

```bash
aa-enforce usr.sbin.apache2
```

Redémarrez votre service *apache2* pour voir si tout fonctionne toujours :

```bash
service apache2 stop
service apache2 start
```

Vous pouvez constater que le service est bien en état `renforcé` avec :

```bash
aa-status
```

Dans le cas ou les choses ne se passent pas bien, il faut aller lire le fichier syslog `/var/log/syslog` et `/var/log/apache2/error.log` pour constater un problème d'accès (lié au blocage par AppArmor).  
Si le service ne démarre pas, relancez `aa-logprof` et autorisez les éléments manquants :

```bash
aa-logprof
```

*Parfois, après un redémarrage du serveur, le service concerné par le renforcement peut ne plus fonctionner. Cela est dû à d'autres nouveaux éléments qu'il faudra inscrire dans le fichier de règle.*

Vous pouvez désactiver Apparmor à tout moment avec : 

```bash
systemctl stop apparmor
```