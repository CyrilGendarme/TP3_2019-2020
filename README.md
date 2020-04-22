
Objectif : 
	Créer une applciation pour gérer des produits sur un site d'e-commerce, et ce dans une optique SEO par la gestion de thématiques.
	
	
Spécifications :
	Un produit peut être commun à plusieurs collections (thèmes), liste crée des articles de blog en lien avec les thèmes et les produits.
	L'architecture du site est faite de telle sorte que seul les articles de blog ont des liens (dans le texte) pointant vers d'autres pages.
	Étant donné l'objectif de voir le SEO d'un point de vue uniquement thématique ici, le texte n'importe pas vraiment à partir du moment où nous connaisson les mots-clés principaux (et donc normalement les champs lexicaux) abordés par une certaine page
	Les produits doivent être enregistrés dans un tableau excel, peu importe pour le reste.
	
	
Besoin (classes) :
	- Contenu classe dont hériteront toutes les autres sauf mot-clé et thématique
		==>	un nom / titre 
			une date de création

	- IUseMot_clé : une interface pqui possède une méthode retournant une lsite de mots-clé		

	- Produit
		==> un mot-clé non obligatoire (identique au nom du produit et qui contient son volume de recherche)
			une liste de collections
			un fournisseur (= adresse web : String)
			un prix fournisseur
			un prix de vente (une suggestion sera calculée automatiquement à partir du prix fournisseur)

	- Collection
		==>	un mot-clé (ce qui comprend le nom du produit et son volume de recherche)
			une liste de produits
		
	- Article de blog
		==>	une liste de mot-clés 
			une évaluation de la qualité (très subjectif comme ça, peut-être faire ça de manière plus précise si temps suffisant)
			une liste de liens sortants (adresses web, notamment celles du site-même) : String ou créer une lasse spécifique... Cela sera à déterminer plus tard
			
	- Mot-clé 
		==>	mot 
			volume de recherche mensuel (peut être nul dans le cas de produits au très faible volume de recherche car données introuvables)
			difficulté estimé pour se classer dessus
			
	- Thématique : "supra-classe" permettant de regrouper collections et articles de blog associés
		==> une collection
			une liste d'articles de blog
			une liste de mots-clés correspondant à la somme de tous les mots-clés des éléments constituant la thématique (pas besoin de créer de vraible membre grâce à l'interface IUseMot_clé !! )
			
	- Une fenêtre graphique principal : partir sur une interface où les champs proposés évoluent dynamiquement en fonction du type d'objet sur lequel on veut travailler (type TP2)
	    ==>	tout le nécessaire pour créer / modifier les objets ci-dessus
			la sélection des champs devrait ici notamment se faire sous forme de liste (mots-clé, collection, etc) : classée par ordre alphabétique ? par thématique ? Cela reste à voir... 
			
	- Une boite de dialogue pour ajouter facilement des mot-clé
	
	- Des boite de dialogue pour sélectionner un objet (de n'importe quel type, mais c'est surout intéressant pour les thématiques et collections) et ensuite afficher rapidement son contenu
	
	- Une fenêtre "vue globale" pour voir le site du point de vue des thématiques et afficher des infos intéressantes pour l'analyser (reste à voir lesquelles exactement)
	
	
	
Classification en librairies / projets
	- une libraire objets
	- une libraire "interface graphique A" (ajout et modification d'objets)
	- une libraire "interface graphique B" (vue globale du site)