
## Question 1:  Pourquoi b affiche 44

``` C#
short s = 300;
byte b = (byte)s;
```

La raison pour laquelle b affiche 44 en C# est que la valeur maximale que peut contenir un type de données byte est 255. Lorsque vous affectez une valeur plus grande que cela à une variable de type byte, cela provoque une "débordement". Dans ce cas précis, l'opération de cast en byte effectuée sur la variable *s* lui a attribué la valeur 44. Cela se produit parce que 300 en binaire est 100101100, qui est trop grand pour être stocké dans un byte. Lorsque la valeur est tronquée pour correspondre à un byte, il reste seulement 44 en binaire, soit 00101100 en binaire, ce qui correspond à la valeur 44 en décimal.

## Question 2: Expliquer le fonctionnement des enums

Un énumération (ou enum en abrégé) en C# est une façon de définir un type de données qui peut prendre une valeur parmi un ensemble prédéfini de valeurs. Chaque valeur de l'énumération est représentée par un nom lisible par l'homme, appelé membre de l'énumération.

``` C#
// Enums en C#
public enum Couleur
{
    Rouge,
    Vert,
    Bleu
}

Couleur maCouleurPreferée = Couleur.Rouge;

```

Dans cet exemple, la variable "maCouleurPreferée" est de type "Couleur" et contient la valeur "Rouge".

Les énumérations sont utiles pour définir des valeurs prédéfinies qui peuvent être utilisées dans votre code, ce qui peut rendre votre code plus lisible et plus facile à maintenir.


## Question 3: Expliquer la différence entre deux tableaux

```  C#
int[,] a = new int[1,2];
int[,,] b = new int[1,2,3];
```

La différence entre les deux tableau dans le nombre de dimensions.

Le tableau *a*  à deux dimensions est un tableau qui contient des lignes et des colonnes de valeurs. Dans l'exemple donné, le tableau "a" a une ligne et deux colonnes.
```
|   |   |
| 1 | 2 |

```

Le tableau *b* à trois dimensions est un tableau qui contient des lignes, des colonnes et des profondeurs. Dans l'exemple donné, le tableau "b" a une ligne, deux colonnes et trois profondeurs.

## Question 4: Définir le termes "assembly"

En programmation, un assembly est un fichier exécutable ou bibliothèque de code qui contient du code machine (instructions exécutables par un processeur) ou du code intermédiaire (code généré par un compilateur) ainsi que des informations sur les types, les ressources et les références aux autres assemblies.

Les assemblies sont utilisés dans les environnements de programmation tels que .NET et Java pour organiser et gérer les différents composants logiciels d'une application. Ils peuvent être utilisés pour regrouper des classes et des fonctions qui effectuent des tâches similaires, pour partager du code entre plusieurs applications, pour gérer les dépendances entre différents composants d'une application et pour protéger le code source d'une application en le compilant en code machine ou intermédiaire.

Les assemblies peuvent être chargés à la volée par un programme ou être préchargés dans la mémoire pour une utilisation ultérieure. Ils peuvent également être signés numériquement pour vérifier leur authenticité et leur intégrité.

## Question 5: Exemple d'usage du mot clé Private

Un exemple d'utilisation du mot-clé "private" en programmation est lorsque qu'on définie une variable d'instance dans une classe en tant que "private". Cela signifie que la variable ne peut être modifiée ou accédée que par les membres de la classe elle-même et non par des classes externes.

Exemple:
``` c#
public class CompteBancaire
{
    private decimal montant;

    public void AjouterArgent(decimal montantAAjouter)
    {
        montant += montantAAjouter;
    }

    public void RetirerArgent(decimal montantARetirer)
    {
        montant -= montantARetirer;
    }

    public decimal ObtenirMontant()
    {
        return montant;
    }
}
```

La variable d'instance "montant" est déclarée en tant que "private" dans la classe "CompteBancaire". Cela signifie que seuls les membres de la classe "CompteBancaire", tels que les méthodes "AjouterArgent", "RetirerArgent" et "ObtenirMontant", peuvent accéder et modifier la variable. Si une autre classe essayait d'accéder à la variable "montant", cela générerait une erreur de compilation.

Donc elle permet de protéger la variable d'instance "montant" contre les modifications ou les accès non autorisés de la part de classes externes.

## Question 6: Qu'est-ce qu'un ORM

Un ORM (Object-Relational Mapping) est un type de logiciel qui permet de gérer la conversion des données entre un format objet utilisé dans les programmes informatiques et un format relationnel utilisé dans les bases de données.

Les ORM sont couramment utilisés dans les applications informatiques qui utilisent des bases de données relationnelles, comme MySQL, Oracle ou SQL Server. Ils permettent aux développeurs de travailler avec des données de base de données sous forme d'objets dans leur code, plutôt que de devoir écrire des requêtes SQL complexes pour récupérer et manipuler les données.

## Source:

- [Wikipédia](https://fr.wikipedia.org/wiki/Mapping_objet-relationnel)
- [Microsoft assembly](https://learn.microsoft.com/en-us/dotnet/standard/assembly/)
- [Microsoft enum](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum)
