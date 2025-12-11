## Použitý návrhový vzor: Command Pattern

UI - Kód pro čtení příkazů od uživatele (ConsoleUI) je zcela oddělený od kódu, který mění seznam úkolů (Commands + TaskList)

Pro přidání dalšího commandu stačí vytvořit třídu, která implementuje ICommand a zavolat ji v ConsoleUI

Konzolová aplikace pro správu osobního seznamu úkolů s možností:
- **Přidávání úkolů** (`add <name>`)
- **Odstraňování úkolů** (`remove <id>`)
- **Označování jako splněné** (`complete <id>`)
- **Zobrazení seznamu** (`list`)
- **Vrácení operace zpět** (`undo`)
