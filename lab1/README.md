# ЛАБОРАТОРНА №1
Було виконано лабораторну роботу №1, де було написано консольний додаток на мові C#, де також використано деілька принципів програмувань. Детальніше про них далі.

## 1. DRY
Щоб уникнути повторення коду, я використовувала класи та надавала перевагу композиції, а не успадкуванню. Кожна операція використовується один раз у своєму методі. 

Наприклад, у [класі Program](./ProductWarehouse/Program.cs) логіка у switch-case зрозуміла, адже кожен case просто викликає відповідний метод. Завдяки цьому DRY дотримано, оскільки логіка винесена в окремі методи.

Також у цьому класі я створила [метод GetSelectedProduct](./ProductWarehouse/Program.cs#L71-L81), що довжолив у методах не дублювати код.

## 2. KISS
Зрозуміла назва класів, Їх методів та полів. Наприклад, [класі Money](./ProductWarehouseLibrary/Money.cs) створений для роботи з грошима. [метод Warehouse.DisplayProducts](./ProductWarehouseLibrary/Warehouse.cs#L18-L26) відповідає за зрозумілий форматований вивід кожного товару, а якщо склад пустий, то виводить про це повідомлення.

## 3. SOLID
### 3.1 S - Single Responsibility
Кожен клас виконує лише одну функцію: 
- [Product](./ProductWarehouseLibrary/Product.cs) – описує товар.
- [LimitedEditionProduct](./ProductWarehouseLibrary/LimitedEditionProduct.cs) – товари з обмеженим тиражем.
- [Warehouse](./ProductWarehouseLibrary/Warehouse.cs) – керує списком товарів.
- [Reporting](./ProductWarehouseLibrary/Reporting.cs) – відповідає за звітність.
- [AddNewItem](./ProductWarehouseLibrary/AddNewItem.cs) – відповідає за створення товару.
- [Money](./ProductWarehouseLibrary/Money.cs) - відповідає тільки за операції з грошима.
- [Program](./ProductWarehouse/Program.cs) – керує користувацьким інтерфейсом.

### 3.2 Open/Closed
Структура проекту дозволяє легко розширювати функціональність без зміни існуючого коду. Додавання нових типів звітів або операцій не потребує змін у базовому коді. Наприклад, якщо потрібно додати новий тип обліку товарів, то клас [Reporting](./ProductWarehouseLibrary/Reporting.cs) можна розширити, не змінюючи його основний код.

### 3.3 L – Liskov Substitution Principle
У мене є основний клас [Product](./ProductWarehouseLibrary/Product.cs), який використовується для представлення товару. Від нього є похідний клас [LimitedEditionProduct](./ProductWarehouseLibrary/LimitedEditionProduct.cs). Не змінюється код Product, а лише додається нова поведінку, тому будь-який код, що працює з Product, продовжує працювати і з LimitedEditionProduct. [Метод Display у класі LimitedEditionProduct](./ProductWarehouseLibrary/LimitedEditionProduct.cs#L19-L22) перевизначений, але не змінює загальну концепцію відображення товару.

## 4. YAGNI 
Принцип YAGNI говорить, що не потрібно додавати функціональність, якщо вона зараз не потрібна, саме тому у своєму коді я додала лише те, що використовую. Наприклад, можна додати клас або метод DeleteProduct чи ChangeProduct у [класі Product](./ProductWarehouseLibrary/Product.cs), проте наразі я їх не використовувала, а додавати "на майбутнє" не варто. Я не створювала складної логіки заздалегідь.

## 5. Composition Over Inheritance
У коді [Product](./ProductWarehouseLibrary/Product.cs) не успадковує [Money](./ProductWarehouseLibrary/Money.cs), а містить його як [окремий об'єкт](./ProductWarehouseLibrary/Product.cs#L).

Замість того, щоб створювати [Warehouse](./ProductWarehouseLibrary/Warehouse.cs) як підклас [Product](./ProductWarehouseLibrary/Product.cs) (що було б неправильно, адже склад не є товаром), Warehouse містить [список Product](./ProductWarehouseLibrary/Warehouse.cs#L11). Це дозволяє Warehouse працювати з будь-якими підкласами Product, наприклад [LimitedEditionProduct](./ProductWarehouseLibrary/LimitedEditionProduct.cs).

Також Reporting приймає Warehouse [як параметр у методах](./ProductWarehouseLibrary/Reporting.cs#L11-16) (у прикладі представлений один метод, хоча таке спостерігається у всіх методах поточного класу. 