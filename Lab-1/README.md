## Дотримання принципів програмування

### 1. **Single Responsibility Principle**
Кожен клас виконує тільки одну відповідальність

- `Lion`, `Parrot` – лише представлення тварин [рядки](Lab-1/Animals.cs#L15-L26)
- `Zookeeper`, `Veterinarian` – лише типи співробітників [рядки](Lab-1/Employees.cs#L14-L23)
- `Enclosure` – управління тваринами у вольєрі [рядки](Lab-1/Enclosure.cs#L9-L32)
- `ZooInventory` – облік тварин і працівників [рядки](Lab-1/ZooInventory.cs#L9-L39)

---

### 2. **O – Open/Closed Principle**
Класи відкриті для розширення

- Нові тварини можуть бути додані, не змінюючи існуючий код. Наприклад, додати клас `Elephant : IAnimal` без змін в `ZooInventory`.

---

### 3. **L – Liskov Substitution Principle**
Будь-який екземпляр `Lion`, `Parrot` може бути використаний замість `IAnimal`.

- Метод `AddAnimal(IAnimal)` приймає будь-яку тварину, яка реалізує інтерфейс. Приклад:
[рядок](Lab-1/Enclosure.cs#L19)  
[рядки](Lab-1/Program.cs#L17-L18)

---

### 4. **I – Interface Segregation Principle**
Кожен інтерфейс має вузьку спеціалізацію

- `IAnimal` — тільки методи, що стосуються тварин  
- `IEmployee` — тільки метод, що стосується працівника  
[`Animals.cs`](Lab-1/Animals.cs#L9-L13)  
[`Employees.cs`](Lab-1/Employees.cs#L9-L13)

---

### 5. **D – Dependency Inversion Principle**
Використання залежностей через абстракції

- `ZooInventory`, `Enclosure` працюють із `IAnimal`, `IEmployee`, а не з конкретними класами  
[`ZooInventory.cs`](Lab-1/ZooInventory.cs#L11-L12)  
[`Enclosure.cs`](Lab-1/Enclosure.cs#L12)

---

### 6. **DRY – Don’t Repeat Yourself**
Повторюваний код винесено в абстракції

- `IAnimal` та `IEmployee` дозволяють уникати дублювання логіки для всіх тварин та працівників    

---

### 7. **KISS – Keep It Simple, Stupid**
Прості та зрозумілі класи без зайвих залежностей

- Мінімум логіки в кожному класі — лише те, що потрібно для демонстрації зв’язків  
[`Program.cs`](Lab-1/Program.cs)

---

### 8. **YAGNI – You Aren’t Gonna Need It**
Не реалізовано зайвої функціональності, яка не вимагається

- Відсутні непотрібні класи типу `Food`, `Schedule`, бо хватає і тих шо є  
- Кожен клас має тільки ті поля і методи, яких дсотатньо для демонстрації  
