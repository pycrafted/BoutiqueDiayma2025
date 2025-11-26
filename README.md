# Boutique Diayma - Travaux Pratiques

## 1. Récupération et exécution du code

**Code récupéré depuis GitHub et exécuté avec succès.**

- Les avertissements concernant .NET Core 2.0 (version obsolète) ont été fermés


## 2. Projets de la solution

La solution `Diayma.sln` contient **1 projet** :

- **Diayma** (`P2FixAnAppDotNetCode\Diayma.csproj`)
  - Type : Application web ASP.NET Core MVC
  - Framework : .NET Core 2.0

## 3. Version SDK .NET utilisée

Le projet utilise :
- **Target Framework** : `netcoreapp2.0` (.NET Core 2.0)

<img width="653" height="257" alt="Capture d’écran 2025-11-25 213600" src="https://github.com/user-attachments/assets/ef04abd5-ea15-4e90-b68a-11c0d37a7cf7" />

## 4. Installation du SDK

**SDK .NET Core 2.1.202 installé et vérifié**

<img width="1811" height="847" alt="Capture d’écran 2025-11-25 215222" src="https://github.com/user-attachments/assets/e2564748-f357-4939-81e0-daebb4c90b97" />





<img width="1186" height="317" alt="Capture d’écran 2025-11-25 215625" src="https://github.com/user-attachments/assets/65b7ad2a-7eb1-4d0f-87cf-3298a41c31ca" />


**Résultat** : SDK 2.1.202 installé (compatible avec .NET Core 2.0)

- L'application compile et s'exécute correctement
- URL d'accès : `http://localhost:62929`



## 5. Dépôt GitHub

dépot github créé

## 6. Bugs trouvés dans l'application

### Bug 1 : Calcul incorrect du total du panier(NAVBAR)
**Fichier** : `P2FixAnAppDotNetCode/Models/Cart.cs` - Ligne 66  
**Problème** : Le total affiché dans le navbar (en haut à droite) ne multiplie pas les prix par les quantités. La méthode `GetTotalValue()` calcule seulement la somme des prix des produits sans tenir compte des quantités.

**Manifestation** : Dans la barre de navigation bleue, le texte "Votre panier: X item(s) [MONTANT]" affiche un montant incorrect

**Code actuel (BUGUÉ) :**
```csharp
return GetCartLineList().Sum(x => x.Product.Price);
```

<img width="1672" height="867" alt="Capture d’écran 2025-11-25 220828" src="https://github.com/user-attachments/assets/664c8c25-86e9-4a84-b2cd-65b552ffb588" />




---

### Bug 2 : Calcul incorrect de la moyenne du panier
**Fichier** : `P2FixAnAppDotNetCode/Models/Cart.cs` - Ligne 77  
**Problème** :  Dans la page du panier (`/Cart/Index`), ligne "Average" affiche une moyenne incorrecte qui ne reflète pas la réalité des quantités dans le panier. La méthode `GetAverageValue()` calcule la moyenne des prix unitaires sans tenir compte des quantités.

**Code actuel (BUGUÉ) :**
```csharp
return GetCartLineList().Average(x => x.Product.Price);
```

**Manifestation** : Dans la page du panier (`/Cart/Index`), La moyenne calculée ne reflète pas la réalité des quantités dans le panier
- Elle fait une simple moyenne arithmétique des prix unitaires, ignorant que certains produits sont présents en plusieurs exemplaires

<img width="1667" height="645" alt="Capture d’écran 2025-11-25 222708" src="https://github.com/user-attachments/assets/9022e5dd-070b-4f78-a9ad-57fd9be43082" />


---

## 7. Points d'arrêt placés

Les points d'arrêt ont été placés sur les lignes suivantes :

### a) CartSummaryViewComponent.cs - Ligne 12
### b) ProductController.cs - Ligne 15
### c) OrderController.cs - Ligne 17
### d) CartController.cs - Ligne 15
### e) Startup.cs - Ligne 20

<img width="1512" height="892" alt="Capture d’écran 2025-11-25 224722" src="https://github.com/user-attachments/assets/57fcc733-db32-4192-a70d-55442a982ec2" />


## 8. Flux d'exécution détaillé - Namespaces, classes et méthodes visités


