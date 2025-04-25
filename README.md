
# 🍕 PizzaStore API

Bienvenue dans l'API **PizzaStore** !  
Ce projet est une API RESTful simple permettant de gérer des pizzas. Vous pouvez **ajouter**, **modifier**, **supprimer** et **consulter** des pizzas via des endpoints bien définis.

---

## 🚀 Fonctionnalités

- **Lister toutes les pizzas** : Obtenez une liste de toutes les pizzas disponibles.
- **Ajouter une pizza** : Ajoutez une nouvelle pizza à la base de données.
- **Modifier une pizza** : Mettez à jour les informations d'une pizza existante.
- **Supprimer une pizza** : Supprimez une pizza de la base de données.
- **Consulter une pizza par ID** : Obtenez les détails d'une pizza spécifique.

---

## 🛠️ Prérequis

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQLite](https://www.sqlite.org/index.html) (utilisé comme base de données par défaut)

---

## ⚙️ Installation

1. Clonez le dépôt :
   ```bash
   git clone https://github.com/ImaneBacar/ApiPizzaStore
   cd ApiPizzaStore-main
   ```

2. Restaurez les dépendances :
   ```bash
   dotnet restore
   ```

3. Lancez l'application :
   ```bash
   dotnet run
   ```

4. Accédez à l'interface Swagger :  
   [http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 📡 Endpoints de l'API

### 1. `GET /pizzas`  
Récupère la liste de toutes les pizzas.

**Réponse :**
```json
[
  {
    "id": 1,
    "nom": "Margherita",
    "description": "Tomate, mozzarella, basilic"
  }
]
```

---

### 2. `GET /pizza/{id}`  
Récupère une pizza spécifique par son ID.

**Réponse :**
```json
{
  "id": 1,
  "nom": "Margherita",
  "description": "Tomate, mozzarella, basilic"
}
```

---

### 3. `POST /pizza`  
Ajoute une nouvelle pizza.

**Corps de la requête :**
```json
{
  "nom": "Pepperoni",
  "description": "Tomate, mozzarella, pepperoni"
}
```

**Réponse :**
```json
{
  "id": 2,
  "nom": "Pepperoni",
  "description": "Tomate, mozzarella, pepperoni"
}
```

---

### 4. `PUT /pizza/{id}`  
Met à jour une pizza existante.

**Corps de la requête :**
```json
{
  "nom": "Quatre Fromages",
  "description": "Tomate, mozzarella, gorgonzola, parmesan, chèvre"
}
```

**Réponse :**
```json
{
  "message": "Pizza mise à jour avec succès."
}
```

---

### 5. `DELETE /pizza/{id}`  
Supprime une pizza par son ID.

**Réponse :**
```json
{
  "message": "Pizza supprimée avec succès."
}
```

---

## 🗄️ Configuration de la base de données

La base de données SQLite est utilisée par défaut.  
Le fichier `Pizzas.db` est créé automatiquement dans le répertoire du projet.

Si vous souhaitez utiliser une autre base de données, modifiez la chaîne de connexion dans le fichier `appsettings.json` :

```json
{
  "ConnectionStrings": {
    "Pizzas": "DataSource=Pizzas.db"
  }
}
```

---

## 📖 Documentation Swagger

Swagger est activé pour explorer et tester l'API.  
Accédez à l'interface Swagger ici :  
[http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 🔮 Améliorations futures

- Implémenter une authentification pour sécuriser l'API.
- Ajouter des tests unitaires pour garantir la fiabilité du code.

---

## 🤝 Contribution

Les contributions sont les bienvenues !  
N'hésitez pas à **ouvrir une issue** ou à **soumettre une pull request**.
