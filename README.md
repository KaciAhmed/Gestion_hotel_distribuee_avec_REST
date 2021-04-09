# GestionHotelDistribueParAgenceDeVoyage

HMIN 210, Service web SOAP, Version distribuée-Agence de voyage et hôtels.

# Objectifs :

## Version distribuée-Agence de voyage et hôtels.

* Modifiez la conception UML précédente pour intégrer le fait qu’un hôtel peut avoir des agences partenaires qui chacune bénéficie d’un tarif propre (un pourcentage par rapport à un prix de base d’une chambre).

* Proposez une version distribuée de l’application sans base de données où :
    * La réservation d’hôtels se fait via une agence de voyage qui accède aux données des hôtels via leurs services web respectifs. Les prix proposés par les hôtels peuvent être adaptés en fonction des agences (les agences peuvent avoir des prix différents pour les mêmes produits/chambres. L’utilisateur final est un client de l’agence qui dispose d’un menu pour bénéficier des services de l’agence.
    * Chaque hôtel aura son propre serveur et ainsi ses propres services web pour pouvoir :
        * Service web 1 : Consulter les disponibilités par les agences partenaires où :
            * Les données en entrée du service web concernent :
                * Identifiant et mot de passe de l’agence.
                * Dates début et fin de la réservation. 
                * Nombre de personnes à héberger.
            * Les données en réponse du service web :
                * Une liste d’offres où une offre est caractérisée par :
                    * Un Identifiant de l’offre.
                    * Type de chambre : nombre de lits.
                    * Date de disponibilité.
                    * Prix.
        * Service web 2 : Effectuer une réservation où :
            * Les données en entrée du service web concernent :
                * Identifiant de l’agence.
                * Login.
                * Mot de passe.
                * Identifiant de l’offre.
                * Informations personne principale.
            * Les données en réponse du service web :
                * Confirmation de la réservation ou problème.
                * Référence de la réservation si cette dernière est confirmée.

# Preview

<img src="https://puu.sh/HwaNk/57b4c01e87.png" width="auto">

## Version distribuée- service web intègre des images.

* Modifier l’application précédente pour que le service « Service web 1 : Consulter
les disponibilités par les agences partenaires » puisse retourner une image de la
chambre proposée au client.

# Preview

<img src="https://puu.sh/HwaPC/50ac247fcd.png" width="auto">

## (Bonus) Version distribuée- Base de données et interface graphique. 

* Modifiez la version distribuée de l’application pour intégrer une base de données
pour stocker les données persistantes.
* Proposez une interface graphique pour l’application agence.

# Preview

* v1
<img src="https://puu.sh/HwaIy/e15de2f9c8.gif" width="auto">

* v2
<img src="https://puu.sh/HwPdv/f3c634f90c.png" width="auto">
