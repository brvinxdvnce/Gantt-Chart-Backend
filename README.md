# Gantt-Chart-Backend

## Эндпоинты ProjectController

**Базовый путь:** `/api/projects`  
**Требование:** Все запросы требуют авторизации (JWT)

### Основные операции с проектами:
- `POST /api/projects` - Создание нового проекта
- `GET /api/projects/{projectId}` - Получение полной информации о проекте
- `PATCH /api/projects/{projectId}` - Обновление данных проекта
- `DELETE /api/projects/{projectId}` - Удаление проекта
#
- `POST /api/projects/{projectId}/members?userId={userId}` - Добавление пользователя в проект
- `DELETE /api/projects/{projectId}/members/{userId}` - Удаление пользователя из проекта
- `PATCH /api/projects/{projectId}/members/{userId}` - Изменение роли пользователя в проекте

**Примечание:** Все GUID параметры должны быть в формате UUID. Текущий пользователь определяется из JWT токена автоматически.


## Эндпоинты TaskController

**Базовый путь:** `/api/tasks`  
**Требование:** Все запросы требуют авторизации (JWT)

### Основные операции с задачами:
- `POST /api/tasks` - Создание новой задачи
- `GET /api/tasks/{taskId}` - Получение информации о задаче
- `PATCH /api/tasks/{taskId}` - Обновление данных задачи
- `DELETE /api/tasks/{taskId}` - Удаление задачи

### Управление зависимостями задач:
- `POST /api/tasks/{taskId}/dependence` - Добавление зависимости между задачами
- `DELETE /api/tasks/{taskId}/dependence` - Удаление зависимости между задачами

### Управление исполнителями:
- `POST /api/tasks/{taskId}/performers?userId={userId}` - Добавление исполнителя к задаче
- `DELETE /api/tasks/{taskId}/performers?userId={userId}` - Удаление исполнителя из задачи

**Примечание:** Все GUID параметры должны быть в формате UUID. Текущий пользователь определяется из JWT токена автоматически.