|  | Namespace | Classe | Méthode | Mode utilisé |
|---|-----------|--------|---------|--------------|
| 1 | `P2FixAnAppDotNetCode` | `Program` | `Main(string[] args)` | F10 |
| 2 | `P2FixAnAppDotNetCode` | `Program` | `BuildWebHost(string[] args)` | F11 |
| 3 | `P2FixAnAppDotNetCode` | `Startup` | `Startup(IConfiguration)` | F10 |
| 4 | `P2FixAnAppDotNetCode` | `Startup` | `ConfigureServices(...)` | F11→F10 |
| 5 | `P2FixAnAppDotNetCode` | `Startup` | `Configure(...)` | F10 |
| 6 | `Microsoft.AspNetCore.Routing` | (Framework) | Résolution route | F10 |
| 7 | `P2FixAnAppDotNetCode.Controllers` | `ProductController` | `ProductController(...)` | F10 |
| 8 | `P2FixAnAppDotNetCode.Controllers` | `ProductController` | `Index()` | F10→F11 |
| 9 | `P2FixAnAppDotNetCode.Models.Services` | `ProductService` | `GetAllProducts()` | F11→F10 |
| 10 | `P2FixAnAppDotNetCode.Models.Repositories` | `ProductRepository` | `GetAllProducts()` | F11→F10 |
| 11 | `P2FixAnAppDotNetCode.Controllers` | `ProductController` | `Index()` retour | Shift+F11 |
| 12 | `Microsoft.AspNetCore.Mvc.Razor` | (Framework) | Rendu vue | F10 |
| 13 | `P2FixAnAppDotNetCode.Components` | `CartSummaryViewComponent` | `CartSummaryViewComponent(...)` | F10 |
| 14 | `P2FixAnAppDotNetCode.Components` | `CartSummaryViewComponent` | `Invoke()` | F10 |
| 15 | `P2FixAnAppDotNetCode.Components` | `LanguageSelectorViewComponent` | `Invoke()` | F10 |

---

## 9. Déploiement en exécutable Windows

 **Déploiement réussi !**

### Lien vers le fichier .exe (le fichier diayma.exe se trouve dans publish qui a été compressé puis mis sur mon drive)

lien drive vers la ressource :

[Télécharger Diayma.exe (ZIP)](https://drive.google.com/file/d/10tlIVYQxIwHhgb8hKSHKu_urzkOsh48W/view?usp=sharing)

### Commande utilisée

```bash
cd P2FixAnAppDotNetCode
dotnet publish -c Release -r win-x64 --self-contained
```

### Résultat

L'exécutable a été généré avec succès dans le dossier :
```
P2FixAnAppDotNetCode\bin\Release\netcoreapp2.0\win-x64\publish\
```

---

## 10. Améliorations apportées au projet

### Refactoring et amélioration du code
- Remplacement de `foreach` par LINQ dans `Cart.AddItem()` pour améliorer la lisibilité
- Ajout de validation d'index dans `GetCartLineByIndex()` pour éviter les exceptions
- Nettoyage des commentaires TODO/DONE dans le code
- Amélioration de la validation dans `GetProductById()` (id <= 0)
- Simplification du code avec `FirstOrDefault()` au lieu de `Where().FirstOrDefault()`

### Ajout de validations et gestion d'erreurs
- Validation des paramètres dans `Cart.AddItem()` (null check et quantité > 0)
- Validation de l'ID dans `CartController.AddToCart()`
- Vérification du stock disponible avant d'ajouter un produit au panier
- Messages d'erreur et de succès via TempData pour améliorer le feedback utilisateur

### Refonte complète de l'UI/UX
- **Design moderne en cartes** : Transformation de la liste produits en design de cartes avec effets hover
- **Panier redesigné** : Sidebar récapitulatif avec layout amélioré et meilleure organisation
- **Animations fluides** : Gradients, ombres et transitions pour une expérience premium
- **Formulaires modernes** : Design amélioré avec validations visuelles et placeholders
- **Page de confirmation** : Redesign avec animations et design attractif
- **Micro-interactions** : Transitions sur tous les éléments interactifs
- **Responsive design** : Optimisé pour mobile et desktop
- **Système de couleurs** : Variables CSS personnalisées pour cohérence

### Support multilingue
- Ajout du support de la langue **Wolof** avec les mêmes options de culture que le français
- Création de 9 fichiers de ressources `.wo.resx` pour la traduction complète
- Intégration dans le sélecteur de langue de l'interface

---

## 11. Structure du projet

```
BoutiqueDiayma2025/
├── P2FixAnAppDotNetCode/
│   ├── Controllers/          # Contrôleurs MVC
│   ├── Models/               # Modèles de données
│   │   ├── Repositories/     # Accès aux données
│   │   └── Services/         # Logique métier
│   ├── Views/                # Vues Razor
│   ├── Resources/            # Fichiers de localisation (.resx)
│   ├── Components/           # ViewComponents
│   └── wwwroot/              # Fichiers statiques
└── README.md                 # Documentation du projet
```

---

## 12. Technologies utilisées

- **Framework** : ASP.NET Core MVC 2.0
- **Langage** : C#
- **Frontend** : Bootstrap 4, Font Awesome, jQuery
- **Localisation** : Microsoft.Extensions.Localization
- **Dependency Injection** : Built-in ASP.NET Core DI

---

## 13. Auteur

**Projet réalisé dans le cadre des Travaux Pratiques - ESP EHOD 2025**
