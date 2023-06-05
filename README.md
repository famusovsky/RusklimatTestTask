# Test Task

## [Задание](https://clck.ru/34cJbf)

### Для запуска проекта необходимо:

1. Создать базу данных PostgreSQL
2. Создать таблицы [(см. ниже)](#postgresql-query-для-создания-таблиц)
3. Изменить строку подключения в файле appsettings.json
4. Запустить проект: `dotnet run` из корневой папки проекта

### PostgreSQL Query для создания таблиц
```SQL
CREATE TABLE "Managers" (
    "Id" SERIAL PRIMARY KEY, 
    "Name" TEXT NOT NULL, 
    "DefaultSalary" INT NOT NULL CHECK ("DefaultSalary" >= 0)
);

CREATE TABLE "ProcessedCalls" (
    "Id" SERIAL PRIMARY KEY, 
    "EmployeeId" INT NOT NULL CHECK ("EmployeeId" >= 0), 
    "Date" DATE NOT NULL, 
    "Count" INT NOT NULL CHECK ("Count" >= 0), 
    FOREIGN KEY ("EmployeeId") REFERENCES "Managers"("Id")
);

CREATE TABLE "Bonuses" (
    "Id" SERIAL PRIMARY KEY, 
    "EmployeeId" INT NOT NULL CHECK ("EmployeeId" >= 0), 
    "Category" INT NOT NULL CHECK ("Category" >= 0), 
    "CreationDate" DATE NOT NULL, 
    FOREIGN KEY ("EmployeeId") REFERENCES "Managers"("Id")
);

CREATE TABLE "Premiums" (
    "Id" SERIAL PRIMARY KEY, 
    "EmployeeId" INT NOT NULL CHECK ("EmployeeId" >= 0), 
    "Volume" INT NOT NULL CHECK ("Volume" >= 0), 
    "CreationDate" DATE NOT NULL, 
    FOREIGN KEY ("EmployeeId") REFERENCES "Managers"("Id")
);
```

### Swagger URL: `<domain>/swagger`