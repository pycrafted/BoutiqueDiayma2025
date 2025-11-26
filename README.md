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

![Fichier Diayma.csproj montrant le Target Framework](Capture d'écran 2025-11-25 213600.png)


## 4. Installation du SDK

**SDK .NET Core 2.1.202 installé et vérifié**

![Confirmation de téléchargement du SDK .NET Core 2.0](Capture d'écran 2025-11-25 215222.png)

![Vérification des SDK installés avec dotnet --list-sdks](Capture d'écran 2025-11-25 215625.png)

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

![Bug du navbar - Total incorrect du panier affiché](Capture d'écran 2025-11-25 220828.png)



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

![Bug de la moyenne du panier - Moyenne incorrecte affichée](Capture d'écran 2025-11-25 222708.png)

---


## 7. Points d'arrêt placés

Les points d'arrêt ont été placés sur les lignes suivantes :

### a) CartSummaryViewComponent.cs - Ligne 12
### b) ProductController.cs - Ligne 15
### c) OrderController.cs - Ligne 17
### d) CartController.cs - Ligne 15
### e) Startup.cs - Ligne 20

![Point d'arrêt dans Visual Studio Code - Startup.cs ligne 20](Capture d'écran 2025-11-25 224722.png)

## 8. Flux d'exécution détaillé - Namespaces, classes et méthodes visités


| # | Namespace | Classe | Méthode | Mode utilisé |
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

✅ **Déploiement réussi !**

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
