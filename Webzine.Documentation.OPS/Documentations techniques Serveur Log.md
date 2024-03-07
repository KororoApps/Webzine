
Infos réseau :

Adresse IP : 192.168.0.13
Masque: 255.255.255.0
Passerelle: 192.168.0.10


# 1. Installation et configuration de Grafana

Pré-requis

- Disposer d'un serveur Linux avec une distribution compatible (Debian ou Ubuntu)
    
- Être connecté à ce serveur en root ou, à défaut, avec un utilisateur avec les droits sudo
    
- Avoir installé les packages `zip` et `curl` :
    
    ```shell
    apt update && apt install -y curl zip
    ```
    

## Installation du service via apt

1. Commencer par installer les services requis pour installer le dépôt officiel de Grafana :
    
    ```shell
    apt update && apt install -y apt-transport-https software-properties-common gnupg gnupg2 wget
    ```
    
2. Installer la clé publique du dépôt de Grafana :
    
    ```shell
    sudo mkdir -p /etc/apt/keyrings/
    wget -q -O - https://apt.grafana.com/gpg.key | gpg --dearmor | tee /etc/apt/keyrings/grafana.gpg > /dev/null
    ```
    
3. Ajout du dépôt en spécifiant la clé téléchargée précédemment :
    
    ```shell
    echo "deb [signed-by=/etc/apt/keyrings/grafana.gpg] https://apt.grafana.com stable main" | tee -a /etc/apt/sources.list.d/grafana.list
    ```
    
4. Mettre à jour les apt et installer Grafana :
    
    ```shell
    apt update && apt install grafana
    ```
    
5. Activer le daemon et lancer le service Grafana
    
    ```shell
    systemctl daemon-reload
    systemctl enable grafana-server
    systemctl start grafana-server
    ```
    
6. Vérifier que le service est up :
    
    ```shell
    systemctl status grafana-server
    ```
    

Le service est maintenant accessible sur le port `3000` de la machine.

# 2. Installation et configuration de Loki

Dans cette documentation, nous allons installer et configurer le package Loki.

## Prérequis

- Disposer d'un serveur Linux avec une distribution compatible (Debian ou Ubuntu)
    
- Être connecté à ce serveur en root ou, à défaut, avec un utilisateur avec les droits sudo
    
- Avoir installé les packages `zip` et `curl` :
    
    ```shell
    apt update && apt install -y curl zip
    ```
    

## Installation du binaire

