# Task Manager - Správce úkolù

## Popis øešení

Konzolová aplikace pro správu osobního seznamu úkolù s možností:
- **Pøidávání úkolù** (`add <název>`)
- **Odstraòování úkolù** (`remove <id>`)
- **Oznaèování jako splnìné** (`complete <id>`)
- **Zobrazení seznamu** (`list`)
- **Vrácení operace zpìt** (`undo`)

## Použitý návrhový vzor: Command Pattern

### Proè Command Pattern?

1. **Oddìlení zodpovìdností** - Kód pro ètení pøíkazù od uživatele (ConsoleUI) je zcela oddìlený od kódu, který mìní seznam úkolù (Commands + TaskList).

2. **Snadná rozšiøitelnost** - Pro pøidání nové operace staèí vytvoøit novou tøídu implementující `ICommand`. Není potøeba mìnit existující kód.

3. **Podpora Undo** - Každý pøíkaz si pamatuje stav pøed provedením a umí se vrátit zpìt.

4. **Historie pøíkazù** - `CommandInvoker` uchovává zásobník provedených pøíkazù pro Undo operace.

### Struktura projektu

```
TaskManager/
??? Models/
?   ??? TaskItem.cs      # Model úkolu
?   ??? TaskList.cs      # Správa seznamu úkolù (Receiver)
??? Commands/
?   ??? ICommand.cs      # Rozhraní pro pøíkazy
?   ??? AddTaskCommand.cs
?   ??? RemoveTaskCommand.cs
?   ??? CompleteTaskCommand.cs
?   ??? CommandInvoker.cs # Správa historie pøíkazù
??? UI/
?   ??? ConsoleUI.cs     # Konzolové rozhraní (Client)
??? Program.cs           # Vstupní bod
```

### Jak pøidat novou operaci

1. Vytvoøte novou tøídu implementující `ICommand`
2. Implementujte metody `Execute()` a `Undo()`
3. Pøidejte zpracování v `ConsoleUI.ProcessInput()`

### Pøíklad použití

```
> add Nakoupit mléko
Úkol 'Nakoupit mléko' byl pøidán s ID 1.

> add Zaplatit úèty
Úkol 'Zaplatit úèty' byl pøidán s ID 2.

> list
=== Seznam úkolù ===
1. [ ] Nakoupit mléko
2. [ ] Zaplatit úèty

> complete 1
Úkol 'Nakoupit mléko' byl oznaèen jako splnìný.

> list
=== Seznam úkolù ===
1. [?] Nakoupit mléko
2. [ ] Zaplatit úèty

> undo
Oznaèení úkolu 'Nakoupit mléko' jako splnìného bylo vráceno zpìt.

> remove 2
Úkol 'Zaplatit úèty' byl odstranìn.

> undo
Úkol 'Zaplatit úèty' byl obnoven.
```
