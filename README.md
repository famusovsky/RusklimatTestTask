# Test Task

### PostgreSQL table creation Query
```SQL
CREATE TABLE "Managers" (
    "Id" SERIAL PRIMARY KEY, 
    "Name" TEXT NOT NULL, 
	"Salary" INT NOT NULL CHECK ("Salary" >= 0), 
	"ProcessedCallsCount" INT NOT NULL CHECK ("ProcessedCallsCount" >= 0)
);

CREATE TABLE "Premiums" (
    "Id" SERIAL PRIMARY KEY, 
	"EmployeeId" INT NOT NULL CHECK ("EmployeeId" >= 0), 
	"Volume" INT NOT NULL CHECK ("Volume" >= 0), 
	"CreationDate" TIMESTAMP NOT NULL,
	FOREIGN KEY ("EmployeeId") REFERENCES "Managers"("Id")
);

CREATE TABLE "Bonuses" (
	"Id" SERIAL PRIMARY KEY, 
	"CreationDate" TIMESTAMP NOT NULL,
	"Category" INT NOT NULL CHECK ("Category" >= 0), 
	"EmployeeId" INT NOT NULL CHECK ("EmployeeId" >= 0), 
	FOREIGN KEY ("EmployeeId") REFERENCES "Managers"("Id")
);
```

### WebAPI