1. Se rendre sur le dépôt officiel de Loki, dans la section [Releases](https://github.com/grafana/loki/releases/)
    
2. Repérer la version de Loki que l'on souhaite installer. Dans notre cas, il s'agit de la version `2.9.4`
    
3. Effectuer la commande `curl` suivante avec la version du package correspondant :
    
    ```shell
    curl -O -L "https://github.com/grafana/loki/releases/download/v2.9.4/loki-linux-amd64.zip"
    ```
    
4. Dézipper le zip téléchargé dans le répertoire `/usr/local/bin/` :
    
    ```shell
    unzip -d /usr/local/bin/ loki-linux-amd64.zip
    ```
    
5. Une fois le binaire dézippé, il faudra le renommer en `loki` :
    
    ```shell
    mv /usr/local/bin/loki-linux-amd64  /usr/local/bin/loki
    ```
    
6. Rajouter des droits d'exécution au binaire avec la commande `chmod` :
    
    ```shell
    chmod +x /usr/local/bin/loki
    ```
    

Le binaire est maintenant installé et prêt à être utilisé. La prochaine étape consistera à créer le fichier de configuration nécessaire à Loki.

## Création du fichier de configuration

1. Créer le répertoire `/etc/loki` et s'y déplacer :
    
    ```shell
    mkdir /etc/loki && cd /etc/loki
    ```
    
2. Récupérer la dernière version du fichier de configuration de Loki en le renommant en `loki.yaml` :
    
    ```shell
    wget -O loki.yaml https://raw.githubusercontent.com/grafana/loki/main/cmd/loki/loki-local-config.yaml
    ```
    
3. Créer un répertoire `/data/loki` :
    
    ```shell
    mkdir /data/loki -p
    ```
    
4. Editer le fichier `loki.yaml` et modifier le répertoire utilisé par Loki pour stocker ses données par `/data/loki` :
    
    ```yaml
    common:
      instance_addr: 127.0.0.1
      path_prefix: /data/loki
      storage:
        filesystem:
          chunks_directory: /data/loki/chunks
          rules_directory: /data/loki/rules
    ```
    
5. A la fin du fichier, renseigner les éléments suivants pour configurer la rétention :
    
    ```yaml
    compactor:
      working_directory: /data/loki/retention
      compaction_interval: 10m
      retention_enabled: true
      retention_delete_delay: 2h
      retention_delete_worker_count: 150
    storage_config:
        boltdb_shipper:
            active_index_directory: /data/loki/index
            cache_location: /data/loki/boltdb-cache
    
    limits_config:
      retention_period: 180d
    #  retention_stream:
    #  - selector: '{job="syslog"}'
    #    priority: 1
    #    period: 24h
    ```
    
6. Sauvegarder le fichier.
    

Le fichier de configuration est maintenant prêt à être utilisé par Loki. La prochaine étape consistera à créer le service pour Loki avec `systemd`.

## Création du fichier service et du compte de service dédié

1. Création de l'utilisateur système :
    
    ```shell
    useradd --system loki
    ```
    
2. Modifier le propriétaire des dossiers `/data/loki` et `/etc/loki` par loki :
    
    ```shell
    chown loki: /data/loki -R && chown loki: /etc/loki -R
    ```
    
3. Editer le fichier `nano /etc/systemd/system/loki.service` :
    
    ```shell
    nano /etc/systemd/system/loki.service
    ```
    
4. Renseigner les informations suivantes :
    
    ```
    [Unit]
    Description=Loki Service
    After=network.target
    
    [Service]
    Type=simple
    User=loki
    ExecStart=/usr/local/bin/loki -config.file /etc/loki/loki.yaml
    
    [Install]
    WantedBy=multi-user.target
    ```
    
5. Activer et démarrer le service :
    
    ```shell
    systemctl enable loki & systemctl start loki
    ```
    
6. Vérifier l'état du service :
    
    ```shell
    systemctl status loki
    ```
    

Le service est désormais prêt à être utilisé.

# 3. Installation et configuration de Promtail

Dans cette documentation, nous allons installer et configurer Promtail.

Toutes les étapes suivies sont globalement les mêmes que pour l'installation de Loki.

## Prérequis


- Disposer d'un serveur Linux avec une distribution compatible
    
- Être connecté à ce serveur en root ou, à défaut, avec un utilisateur avec les droits sudo
    
- Avoir installé les packages `zip` et `curl` :
    
    ```shell
    apt update && apt install -y curl zip
    ```
    

## Installation du binaire

1. Se rendre sur le dépôt officiel de Loki, dans la section [Releases](https://github.com/grafana/loki/releases/)
    
2. Repérer la version de Loki que l'on souhaite installer. Dans notre cas, il s'agit de la version `2.9.4`
    
3. Effectuer la commande `curl` suivante avec la version du package correspondant :
    
    ```shell
    curl -O -L "https://github.com/grafana/loki/releases/download/v2.9.4/promtail-linux-amd64.zip"
    ```
    
4. Dézipper le zip téléchargé dans le répertoire `/usr/local/bin/` :
    
    ```shell
    unzip -d /usr/local/bin/ promtail-linux-amd64.zip
    ```
    
5. Une fois le binaire dézippé, il faudra le renommer en `promtail` :
    
    ```shell
    mv /usr/local/bin/promtail-linux-amd64  /usr/local/bin/promtail
    ```
    
6. Rajouter des droits d'exécution au binaire avec la commande `chmod` :
    
    ```shell
    chmod +x /usr/local/bin/promtail
    ```
    

Le binaire est maintenant installé et prêt à être utilisé. La prochaine étape consistera à créer le fichier de configuration nécessaire à Promtail.

## Création du fichier de configuration

1. Créer le répertoire `/etc/promtail` et s'y déplacer :
    
    ```shell
    mkdir /etc/promtail && cd /etc/promtail
    ```
    
2. Récupérer la dernière version du fichier de configuration de Loki en le renommant en `loki.yaml` :
    
    ```shell
    wget -O promtail.yaml https://raw.githubusercontent.com/grafana/loki/main/clients/cmd/promtail/promtail-local-config.yaml
    ```
    
3. Editer le fichier `/etc/loki/loki.yaml`. A la fin du fichier, rajouter le bloc de configuration suivant :
    
    ```yaml
    [...]
    - job_name: syslog
      syslog:
        listen_address: 0.0.0.0:1514
        listen_protocol: tcp
        idle_timeout: 12h
        labels:
          job: syslog
        relabel_configs:
          - source_labels: [__syslog_message_hostname]
            target_label: host
          - source_labels: [__syslog_message_severity]
            target_label: severity
          - source_labels: [__syslog_message_app_name]
            target_label: application
          - source_labels: [__syslog_message_facility]
            target_label: facility
    ```
    
4. Sauvegarder le fichier.
    

Le fichier de configuration est maintenant prêt à être utilisé par Promtail. La prochaine étape consistera à créer le service pour Promtail avec `systemd`.

## Création du fichier service

1. Création de l'utilisateur système :
    
    ```shell
    useradd --system promtail
    ```
    
2. Modifier le propriétaire du dossier `/etc/promtail` par promtail :
    
    ```shell
    chown promtail: /etc/promtail -R
    ```
    
3. Editer le fichier `nano /etc/systemd/system/promtail.service` :
    
    ```shell
    nano /etc/systemd/system/promtail.service
    ```
    
4. Renseigner les informations suivantes :
    
    ```
    [Unit]
    Description=Promtail Service
    After=network.target
    
    [Service]
    Type=simple
    User=promtail
    ExecStart=/usr/local/bin/promtail -config.file /etc/promtail/promtail.yaml
    
    [Install]
    WantedBy=multi-user.target
    ```
.
    
5. Activer et démarrer le service :
    
    ```shell
    systemctl enable promtail & systemctl start promtail
    ```
    
6. Vérifier l'état du service :
    
    ```shell
    systemctl status promtail
    ```
    

Le service est désormais prêt à être utilisé.

# 4. Configuration de rsyslog

Le service rsyslog est configuré de sorte à recevoir les logs de manière chiffrée et non chiffrée.

Pour des raisons techniques, la réception des logs se fera par les protocoles TCP et UDP.

## Ajouter la configuration du relai Promtail

L'architecture retenue requiert la configuration d'un relai pour que les logs reçus par rsyslog puissent être transférés à Promtail.

1. Editer un nouveau fichier de configuration `/etc/rsyslog.d/promtail-relay.conf` :
    
    ```shell
    nano /etc/rsyslog.d/promtail-relay.conf
    ```
    
2. Renseigner les lignes suivantes dans ce fichier :
    
    ```shell
    ruleset(name="remote"){
        # https://grafana.com/docs/loki/latest/clients/promtail/scraping/#rsyslog-output-configuration
        
        action(
            type="omfwd"
            protocol="tcp"
            target="localhost"
            port="1514"
            Template="RSYSLOG_SyslogProtocol23Format"
            TCP_Framing="octet-counted"
            KeepAlive="on"
        )
    }
    ```
    
3. Sauvegarder le fichier.
    

## Ajout des éléments de logging dans la configuration rsyslog

Editer le fichier `/etc/rsyslog.d/remote-logging-tcp.conf` (nouveau fichier) :

```shell
nano /etc/rsyslog.d/remote-logging-tcp.conf
```

Rajouter ensuite les éléments de configuration suivants :

```
## Tous les messages concernant l'authentification
auth,authpriv.*                 @@(z4)192.168.0.1:514

## Tous les messages en warn et plus sont envoyes dans syslog
*.warn;auth,authpriv.none       @@(z4)192.168.0.1:514

## Tous les messages kern sont envoyes dans kern
kern.*                          @@(z4)192.168.0.1:514

## Tous les messages user sont envoyes dans user
user.*                          @@(z4)192.168.0.1:514

## Tous les autres messages qui ne matchent pas plus haut
## Specificite : on ne les envoie pas au serveur syslog
*.=info;*.=notice;\
        auth,authpriv.none;\
        cron,daemon.none;\
        mail.none               -/var/log/messages

## Ligne speciale : tous les messages emerg sont envoyes aux terminaux ouverts
*.emerg                         @@(z4)192.168.0.1:514
```

### Création du fichier de configuration TCP


Maintenant que l'envoie des logs est configuré, il faut appliquer les éléments de configuration au serveur rsyslog.

1. Editer le nouveau fichier `/etc/rsyslog.d/tcp.conf` :
    
    ```shell
    nano /etc/rsyslog.d/tcp.conf
    ```
    
2. Renseigner les lignes suivantes :
    
    ```shell
    # Disabling excaping characters (#015, #011)
    $EscapeControlCharactersOnReceive off
    
    # Configure the TCP listener
    module(
        load="imtcp"
        KeepAlive="on"
        NotifyOnConnectionClose="on"
    )
    
    input(
        type="imtcp"
        port="514"
        ruleset="remote"
    )
    ```
    
    
3. Valider la configuration rsyslog avec la commande `rsyslogd -N 1` :
    
    ```shell
    $ rsyslogd -N 1
    rsyslogd: version 8.2102.0, config validation run (level 1), master config /etc/rsyslog.conf
    rsyslogd: End of config validation run. Bye.
    ```
    
4. Redémarrer le service rsyslog :
    
    ```shell
    systemctl restart rsyslog
    ```
    

Le service est maintenant prêt à recevoir les logs via TCP.

## Ajouter des clients

Pour ajouter des clients rsyslog (sur des machines avec rsyslog d'installés), il faut faire la même chose que pour le serveur syslog.

Sur le serveur à configurer, éditer le fichier `/etc/rsyslog.d/remote-logging-tcp.conf` (nouveau fichier) :

```shell
nano /etc/rsyslog.d/remote-logging-tcp.conf
```

Rajouter ensuite les éléments de configuration suivants :

```
## Tous les messages concernant l'authentification
auth,authpriv.*                 @@(z4)192.168.0.1:514

## Tous les messages en warn et plus sont envoyes dans syslog
*.warn;auth,authpriv.none       @@(z4)192.168.0.1:514

## Tous les messages kern sont envoyes dans kern
kern.*                          @@(z4)192.168.0.1:514

## Tous les messages user sont envoyes dans user
user.*                          @@(z4)192.168.0.1:514

## Tous les autres messages qui ne matchent pas plus haut
## Specificite : on ne les envoie pas au serveur syslog
*.=info;*.=notice;\
        auth,authpriv.none;\
        cron,daemon.none;\
        mail.none               -/var/log/messages

## Ligne speciale : tous les messages emerg sont envoyes aux terminaux ouverts
*.emerg                         @@(z4)192.168.0.1:514
```