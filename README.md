# Unity Test Assignment — Game Systems Developer

Прототип top-down survival shooter: арена, враги, боевая система, статистика, мета-прогрессия.

## Управление
- **WASD** — движение
- **Мышь** — прицел
- **ЛКМ** — атака
- **Space** — dash в сторону курсора

## Архитектура

**Combat:**
- `DamageSystem` — единый пайплайн урона (по-желанию - с модификаторами (`CritModifier`, `ArmorModifier`)).
- `IDamageable` / `Health` — здоровье.
- `AbilityBase` (ScriptableObject) + `AbilityComponent` — способности с кулдаунами. Упрощенный аналог GAS из Unreal Engine.

**AI:**
- `EnemyController` — движение к игроку через `Rigidbody.MovePosition`.
- `EnemyAttack` — `OverlapSphere` + урон через `DamageSystem`.

**Stats (Observer):**
- `StatsComponent` (Subject) → `StatsUI` (Observer).
- Метрики: время боя, нанесённый/полученный урон, убийства, смерти.

**Save/Load:**
- `ISaveLoad` + `PlayerPrefsSaveLoad` + `SaveManager` (Singleton, DontDestroyOnLoad).
- Сохраняется: валюта (и прочее по-желанию)

**Game Flow:**
- MainMenu → LoadingScene → GameLevel.
- `GameManager` (Singleton) — победа/поражение через события.
- `ArenaTrigger` — спавн врагов при входе на арену.

## Сцены
- **MainMenu** — `SaveManager`, `MenuUI`.
- **GameLevel** — `GameManager`, Player (`StatsComponent`), `EnemySpawner`, Canvas (`StatsUI`, `ResultPanel`).

## Принципы
- Единый пайплайн урона.
- Интерфейсы (`IDamageable`, `IDamageModifier`, `ISaveLoad`, `IObserver`).
- ScriptableObject для данных.
- События для развязки UI и логики.
- Композиция `Subject` внутри `StatsComponent` (вместо наследования).

## Технологии
Unity 2022+ |
C# |
Rigidbody physics |
ScriptableObject |
Unity UI (Legacy) |
PlayerPrefs
