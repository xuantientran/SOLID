La Vue interacte avec le Présenteur:
- La Vue délègue toutes les actions déclenchées par les évènements de l'utilisateur au Présenteur.
- Le Présenteur récupère ou modifie les données du Modèle.
- Le Présenteur met à jours la Vue

Pour interagir avec la Vue et le Modèle:
- le Présenteur a besoin d'une instance de la Vue et celle du Modèle.
- La Vue et le Modèle fournissent des méthodes au Présenteur.

Pour interagir avec le Présenteur:
- La Vue a besoin d'une instance du Présenteur. Lors des évènements issus de l'utilisateur, la Vue délègue des actions au Présenteur.

Le Modèle est passif, il n'a besoin d'acune instance de la Vue ou du Présenteur.

Pour réduire le niveau de couplage avec le Modèle et la Vue, le Présenteur travaille avec leur interface (ICustomerRepository et ICustomerView)