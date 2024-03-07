# Mise en place de la BDD

Installation de Postgresql

```bash
apt update && apt upgrade

apt install postgresql-15
```

Modifier le fichier /etc/postgresql/15/main/pg_hba.conf

```bash
#Ajoute la ligne : 

host  all  all  0.0.0.0/0  scram-sha-256
```

Modifier le fichier /etc/postgresql/15/main/postgresql.conf

```bash
#Modifier la ligne : 

listen_addresses = '127.0.0.1'
#Et remplacer par
listen_addresses = '*'
```

Redémarrer postgresql 

```
systemctl restart postgresql
```

##### Autoriser le serveur à écouteur sur le port 5432 (port de postgresql par défaut)

Installer le paquet ufw

```bash
apt install ufw
```

Autoriser l'écoute sur le port 5432

```bash
ufw allow 5432/tcp
```

On vérifie si le port est ouvert

```bash
ss -lntp
```

On devrait obtenir cette ligne : 
```bash
LISTEN     0     244     [::]:5432      [::]:*   
users:(("postgres",pid=5761,fd=6))
```

On crée la base de donnée par défaut:

```bash
sudo -u postgres psql template1

ALTER USER postgres with encrypted password 'Azerty@123';
```

**Notre service de base donnée est fonctionnelle**

###### On peut se connecter avec Dbeaver:

```
ip : 10.4.1.70
port : 5432
Database : postgres
utilisateur : postgres
mot de passe : Azerty@123
```

###### Si ce n'est pas le cas il faut ajouter une NAT/PAT sur le serveur SRV-FRONT

Créez la table NAT :

```bash
sudo nft add table ip nat
```

 Ajoutez la chaîne PREROUTING pour le NAT  
 
```bash
sudo nft add chain ip nat PREROUTING { type nat hook prerouting priority 0 \; }
```
 
 Ajoutez la règle DNAT pour rediriger le port 5432 vers 192.168.0.12  
 
```bash
sudo nft add rule ip nat PREROUTING tcp dport 5432 dnat to 192.168.0.12
```
 
 Ajoutez la chaîne POSTROUTING pour le NAT
 
```bash
sudo nft add chain ip nat POSTROUTING { type nat hook postrouting priority 100 \; }
```

 Ajoutez la règle de masquerade pour la translation d'adresse de destination 

```bash
sudo nft add rule ip nat POSTROUTING masquerade
```