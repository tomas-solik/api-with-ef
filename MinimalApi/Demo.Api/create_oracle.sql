BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"Manufacturers" (
    "Id" NUMBER(19) GENERATED BY DEFAULT ON NULL AS IDENTITY NOT NULL,
    "Name" NVARCHAR2(2000) NOT NULL,
    CONSTRAINT "PK_Manufacturers" PRIMARY KEY ("Id")
)';
END;/


BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"Users" (
    "Username" NVARCHAR2(450) NOT NULL,
    "FirstName" NVARCHAR2(255) NOT NULL,
    "Email" NVARCHAR2(255) NOT NULL,
    "Password" NVARCHAR2(2000) NOT NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("Username")
)';
END;/


BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"Models" (
    "Id" NUMBER(19) GENERATED BY DEFAULT ON NULL AS IDENTITY NOT NULL,
    "Name" NVARCHAR2(2000) NOT NULL,
    "Description" NVARCHAR2(2000) NOT NULL,
    "ToolType" NUMBER(10) NOT NULL,
    "ManufacturerId" NUMBER(19) NOT NULL,
    CONSTRAINT "PK_Models" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Models_Manufacturers_ManufacturerId" FOREIGN KEY ("ManufacturerId") REFERENCES "Manufacturers" ("Id") ON DELETE CASCADE
)';
END;/


BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"Tools" (
    "Id" NUMBER(19) GENERATED BY DEFAULT ON NULL AS IDENTITY NOT NULL,
    "Name" NVARCHAR2(2000) NOT NULL,
    "ModelId" NUMBER(19) NOT NULL,
    "NominalValue" NUMBER(10) NOT NULL,
    CONSTRAINT "PK_Tools" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Tools_Models_ModelId" FOREIGN KEY ("ModelId") REFERENCES "Models" ("Id") ON DELETE CASCADE
)';
END;/


BEGIN 
EXECUTE IMMEDIATE 'CREATE TABLE 
"TestPoints" (
    "Id" NUMBER(19) GENERATED BY DEFAULT ON NULL AS IDENTITY NOT NULL,
    "TargetTorque" DECIMAL(18, 2) NOT NULL,
    "TargetAngle" DECIMAL(18, 2) NOT NULL,
    "ToolId" NUMBER(19) NOT NULL,
    CONSTRAINT "PK_TestPoints" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_TestPoints_Tools_ToolId" FOREIGN KEY ("ToolId") REFERENCES "Tools" ("Id") ON DELETE CASCADE
)';
END;/


CREATE INDEX "IX_Models_ManufacturerId" ON "Models" ("ManufacturerId")/


CREATE INDEX "IX_TestPoints_ToolId" ON "TestPoints" ("ToolId")/


CREATE INDEX "IX_Tools_ModelId" ON "Tools" ("ModelId")/


