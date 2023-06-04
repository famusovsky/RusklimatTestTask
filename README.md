# Test Task

### PostgreSQL table creation Query
```SQL
CREATE TABLE "Managers" (
    "Id" SERIAL PRIMARY KEY, 
    "Name" TEXT NOT NULL, 
	"Salary" INT NOT NULL CHECK ("Salary" >= 0)
);

CREATE TABLE "Premiums" (
    "Id" SERIAL PRIMARY KEY, 
	"EmployeeId" INT NOT NULL CHECK ("EmployeeId" >= 0), 
	"Volume" INT NOT NULL CHECK ("Volume" >= 0), 
	"CreationDate" DATE NOT NULL,
	FOREIGN KEY ("EmployeeId") REFERENCES "Managers"("Id")
);

CREATE TABLE "Bonuses" (
	"Id" SERIAL PRIMARY KEY, 
	"EmployeeId" INT NOT NULL CHECK ("EmployeeId" >= 0), 
	"Category" INT NOT NULL CHECK ("Category" >= 0), 
	"CreationDate" DATE NOT NULL,
	FOREIGN KEY ("EmployeeId") REFERENCES "Managers"("Id")
);

CREATE TABLE "ProcessedCalls" (
	"Id" SERIAL PRIMARY KEY, 
	"EmployeeId" INT NOT NULL CHECK ("EmployeeId" >= 0), 
	"Date" DATE NOT NULL,
	"Count" INT NOT NULL CHECK ("Count" >= 0), 
	FOREIGN KEY ("EmployeeId") REFERENCES "Managers"("Id")
);
```

### WebAPI
